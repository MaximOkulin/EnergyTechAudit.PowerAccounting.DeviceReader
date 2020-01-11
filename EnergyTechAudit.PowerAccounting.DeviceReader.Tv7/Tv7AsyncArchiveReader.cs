using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7
{
    public partial class Tv7
    {
        private List<Tv7Event> _tv7Events;
        private void ReadAsyncArchives(AsyncArchiveType archiveType)
        {
            string dynamicParameterCode = GetAsyncArchiveDynamicParameterCode(archiveType);

            ResetDynamicParameterValue(archiveType);

            var tv7Events = new Tv7Events();
            _tv7Events = tv7Events.Events;
            
            ReadAsyncArchiveInfo(archiveType);
            byte[] buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            // максимальное кол-во записей АИБД
            int maxCount = BitConverter.ToInt16(new [] {buffer[4], buffer[3]}, 0);
            // индекс записи, в который будет произведено сохранение архивной информации в следующий раз
            int nextIndex = BitConverter.ToInt16(new[] {buffer[6], buffer[5]}, 0);

            // признак закольцованности архива
            bool isLoopBack = Convert.ToBoolean(buffer[10] & 0x01);

            var lastReadedIndex = GetLastIndexFromDynamicData(dynamicParameterCode);
            
            // архив закольцован
            if (isLoopBack)
            {
                // еще ни разу не читали
                if (lastReadedIndex == -1)
                {
                    // читаем от самой старой записи архива во всю глубину архива
                    for (var i = nextIndex; i <= maxCount - 1; i++)
                    {
                        ReadAsyncArchive(archiveType, i);
                    }

                    if (nextIndex != 0)
                    {
                        // читаем "голову", которая находится в начале архива
                        for (var i = 0; i < nextIndex; i++)
                        {
                            ReadAsyncArchive(archiveType, i);
                        }
                    }
                }
                else
                {
                    // архив уже читался, дополняем его недостающими записями
                    // если "хвост" лежит раньше "головы"
                    if (lastReadedIndex < nextIndex - 1)
                    {
                        for (var i = lastReadedIndex + 1; i < nextIndex; i++)
                        {
                            ReadAsyncArchive(archiveType, i);
                        }
                    }
                    // если "голова" лежит раньше "хвоста"
                    else if (lastReadedIndex > nextIndex)
                    {
                        // дочитываем архивы во всю глубину
                        for (var i = lastReadedIndex + 1; i <= maxCount - 1; i++)
                        {
                            ReadAsyncArchive(archiveType, i);
                        }
                        if (nextIndex != 0)
                        {
                            // читаем часть "головы" лежащей в начале
                            for (var i = 0; i < nextIndex; i++)
                            {
                                ReadAsyncArchive(archiveType, i);
                            }
                        }
                    }
                }

            }
            // архив незакольцован
            else
            {
                // еще ни разу не читали
                if (lastReadedIndex == -1)
                {
                    // в архиве есть записи
                    if (nextIndex > 0)
                    {
                        for (var i = 0; i < nextIndex; i++)
                        {
                            ReadAsyncArchive(archiveType, i);
                        }
                    }
                }
                else
                {
                    if (lastReadedIndex < nextIndex - 1)
                    {
                        for (var i = lastReadedIndex + 1; i < nextIndex; i++)
                        {
                            ReadAsyncArchive(archiveType, i);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Читает информацию об асинхронном архиве
        /// </summary>
        /// <param name="archiveType">Тип асинхронного архива</param>
        private void ReadAsyncArchiveInfo(AsyncArchiveType archiveType)
        {
            switch (archiveType)
            {
                    case AsyncArchiveType.DatabaseChanges: _actionSteps.ReadDatabaseChangesArchivesInfo();
                    break;
                    case AsyncArchiveType.Events: _actionSteps.ReadEventsArchivesInfo();
                    break;
                    case AsyncArchiveType.Diagnostic: _actionSteps.ReadDiagnosticArchivesInfo();
                    break;
            }
        }

        /// <summary>
        /// Сбрасывает индекс асинхронного архива, если в базе нет ни одной записи
        /// </summary>
        /// <param name="archiveType">Тип асинхронного архива</param>
        private void ResetDynamicParameterValue(AsyncArchiveType archiveType)
        {
            string dynamicParameterCode = GetAsyncArchiveDynamicParameterCode(archiveType);
            
            var condition = ConditionFactory.GetCondition(archiveType);

            var journalRowsCount = GetMeasurementDeviceJournalCount(condition);

            if (journalRowsCount == 0)
            {
                UpdateLastIndexDynamicParameter(dynamicParameterCode, -1);
            }
        }

        private void ReadAsyncArchive(AsyncArchiveType archiveType)
        {
            switch (archiveType)
            {
                case AsyncArchiveType.DatabaseChanges:
                    _actionSteps.ReadDatabaseChangesArchive();
                    break;
                    case AsyncArchiveType.Events:
                    _actionSteps.ReadEventsArchive();
                    break;
                    case AsyncArchiveType.Diagnostic:
                    _actionSteps.ReadDiagnosticArchive();
                    break;
            }
        }

        /// <summary>
        /// Читает запись асинхронного архива
        /// </summary>
        /// <param name="archiveType">Тип асинхронного архива</param>
        /// <param name="index">Индекс архивной записи</param>
        private void ReadAsyncArchive(AsyncArchiveType archiveType, int index)
        {
            RaiseTraceInfoPassedEvent(string.Format(TraceMessages.Tv7ReadAsyncArchive, index, archiveType));

            string dynamicParameterCode = GetAsyncArchiveDynamicParameterCode(archiveType);

            _actionSteps.SetAsyncArchiveIndex(index);
            
            ReadAsyncArchive(archiveType);

            byte[] buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            var time = _parser.GetDateArchiveFromBuffer(buffer, 0);
            Int16 param = BitConverter.ToInt16(new byte[] { buffer[10], buffer[9] }, 0);
            int eventNumber = param & 511; // (0x01FF)
            int pipeOrInputNumber = (buffer[9] >> 1) & 0x07;
            int databaseNumber = (buffer[9] >> 7) & 0x01;

            var tv7Event = _tv7Events.FirstOrDefault(p => p.EventNumber == eventNumber && p.AsyncArchiveType == archiveType);

            if (tv7Event != null)
            {
                if (!Context.Set<LightDataAccess.Dictionaries.InternalDeviceEvent>().Any())
                {
                    LoadInternalDeviceEvents();
                }

                var internalDeviceEvent = Context.Set<LightDataAccess.Dictionaries.InternalDeviceEvent>().FirstOrDefault(p => p.Id == tv7Event.InternalDeviceEventId);

                if (internalDeviceEvent != null)
                {
                    string originalValue = tv7Event.ValueParser(new[] {buffer[11], buffer[12], buffer[13], buffer[14]});
                    string currentValue = string.Empty;

                    if (archiveType == AsyncArchiveType.DatabaseChanges)
                    {
                        currentValue = tv7Event.ValueParser(new[] {buffer[15], buffer[16], buffer[17], buffer[18]});
                    }

                    var measurementDeviceJournal = new MeasurementDeviceJournal
                    {
                        MeasurementDeviceId = MeasurementDevice.Id,
                        Time = time,
                        Description = tv7Event.CreateDescription(internalDeviceEvent, pipeOrInputNumber, databaseNumber),
                        OriginalValue = originalValue,
                        CurrentValue = currentValue,
                        InternalDeviceEventId = internalDeviceEvent.Id
                    };

                    ArchiveCollector.MeasurementDeviceJournals.Add(measurementDeviceJournal);

                    if (ArchiveCollector.SaveArchives())
                    {
                        UpdateLastIndexDynamicParameter(dynamicParameterCode, index);
                    }
                    else
                    {
                        // если неудачное сохранение журнальной записи, то проверяем не была ли попытка сохранить дубликат
                        if(HasMeasurementDeviceJournalDuplicate(measurementDeviceJournal))
                        {
                            // такая журнальная запись уже существует в базе, поэтому сохраняем новое значение динамического параметра
                            UpdateLastIndexDynamicParameter(dynamicParameterCode, index);
                        }
                        else
                        {
                            throw new Exception(DeviceMessages.SaveMeasurementDeviceJournalError);
                        }                     
                    }
                }
            }
        }

        /// <summary>
        /// Обновляет значение динамического параметра индекса асинхронного архива в БД
        /// </summary>
        /// <param name="code">Код динамического параметра</param>
        /// <param name="index">Новое значение индекса</param>
        private void UpdateLastIndexDynamicParameter(string code, int index)
        {
            var dynamicValue = GetDynamicParameterValue(code);

            if (dynamicValue != null)
            {
                dynamicValue.Value = Convert.ToString(index);

                SetValueToDynamicData(dynamicValue);
            }
            else
            {
                throw new Exception(string.Format(DeviceMessages.DynamicParameterNotFound, code));
            }
        }

        /// <summary>
        /// Возвращает из динамического параметра индекс последней считанной записи асинхронного архива
        /// </summary>
        /// <param name="code">Код динамического параметра</param>
        private int GetLastIndexFromDynamicData(string code)
        {
            var dynamicValue = GetDynamicParameterValue(code);

            if (dynamicValue != null)
            {
                return Convert.ToInt32(dynamicValue.Value);
            }


            throw new Exception(string.Format(DeviceMessages.DynamicParameterNotFound, code));
        }

        private string GetAsyncArchiveDynamicParameterCode(AsyncArchiveType archiveType)
        {
            switch (archiveType)
            {
                    case AsyncArchiveType.DatabaseChanges:
                    return DeviceMessages.Tv7AIBDLastIndexDynamicParameterCode;
                    case AsyncArchiveType.Events:
                    return DeviceMessages.Tv7AASLastIndexDynamicParameterCode;
                    case AsyncArchiveType.Diagnostic:
                    return DeviceMessages.Tv7ADLastIndexDynamicParameterCode;
                default:
                    return string.Empty;
            }
        }

        private void LoadInternalDeviceEvents()
        {
            using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    Context.Set<LightDataAccess.Dictionaries.InternalDeviceEvent>().Where(p => p.DeviceId == (int)DeviceModel.TV7).Load();
                   tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.CommonTypes;
using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7
{
    /// <summary>
    /// Класс обработки информации при обмене с ВКТ-7
    /// </summary>
    public partial class Vkt7
    {
        private void ReadInstantArchives(bool canSave)
        {
            // a. Задаём, что будем читать текущие мгновенные данные
            RaiseTraceInfoPassedEvent(TraceMessages.Vkt7ReadInstantArchives);
            _actionSteps.SetValueType(ValueTypes.Instant);

            // б. Проверяем активен ли первый канал и читаем данные
            if (_isFirstChannelActive)
            {
                Func<Parameter, bool> predicate = p => p.BeInstant && (p.HeatInput == TraceMessages.Vkt7ChannelOne);
                ExecuteReadParameters(predicate, SetReadElementsList(predicate), PeriodType.Instant,
                    ArchiveCollector.TimeSignature.Time, canSave);
            }
            // в. Проверяем активен ли второй канал и читаем данные
            if (_isSecondChannelActive)
            {
                Func<Parameter, bool> predicate = p => p.BeInstant && (p.HeatInput == TraceMessages.Vkt7ChannelTwo);
                ExecuteReadParameters(predicate, SetReadElementsList(predicate), PeriodType.Instant,
                    ArchiveCollector.TimeSignature.Time, canSave);
            }

            //EmergencyEngine.CollectValuesFromInstantArchives(ArchiveCollector.Archives.Where(p => p.PeriodTypeId == (int)PeriodType.Instant).ToList());
            SetInstantArchiveValuesForAnalyze(ArchiveCollector.Archives);

            // г. Задаём, что будем читать текущие итоговые значения 
            RaiseTraceInfoPassedEvent(TraceMessages.Vkt7ReadFinalInstantArchives);
            _actionSteps.SetValueType(ValueTypes.FinalInstant);

            // д. Проверяем активен ли первый канал и читаем данные
            if (_isFirstChannelActive)
            {
                Func<Parameter, bool> predicate = p => p.BeFinalInstant && (p.HeatInput == TraceMessages.Vkt7ChannelOne);
                ExecuteReadParameters(predicate, SetReadElementsList(predicate), PeriodType.FinalInstant,
                    ArchiveCollector.TimeSignature.Time, canSave);
            }

            // e. Проверяем активен ли второй канал и читаем данные
            if (_isSecondChannelActive)
            {
                Func<Parameter, bool> predicate = p => p.BeFinalInstant && (p.HeatInput == TraceMessages.Vkt7ChannelTwo);
                ExecuteReadParameters(predicate, SetReadElementsList(predicate), PeriodType.FinalInstant,
                    ArchiveCollector.TimeSignature.Time, canSave);
            }            
        }

        private void ReadHourArchives()
        {
            if (MeasurementDevice.GiveHArcData)
            {
                // Задаём, что будем читать часовые данные
                RaiseTraceInfoPassedEvent(TraceMessages.Vkt7ReadHourArchives);
                _actionSteps.SetValueType(ValueTypes.Hourly);

                ArchiveReadCondition archiveReadCondition = _deviceFeatures.IsGetDateIntervalSupports && _deviceTime != null
                    ? ArchiveReadConditionHelper.GetHourArchiveReadCondition(_deviceTime.HourArchiveStart, DeviceTime)
                    : ArchiveReadConditionHelper.GetHourArchiveReadCondition(MeasurementDevice.StartReadArchiveDate, DeviceTime);

                ReadArchive(PeriodType.Hour, archiveReadCondition);
                ArchiveCollector.SaveArchives();
            }
        }

        private void ReadDayArchives()
        {
            if (MeasurementDevice.GiveDArcData)
            {
                // Задаём, что будем читать дневные данные
                RaiseTraceInfoPassedEvent(TraceMessages.Vkt7ReadDayArchives);
                _actionSteps.SetValueType(ValueTypes.Daily);

                ArchiveReadCondition archiveReadCondition = _deviceFeatures.IsGetDateIntervalSupports && _deviceTime != null
                    ? ArchiveReadConditionHelper.GetDayArchiveReadCondition(_deviceTime.DailyArchiveStart, DeviceTime)
                    : ArchiveReadConditionHelper.GetDayArchiveReadCondition(MeasurementDevice.StartReadArchiveDate, DeviceTime);

                ReadArchive(PeriodType.Day, archiveReadCondition);
                ArchiveCollector.SaveArchives();
            }
        }

        private void ReadFinalArchives(int reportingMonthDay)
        {
            // Задаём, что будем читать итоговые данные
            RaiseTraceInfoPassedEvent(TraceMessages.Vkt7ReadFinalArchives);
            _actionSteps.SetValueType(ValueTypes.Final);
            
            ArchiveReadCondition archiveReadCondition =
                    ArchiveReadConditionHelper.GetFinalArchiveReadCondition(DeviceTime,  DeviceSnip.ArchiveDepthMonth, reportingMonthDay);

            ReadArchive(PeriodType.Final, archiveReadCondition);
            ArchiveCollector.SaveArchives();
        }
       
        
        private void ReadArchive(PeriodType periodType, ArchiveReadCondition archiveReadCondition)
        {
            var archiveCollector = ArchiveCollector as ArchiveCollector;
            if (archiveCollector != null)
            {
                var lastPeriodArchive = GetLastArchiveByPeriod(periodType, archiveReadCondition.GetExtraLastArchivePredicate);

                DateTime startDateRead = archiveReadCondition.StartDateCalculator(lastPeriodArchive);

                if (lastPeriodArchive == null )
                {
                    if (MeasurementDevice.StartReadArchiveDate.Year > 2000 && (periodType == PeriodType.Day || periodType == PeriodType.Hour || periodType == PeriodType.Final))
                    {
                        if (startDateRead < MeasurementDevice.StartReadArchiveDate)
                        {
                            startDateRead = MeasurementDevice.StartReadArchiveDate;
                        }
                    }
                }

                DateTime endDateRead = archiveReadCondition.EndDateCalculator(DeviceTime);

                TimeSpan ts = startDateRead - endDateRead;

                // если дата начала раньше даты окончания архива
                if (archiveReadCondition.Condition(ts))
                {
                    // отбираем параметры, соответствующие каналу и периоду, в которые они могут быть получены
                    Func<Parameter, bool> filter = p => archiveReadCondition.FilterCondition(p);
                    var paramsToRead = SetReadElementsList(filter);

                    // читаем следующую дату, увеличивая счетчик на следующий период (час,день,месяц)
                    startDateRead = archiveReadCondition.NextArchiveDateIterator(startDateRead);

                    while (startDateRead <= endDateRead)
                    {   
                        // устанавливаем дату архива
                        RaiseTraceInfoPassedEvent(string.Format(TraceMessages.Vkt7SetArchiveDate, startDateRead));
                        _actionSteps.SetArchiveDate(startDateRead);

                        if (Transport.CurrentErrorCode == ErrorCode.None)
                        {
                            paramsToRead = ExecuteReadParameters(filter, paramsToRead, periodType, startDateRead, true);
                        }

                        // читаем следующую дату, увеличивая счетчик на следующий период (час,день,месяц)
                        startDateRead = archiveReadCondition.NextArchiveDateIterator(startDateRead);
                    }
                }
            }
        }

        private Dictionary<Parameter, int> SetReadElementsList(Func<Parameter, bool> filter)
        {
            var paramsToRead = new Dictionary<Parameter, int>();

            // формируем перечень параметров для чтения
            var channelInstantParams = _parameters.Keys.Where(filter).ToList();

            // если есть параметры для чтения
            if (channelInstantParams.Any())
            {
                channelInstantParams.ForEach((p) => paramsToRead.Add(p, _parameters.First(t => t.Key == p).Value));
                RaiseTraceInfoPassedEvent(TraceMessages.Vkt7SetReadElementsList);
                _actionSteps.SetReadElementsList(paramsToRead);

            }
            return paramsToRead;
        }

        private Dictionary<Parameter, int> ExecuteReadParameters(Func<Parameter, bool> filter, Dictionary<Parameter, int> paramsToRead, 
                                                                 PeriodType periodType, DateTime time, bool canSave)
        {
            // считываем данные
            RaiseTraceInfoPassedEvent(TraceMessages.Vkt7ReadData);
            _actionSteps.GetData(DataType.Archive);

            var archiveCollector = ArchiveCollector as ArchiveCollector;
            if (archiveCollector != null)
            {
                if (Transport.CurrentErrorCode == ErrorCode.MeasurementSchemaChanged)
                {
                    LogHelper.CreateLog(TraceMessages.Vkt7MeasurementSchemaChanged, ErrorType.SpecificDeviceError);
                    RaiseTraceInfoPassedEvent(TraceMessages.Vkt7MeasurementSchemaChanged);
                    _parameters = _actionSteps.GetReadParameters(archiveCollector.ParametersCollection);
                    paramsToRead = SetReadElementsList(filter);
                    ExecuteReadParameters(filter, paramsToRead, periodType, time, canSave);
                }
                else
                {
                    if (!archiveCollector.CollectParameters(paramsToRead, Transport.Buffer, periodType, time, DeviceTime, canSave))
                    {
                        throw new Vkt7SaveArchiveException(string.Format(DeviceMessages.SaveArchiveError, periodType, time));
                    }
                    else
                    {
                        var diffParamIds =
                                paramsToRead.Select(p => archiveCollector.GetDeviceParameterId(p, periodType))
                                            .Intersect(IntegratingParameters.DiffParamsIds).ToArray();
                    }
                }
            }

            return paramsToRead;
        }
    }
}

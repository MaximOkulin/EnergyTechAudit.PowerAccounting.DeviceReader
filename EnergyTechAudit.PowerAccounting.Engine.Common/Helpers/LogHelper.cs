using System;
using System.Collections.Generic;
using System.Data;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    /// <summary>
    /// Класс, обеспечивающий логирование процесса обмена информацией 
    /// с измерительным устройством
    /// </summary>
    public class LogHelper
    {
        private List<DeviceReaderErrorLog> _logs = new List<DeviceReaderErrorLog>();
        private readonly int? _measurementDeviceId;
        private readonly int? _deviceReaderId;

        /// <summary>
        /// Общий конструктор
        /// </summary>
        /// <param name="entityId">Идентификатор логируемой сущности</param>
        /// <param name="entityType">Тип логируемой сущности</param>
        public LogHelper(int entityId, LogEntityType entityType)
        {
            if (entityType == LogEntityType.MeasurementDevice)
            {
                _measurementDeviceId = entityId;
            }
            else if (entityType == LogEntityType.DeviceReader)
            {
                _deviceReaderId = entityId;
            }
        }

        /// <summary>
        /// Создает объект "Лог" и добавляет его в список,
        /// ассоциированный с логом измерительного устройства
        /// </summary>
        /// <param name="text">Текст лога</param>
        /// <param name="errorType">Тип ошибки</param>
        /// <param name="ex">Исключение</param>
        public void CreateLog(string text, ErrorType errorType = ErrorType.Unknown, Exception ex = null)
        {
            var log = new DeviceReaderErrorLog
            {
                Time = DateTime.Now,
                Text = text,
                ErrorTypeId = (int) errorType,
                MeasurementDeviceId = _measurementDeviceId,
                DeviceReaderId = _deviceReaderId
            };

            if (ex != null)
            {
               var collectedLog = CollectExceptionInfo(ex);

                log.Exception = collectedLog.Exception;
                log.Message = collectedLog.Message;
                log.StackTrace = collectedLog.StackTrace;
            }
            
            _logs.Add(log);

            if (_logs.Count > 10)
            {
                SaveLogs();
            }
        }

        /// <summary>
        /// Собирает всю информацию из внутренних исключений и возвращает запись лога
        /// </summary>
        /// <param name="exception">Возникшее исключение</param>
        private DeviceReaderErrorLog CollectExceptionInfo(Exception exception)
        {
            var rootException = exception;
            string exceptions = string.Empty;
            string messages = string.Empty;
            string stackTrace = string.Empty;

            while (rootException != null)
            {
                exceptions = string.Format("{0}{1}{2}", exceptions, rootException.GetType().Name, Environment.NewLine);
                messages = string.Format("{0}{1}{2}", messages, rootException.Message, Environment.NewLine);
                stackTrace = string.Format("{0}{1}{2}", stackTrace, rootException.StackTrace, Environment.NewLine);
                rootException = rootException.InnerException;
            }

            return new DeviceReaderErrorLog()
            {
                Exception = exceptions,
                Message = messages,
                StackTrace = stackTrace
            };
        }

        /// <summary>
        /// Сохраняет логи в базу данных
        /// </summary>
        public void SaveLogs()
        {
            using (var context = new LightDatabaseContext())
            {

                if (_logs.Count > 0)
                {
                    context.Set<DeviceReaderErrorLog>().AddRange(_logs);
                }

                using (var transaction = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }

                context.Set<DeviceReaderErrorLog>().Local.Clear();
                _logs = new List<DeviceReaderErrorLog>();
            }
        }
    }
}

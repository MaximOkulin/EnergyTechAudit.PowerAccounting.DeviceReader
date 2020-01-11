using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Csd;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic
{
    public partial class Device
    {
        /// <summary>
        /// Конструктор (упрощенный) для теста связи с прибором
        /// </summary>
        /// <param name="device">Объект прибора</param>
        public Device(MeasurementDevice device)
        {
            MeasurementDevice = device;
            DeviceModel = (DeviceModel)MeasurementDevice.DeviceId;
            PortType = (PortType)MeasurementDevice.PortTypeId;
            LogHelper = new LogHelper(device.Id, LogEntityType.MeasurementDevice);

            Context = new LightDatabaseContext();

            Context.Configuration.AutoDetectChangesEnabled = true;

            Context.Set<MeasurementDevice>().Attach(MeasurementDevice);

            var mD = Context.Entry(MeasurementDevice);
            mD.Reference(p => p.AccessPoint).Load();
            mD.Reference(p => p.ComPort).Load();
            mD.Reference(p => p.Baud).Load();
            mD.Reference(p => p.DataBit).Load();
            mD.Reference(p => p.StopBit).Load();
            mD.Reference(p => p.Parity).Load();
            mD.Reference(p => p.Device).Load();
            Context.Set<Channel>().Where(p => p.MeasurementDeviceId == device.Id).Load();

            if (MeasurementDevice.AccessPoint != null)
            {
                InitMeasurementDeviceTypeConnection(MeasurementDevice.AccessPoint.DeviceReaderId);
                ApI = new AccessPointInfo();
                ApI.AccessPoint = MeasurementDevice.AccessPoint;
            }

            var aP = Context.Entry(MeasurementDevice.AccessPoint);
            aP.Reference(p => p.TransportServerModel).Load();

            if (MeasurementDevice.AccessPoint != null)
            {
                _configureActionSteps = new ConfigureActionSteps();
                _configureActionSteps.TraceInfoPassed += _configureActionSteps_TraceInfoPassed;
            }

            LocalArchives = new List<ValueInfo>();

            // подгружаем элементы расписания для опроса прибора по заданному интервалу
            var measurementDeviceLinkScheduleItems = Context.Set<MeasurementDeviceLinkScheduleItem>().Where(p => p.MeasurementDeviceId == device.Id).ToList();

            if (measurementDeviceLinkScheduleItems.Count > 0)
            {
                var scheduleItemIds = measurementDeviceLinkScheduleItems.Select(p => p.ScheduleItemId).ToList();
                Context.Set<LightDataAccess.Dictionaries.ScheduleType>().Load();
                _scheduleItems = Context.Set<ScheduleItem>().Where(p => scheduleItemIds.Contains(p.Id)).ToList();
            }
        }

        public void RunCustomAction()
        {
            ExecuteCustomAction();
        }

        /// <summary>
        /// Проверяет качество связи с прибором
        /// </summary>
        /// <returns>Описание результата подключения</returns>
        public Dictionary<string, string> CheckConnectionQuality()
        {
            var result = new Dictionary<string, string>();

            if (MeasurementDevice.AccessPoint.TransportTypeId == (int) TransportType.Csd)
            {
                result.Add(DeviceMessages.CsdNotSupportedConnectionQualityKey,
                    DeviceMessages.CsdNotSupportedConnectionQuality);
            }
            else
            {
                Func<Dictionary<string, string>> func = GetConnectionExistence;
                result = ExecuteCustomAction(func);
            }

            return result;
        }

        public Dictionary<string, string> ReadCurrents()
        {
            var result = new Dictionary<string, string>();

            if (MeasurementDevice.AccessPoint.TransportTypeId == (int)TransportType.Csd)
            {
                result.Add(CommandsKeys.CsdNotSupportedReadCurrentsKey,
                    DeviceMessages.CsdNotSupportedReadCurrents);
            }
            else
            {
                Func<Dictionary<string, string>> func = GetCurrents;
                result = ExecuteCustomAction(func);
            }

            return result;
        }

        
        public Dictionary<string, string> ExecuteExtension(string commandName)
        {
            var result = new Dictionary<string, string>();
            if (MeasurementDevice != null)
            {
                if (MeasurementDevice.AccessPoint != null)
                {
                    ConfigureTransportServer();

                    if (ConfigurationStatus == TransportServerConfigurationStatus.SuccessfullyConfigured)
                    {
                        if (Transport.InitConnection(_preparedTcpClient))
                        {
                            try
                            {
                                result = ExecuteExtensionCommand(commandName);
                            }
                            catch (Exception ex)
                            {
                                if (Transport.CurrentErrorCode == ErrorCode.NullBytesPackage)
                                {
                                    result.Add(DeviceMessages.NullBytesPackageKey, DeviceMessages.NullBytesPackage);
                                }
                                result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.FailConnectionHtml);
                            }
                        }
                        else
                        {
                            result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.FailConnectionHtml);
                        }
                    }
                    else
                    {
                        result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.AccessPointWrongConfigurationHtml);
                    }
                }
                else
                {
                    result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.MissingAccessPointHtml);
                }
            }
            return result;
        }


        /// <summary>
        /// Выполняет произвольное действие
        /// </summary>
        /// <param name="func">Произвольное действие, которое необходимо выполнить после подключения к прибору</param>
        public Dictionary<string, string> ExecuteCustomAction(Func<Dictionary<string, string>> func)
        {
            var result = new Dictionary<string, string>();

            // проверяем есть ли заданное расписание опроса и можно ли опрашивать в текущий момент
            if (_scheduleItems != null && _scheduleItems.Count > 0)
            {
                var canExecute = ScheduleItem.CheckSchelude(_scheduleItems);

                if (!canExecute)
                {
                    result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.ScheduleMessage);
                }
                return result;
            }

            if (MeasurementDevice != null)
            {
                if (MeasurementDevice.AccessPoint != null)
                {
                    ConfigureTransportServer();

                    if (ConfigurationStatus == TransportServerConfigurationStatus.SuccessfullyConfigured)
                    {
                        if (Transport.InitConnection(_preparedTcpClient))
                        {
                            try
                            {
                                // при опросе через CSD
                                if (Transport.TransportType == TransportTypes.CSD)
                                {
                                    // предварительно кладём трубку модема
                                    HangUp();

                                    if (Call() == CallResult.Ok)
                                    {
                                        // переходим в прозрачный режим
                                        Transport.IsCsdCommandMode = false;
                                        result = func();
                                        // переходим в командный режим
                                        Transport.IsCsdCommandMode = true;
                                        HangUp();
                                    }
                                    else
                                    {
                                        result.Add(DeviceMessages.WrongMakeCallKey, string.Format(DeviceMessages.WrongMakeCall, MeasurementDevice.AccessPoint.NetPhone));
                                    }
                                }
                                // при опросе через другие типы связи
                                else
                                {
                                    result = func();
                                }
                                
                            }
                            catch(Exception ex)
                            {
                                if (Transport.CurrentErrorCode == ErrorCode.NullBytesPackage)
                                {
                                    result.Add(DeviceMessages.NullBytesPackageKey, DeviceMessages.NullBytesPackage);
                                }
                                result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.FailConnectionHtml);
                            }
                        }
                        else
                        {
                            result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.FailConnectionHtml);
                        }
                    }
                    else
                    {
                        result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.AccessPointWrongConfigurationHtml);
                    }
                }
                else
                {
                    result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.MissingAccessPointHtml);
                }
            }
            return result;
        }
    }
}

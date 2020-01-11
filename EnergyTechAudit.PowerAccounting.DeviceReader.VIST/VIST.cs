using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types.Precisions;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Linq;
using Ex = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions.BaseExtensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.CustomFormatters;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using System.IO;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST
{
    [Device("VIST")]
    public partial class VIST : Device
    {
        private ActionSteps _actionSteps;
        private ReportingTime _reportingTime;
        private int _systemsCount;
        private List<ArchiveInfo> _archiveInfo;
        private List<FinalInstantParamsPrecisions> _precisions;

        protected override void InitTransport()
        {
            var autoEvent = new ManualResetEvent(false);
            Transport = new VISTConnection(MeasurementDevice, ApI, autoEvent, LogHelper);
            _actionSteps = new ActionSteps(Transport, autoEvent, MeasurementDevice.NetworkAddress);
            _archiveInfo = new List<ArchiveInfo>();
            _precisions = new List<FinalInstantParamsPrecisions>();

            if (DynamicParameterHelper != null)
            {
                DynamicParameterHelper.CheckExistDynamicDataValues();

                DynamicParameterHelper.InitDynamicDataValues(new[]
                {
                    (int)DynamicParameter.DeviceDeviceSettingUpdateDate,
                    (int)DynamicParameter.DeviceLastSumArchiveTimeSystem1,
                    (int)DynamicParameter.DeviceLastSumArchiveTimeSystem2,
                    (int)DynamicParameter.DeviceLastSumArchiveTimeSystem3
                });
            }
        }

        public VIST(int deviceId, DeviceReaderCache deviceReaderCache = null): base(deviceId, deviceReaderCache)
        {

        }

        public VIST(int deviceId, DeviceReaderCache deviceReaderCache, TcpClient preparedTcpClient)
            : base(deviceId, deviceReaderCache, preparedTcpClient)
        {

        }

        public VIST(MeasurementDevice device) : base(device)
        {

        }

        public VIST(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings):
            base(device, preparedTcpClient, serverCommunicatorSettings)
        {

        }

        public VIST(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings, int deviceReaderId)
            : base(device, preparedTcpClient, serverCommunicatorSettings, deviceReaderId)
        {

        }

        protected override Dictionary<string, string> GetConnectionExistence()
        {
            var result = new Dictionary<string, string>();

            // читаем заводской номер
            _actionSteps.GetFactoryNumber();
            var factoryNumber = Parser.ParseFactoryNumber(Transport.Buffer);

            result.Add(DeviceMessages.RealFactoryNumberKey, string.Format(DeviceMessages.RealFactoryNumber, factoryNumber));

            if (factoryNumber == MeasurementDevice.FactoryNumber)
            {
                _actionSteps.GetDeviceTime();
                DeviceTime = Parser.ParseDeviceTime(Transport.Buffer);

                result.Add(CommandsKeys.DeviceTimeDifferenceKey, string.Format(new DeviceTimeDifferenceFormat(), Resources.Common.DeviceTimeDifferenceStringFormat, DeviceTime.CalculateDeviceTimeDifference()));

                result.Add(CommandsKeys.DeviceTimeKey, string.Format(DeviceMessages.DeviceTime, DeviceTime));

                result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.SuccessConnectionHtml);
            }
            else
            {
                result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.SuccessConnectionWrongFactoryNumberHtml);
            }

            return result;
        }

        protected override Dictionary<string, string> GetCurrents()
        {
            var result = new Dictionary<string, string>();

            // получаем заводской номер прибора
            _actionSteps.GetFactoryNumber();

            var factoryNumber = Parser.ParseFactoryNumber(Transport.Buffer);

            if (!CheckFactoryNumber(factoryNumber))
            {
                result.Add(CommandsKeys.WrongFactoryNumberKey, string.Format(DeviceMessages.WrongFactoryAttentionStringFormat, MeasurementDevice.FactoryNumber, factoryNumber));
            }

            // текущее время прибора
            _actionSteps.GetDeviceTime();
            DeviceTime = Parser.ParseDeviceTime(Transport.Buffer);

            ArchiveCollector = new Common.Base.ArchiveCollectorBase(DeviceTime, MeasurementDevice);

            // количество теплосистем в приборе
            _actionSteps.GetSystemsCount();
            _systemsCount = Transport.Buffer[4];

            ReadInstant();

            ArchiveCollector.CreateArchives(LocalArchives);

            if (!ArchiveCollector.SaveArchives())
            {
                result.Add(CommandsKeys.CurrentArchivesSaveErrorKey, DeviceMessages.FinalInstantArchivesSaveErrorHtml);
            }
            else
            {
                SetInstantArchiveValuesForAnalyze(LocalArchives);
                UpdateLastTimeSignatureId();
                result.Add(CommandsKeys.ReadCurrentsSuccessfullyKey, DeviceMessages.ReadCurrentsSuccessfullyHtml);
            }

            return result;
        }

        protected override void Polling()
        {
            // получаем заводской номер прибора
            _actionSteps.GetFactoryNumber();

            var factoryNumber = Parser.ParseFactoryNumber(Transport.Buffer);

            if (CheckFactoryNumber(factoryNumber))
            {
                if (MeasurementDevice.Firmware == null)
                {
                    // получаем версию программного обеспечения
                    _actionSteps.GetFirmware();

                    MeasurementDevice.Firmware = Parser.ParseFirmware(Transport.Buffer);
                }

                // чтение отчетного времени
                _actionSteps.GetReportingTime();
                _reportingTime = Parser.ParseReportingTime(Transport.Buffer);

                // текущее время прибора
                _actionSteps.GetDeviceTime();
                DeviceTime = Parser.ParseDeviceTime(Transport.Buffer);

                ArchiveCollector = new Common.Base.ArchiveCollectorBase(DeviceTime, MeasurementDevice);

                // количество теплосистем в приборе
                _actionSteps.GetSystemsCount();
                _systemsCount = Transport.Buffer[4];

                ReadInstant();

                ArchiveCollector.CreateArchives(LocalArchives);

                if (!ArchiveCollector.SaveArchives())
                {
                    throw new Exception(DeviceMessages.FinalInstantArchivesSaveError);
                }

                SetInstantArchiveValuesForAnalyze(LocalArchives);
                UpdateLastTimeSignatureId();

                ReadArchives();

                CheckDeviceSettings();
            }
        }

        private void ReadInstant()
        {
            LocalArchives.Clear();

            // текущее время прибора
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                DeviceParameterId = (int)DeviceParameter.VIST_DeviceTime,
                Value = (decimal)DeviceTime.ToOADate()
            }));

            for (int systemNumber = 1; systemNumber <= _systemsCount; systemNumber++)
            {
                // чтение набора измеряемых текущих параметров теплосистемы
                _actionSteps.GetInstantParamsSet(systemNumber);
                var instantParamsSet = Parser.ParseInstantParamsSet(Transport.Buffer);

                // чтение точности по расходу и тепловой мощности теплосистемы
                _actionSteps.GetInstantParamsPrecisions(systemNumber);
                var instantParamsPrecisions = Parser.ParseInstantParamsPrecisions(Transport.Buffer);

                // ТЕМПЕРАТУРЫ
                // если хотя бы одна температура измеряется
                if (EnumHelper.HasInstantTemperatures(instantParamsSet))
                {
                    _actionSteps.GetInstantTemperatures(systemNumber);

                    if (instantParamsSet.HasFlag(InstantParamsSet.Temperature1))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.TemperatureSystemInstant, 1, systemNumber)),
                            Value = Parser.ParseInstantTemperature(Transport.Buffer, 1)
                        }));
                    }
                    if (instantParamsSet.HasFlag(InstantParamsSet.Temperature2))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.TemperatureSystemInstant, 2, systemNumber)),
                            Value = Parser.ParseInstantTemperature(Transport.Buffer, 2)
                        }));
                    }
                    if (instantParamsSet.HasFlag(InstantParamsSet.Temperature3))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.TemperatureSystemInstant, 3, systemNumber)),
                            Value = Parser.ParseInstantTemperature(Transport.Buffer, 3)
                        }));
                    }
                    if (instantParamsSet.HasFlag(InstantParamsSet.Temperature4))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.TemperatureSystemInstant, 4, systemNumber)),
                            Value = Parser.ParseInstantTemperature(Transport.Buffer, 4)
                        }));
                    }
                }
                // ОБЪЕМНЫЕ РАСХОДЫ
                // если хотя бы один объемный расход измеряется
                if (EnumHelper.HasInstantVolumeFlows(instantParamsSet))
                {
                    _actionSteps.GetInstantVolumeFlows(systemNumber);

                    if (instantParamsSet.HasFlag(InstantParamsSet.VolumeFlow1))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.VolumeFlowSystemInstant, 1, systemNumber)),
                            Value = Parser.ParseInstantFlows(Transport.Buffer, 1, instantParamsPrecisions.Channel1)
                        }));
                    }
                    if (instantParamsSet.HasFlag(InstantParamsSet.VolumeFlow2))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.VolumeFlowSystemInstant, 2, systemNumber)),
                            Value = Parser.ParseInstantFlows(Transport.Buffer, 2, instantParamsPrecisions.Channel2)
                        }));
                    }
                    if (instantParamsSet.HasFlag(InstantParamsSet.VolumeFlow3))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.VolumeFlowSystemInstant, 3, systemNumber)),
                            Value = Parser.ParseInstantFlows(Transport.Buffer, 3, instantParamsPrecisions.Channel3)
                        }));
                    }
                }
                // МАССОВЫЕ РАСХОДЫ
                // если хотя бы один объемный расход измеряется
                if (EnumHelper.HasInstantMassFlows(instantParamsSet))
                {
                    _actionSteps.GetInstantMassFlows(systemNumber);

                    if (instantParamsSet.HasFlag(InstantParamsSet.MassFlow1))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.MassFlowSystemInstant, 1, systemNumber)),
                            Value = Parser.ParseInstantFlows(Transport.Buffer, 1, instantParamsPrecisions.Channel1)
                        }));
                    }
                    if (instantParamsSet.HasFlag(InstantParamsSet.MassFlow2))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.MassFlowSystemInstant, 2, systemNumber)),
                            Value = Parser.ParseInstantFlows(Transport.Buffer, 2, instantParamsPrecisions.Channel2)
                        }));
                    }
                    if (instantParamsSet.HasFlag(InstantParamsSet.MassFlow3))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.MassFlowSystemInstant, 3, systemNumber)),
                            Value = Parser.ParseInstantFlows(Transport.Buffer, 3, instantParamsPrecisions.Channel3)
                        }));
                    }
                }
                // ДАВЛЕНИЯ
                // если хотя бы один объемный расход измеряется
                if (EnumHelper.HasInstantPressures(instantParamsSet))
                {
                    _actionSteps.GetInstantPressures(systemNumber);

                    if (instantParamsSet.HasFlag(InstantParamsSet.Pressure1))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.PressureSystemInstant, 1, systemNumber)),
                            Value = Parser.ParseInstantPressure(Transport.Buffer, 1)
                        }));
                    }
                    if (instantParamsSet.HasFlag(InstantParamsSet.Pressure2))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.PressureSystemInstant, 2, systemNumber)),
                            Value = Parser.ParseInstantPressure(Transport.Buffer, 2)
                        }));
                    }
                    if (instantParamsSet.HasFlag(InstantParamsSet.Pressure3))
                    {
                        LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.PressureSystemInstant, 3, systemNumber)),
                            Value = Parser.ParseInstantPressure(Transport.Buffer, 3)
                        }));
                    }
                }
                // ТЕПЛОВАЯ МОЩНОСТЬ
                if (EnumHelper.HasInstantThermalPower(instantParamsSet))
                {
                    _actionSteps.GetInstantThermalPowers(systemNumber);

                    LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                    {
                        DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.ThermalPowerSystemInstant, systemNumber)),
                        Value = Parser.ParseInstantFlows(Transport.Buffer, 1, instantParamsPrecisions.ThermalPower)
                    }));
                }

                // ТЕКУЩИЕ ИТОГОВЫЕ

                // чтение набора измеряемых текущих параметров теплосистемы
                _actionSteps.GetFinalInstantParamsSet(systemNumber);
                var finalInstantParamsSet = Parser.ParseFinalInstantParamsSet(Transport.Buffer);

                // чтение точности по объему и тепловой энергии теплосистемы
                _actionSteps.GetFinalInstantParamsPrecisions(systemNumber);
                var finalInstantParamsPrecisions = Parser.ParseFinalInstantParamsPrecisions(Transport.Buffer);

                var finalInstantValuesForHour = new FinalInstantValuesForHour();
                // ОБЪЕМЫ ЗА ЧАС
                if (EnumHelper.HasFinalInstantVolumes(finalInstantParamsSet))
                {
                    _actionSteps.GetVolumesForHour(systemNumber);

                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Volume1))
                    {
                        finalInstantValuesForHour.Volume1 = Parser.ParseInstantFlows(Transport.Buffer, 1, finalInstantParamsPrecisions.Channel1, 3600);
                    }
                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Volume2))
                    {
                        finalInstantValuesForHour.Volume2 = Parser.ParseInstantFlows(Transport.Buffer, 2, finalInstantParamsPrecisions.Channel2, 3600);
                    }
                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Volume3))
                    {
                        finalInstantValuesForHour.Volume3 = Parser.ParseInstantFlows(Transport.Buffer, 3, finalInstantParamsPrecisions.Channel3, 3600);
                    }
                }
                // МАССЫ ЗА ЧАС
                if (EnumHelper.HasFinalInstantMasses(finalInstantParamsSet))
                {
                    _actionSteps.GetMassesForHour(systemNumber);

                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Mass1))
                    {
                        finalInstantValuesForHour.Mass1 = Parser.ParseInstantFlows(Transport.Buffer, 1, finalInstantParamsPrecisions.Channel1, 3600);
                    }
                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Mass2))
                    {
                        finalInstantValuesForHour.Mass2 = Parser.ParseInstantFlows(Transport.Buffer, 2, finalInstantParamsPrecisions.Channel2, 3600);
                    }
                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Mass3))
                    {
                        finalInstantValuesForHour.Mass3 = Parser.ParseInstantFlows(Transport.Buffer, 3, finalInstantParamsPrecisions.Channel3, 3600);
                    }
                }
                // ТЕПЛОВАЯ ЭНЕРГИЯ ЗА ЧАС
                if (EnumHelper.HasFinalInstantHeat(finalInstantParamsSet))
                {
                    _actionSteps.GetHeatForHour(systemNumber);

                    finalInstantValuesForHour.Heat = Parser.ParseInstantFlows(Transport.Buffer, 1, finalInstantParamsPrecisions.Heat, 1200);
                }
                // ВРЕМЯ НАРАБОТКИ ЗА ЧАС
                if (EnumHelper.HasFinalInstantTimeNormal(finalInstantParamsSet))
                {
                    _actionSteps.GetTimeNormalForHour(systemNumber);

                    finalInstantValuesForHour.TimeNormal = Parser.ParseTimeNormalForHour(Transport.Buffer);
                }

                // ОСНОВАЯ ЧАСТЬ ТЕКУЩИХ ИТОГОВЫХ
                // Читаем структуру заголовка архивного файла и текущие итоговые
                _actionSteps.GetArchiveStructureAndFinalInstantSystem(systemNumber);
                var precisionForWhole = Parser.ParseFinalInstantWholePartParamsPrecisions(Transport.Buffer);
                // ОБЪЕМЫ - ОСНОВНАЯ ЧАСТЬ
                if (EnumHelper.HasFinalInstantVolumes(finalInstantParamsSet))
                {
                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Volume1))
                    {
                        var wholePart = Parser.ParseWholePartVolumeAndMass(Transport.Buffer, 27, precisionForWhole.Channel1);
                        LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.VolumeSystemFinalInstant, 1, systemNumber)),
                            Value = Math.Round(wholePart + finalInstantValuesForHour.Volume1, 2)
                        }, false));
                        // обновляем значение, как сумму для передачи в информацию об архиве
                        finalInstantValuesForHour.Volume1 = Math.Round(wholePart, 2);
                    }
                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Volume2))
                    {
                        var wholePart = Parser.ParseWholePartVolumeAndMass(Transport.Buffer, 31, precisionForWhole.Channel2);
                        LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.VolumeSystemFinalInstant, 2, systemNumber)),
                            Value = Math.Round(wholePart + finalInstantValuesForHour.Volume2, 2)
                        }, false));
                        // обновляем значение, как сумму для передачи в информацию об архиве
                        finalInstantValuesForHour.Volume2 = Math.Round(wholePart, 2);
                    }
                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Volume3))
                    {
                        var wholePart = Parser.ParseWholePartVolumeAndMass(Transport.Buffer, 35, precisionForWhole.Channel3);
                        LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.VolumeSystemFinalInstant, 3, systemNumber)),
                            Value = Math.Round(wholePart + finalInstantValuesForHour.Volume3, 2)
                        }, false));
                        // обновляем значение, как сумму для передачи в информацию об архиве
                        finalInstantValuesForHour.Volume3 = Math.Round(wholePart, 2);
                    }
                }

                // МАССЫ - ОСНОВНАЯ ЧАСТЬ
                if (EnumHelper.HasFinalInstantMasses(finalInstantParamsSet))
                {
                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Mass1))
                    {
                        var wholePart = Parser.ParseWholePartVolumeAndMass(Transport.Buffer, 39, precisionForWhole.Channel1);
                        LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.MassSystemFinalInstant, 1, systemNumber)),
                            Value = Math.Round(wholePart + finalInstantValuesForHour.Mass1, 2)
                        }, false));
                        // обновляем значение, как сумму для передачи в информацию об архиве
                        finalInstantValuesForHour.Mass1 = Math.Round(wholePart, 2);
                    }
                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Mass2))
                    {
                        var wholePart = Parser.ParseWholePartVolumeAndMass(Transport.Buffer, 43, precisionForWhole.Channel2);
                        LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.MassSystemFinalInstant, 2, systemNumber)),
                            Value = Math.Round(wholePart + finalInstantValuesForHour.Mass2, 2)
                        }, false));
                        // обновляем значение, как сумму для передачи в информацию об архиве
                        finalInstantValuesForHour.Mass2 = Math.Round(wholePart, 2);
                    }
                    if (finalInstantParamsSet.HasFlag(FinalInstantParamsSet.Mass3))
                    {
                        var wholePart = Parser.ParseWholePartVolumeAndMass(Transport.Buffer, 47, precisionForWhole.Channel3);
                        LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.MassSystemFinalInstant, 3, systemNumber)),
                            Value = Math.Round(wholePart + finalInstantValuesForHour.Mass3, 2)
                        }, false));
                        // обновляем значение, как сумму для передачи в информацию об архиве
                        finalInstantValuesForHour.Mass3 = Math.Round(wholePart, 2);
                    }
                }

                // ТЕПЛОВАЯ ЭНЕРГИЯ - ОСНОВНАЯ ЧАСТЬ
                if (EnumHelper.HasFinalInstantHeat(finalInstantParamsSet))
                {
                    var b = Transport.Buffer;
                    var wholePart = (decimal)(BitConverter.ToInt64(new byte[] { b[62], b[61], b[60], b[59], b[58], b[57], b[56], b[55] }, 0) / Math.Pow(10, precisionForWhole.Heat));
                    LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
                    {
                        DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.HeatSystemFinalInstant, systemNumber)),
                        Value = Math.Round(wholePart + finalInstantValuesForHour.Heat, 2)
                    }, false));
                    // обновляем значение, как сумму для передачи в информацию об архиве
                    finalInstantValuesForHour.Heat = Math.Round(wholePart, 2);
                }
                // ВРЕМЯ НАРАБОТКИ - ОСНОВНАЯ ЧАСТЬ
                if (EnumHelper.HasFinalInstantTimeNormal(finalInstantParamsSet))
                {
                    var b = Transport.Buffer;
                    var wholePart = (decimal)(BitConverter.ToUInt32(new byte[] { b[54], b[53], b[52], b[51] }, 0) / 100);

                    LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
                    {
                        DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.TimeNormalSystemFinalInstant, systemNumber)),
                        Value = Math.Round(wholePart + finalInstantValuesForHour.TimeNormal, 2)
                    }, false));
                    // обновляем значение, как сумму для передачи в информацию об архиве
                    finalInstantValuesForHour.TimeNormal = Math.Round(wholePart, 2);
                }
                
                // параллельно заполняем информацию о состоянии архива теплосистемы
                var archiveInfo = new ArchiveInfo();
                archiveInfo.FinalInstantValues = finalInstantValuesForHour;
                archiveInfo.ArchiveHeatSystemParams = Parser.ParseArchiveHeatSystemParams(Transport.Buffer);
                archiveInfo.SystemNumber = systemNumber;
                archiveInfo.ArchiveRecordCount = BitConverter.ToUInt16(new byte[] { Transport.Buffer[16], Transport.Buffer[15] }, 0);
                archiveInfo.NextRecordIndex = BitConverter.ToUInt16(new byte[] { Transport.Buffer[18], Transport.Buffer[17] }, 0);
                archiveInfo.MaxArchiveRecord = BitConverter.ToUInt16(new byte[] { Transport.Buffer[20], Transport.Buffer[19] }, 0);
                archiveInfo.RefreshDate = new DateTime(2000 + Transport.Buffer[26], Transport.Buffer[25], Transport.Buffer[24], Transport.Buffer[21], Transport.Buffer[22], Transport.Buffer[23]);
                archiveInfo.Precisions = precisionForWhole;
                _archiveInfo.Add(archiveInfo);
                
                try
                {
                    var dt = archiveInfo.RefreshDate;
                    File.AppendAllText(string.Format(@"D:\Dump\Vist_{0}.txt", MeasurementDevice.FactoryNumber),
                                       string.Format("{0}.{1}.{2} {3}:{4}:{5} - {6}{7}", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second, archiveInfo.NextRecordIndex, Environment.NewLine));
                }
                catch
                {

                }

                precisionForWhole.SystemNumber = systemNumber;
                _precisions.Add(precisionForWhole);
            }           
        }

        
        

        protected override void ReadDeviceSettings()
        {
            // Система 1
            _actionSteps.GetSettingsHeatSys1();
            ParseDeviceSettings(1);
            // Система 2
            _actionSteps.GetSettingsHeatSys2();
            ParseDeviceSettings(2);
            // Система 3
            _actionSteps.GetSettingsHeatSys3();
            ParseDeviceSettings(3);

            // количество систем в приборе
            _actionSteps.GetSystemsCount();
            var systemCounts = Transport.Buffer[4];
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.VIST_SystemsCount, Convert.ToString(systemCounts));

            UpdatePrecisions();
        }

        private void UpdatePrecisions()
        {
            if (_precisions != null)
            {
                for (var systemNumber = 1; systemNumber <= _systemsCount; systemNumber++)
                {
                    var precision = _precisions.FirstOrDefault(p => p.SystemNumber == systemNumber);
                    if (precision != null)
                    {
                        // канал 1
                        var channel1PropertyInfo = typeof(FinalInstantParamsPrecisions).GetProperty(Resources.Common.Channel1);
                        var channel1Value = Convert.ToString(channel1PropertyInfo.GetValue(precision));
                        UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.VISTPrecisionChannel1, systemNumber)), channel1Value);
                        // канал 2
                        var channel2PropertyInfo = typeof(FinalInstantParamsPrecisions).GetProperty(Resources.Common.Channel2);
                        var channel2Value = Convert.ToString(channel2PropertyInfo.GetValue(precision));
                        UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.VISTPrecisionChannel2, systemNumber)), channel2Value);
                        // канал3
                        var channel3PropertyInfo = typeof(FinalInstantParamsPrecisions).GetProperty(Resources.Common.Channel3);
                        var channel3Value = Convert.ToString(channel3PropertyInfo.GetValue(precision));
                        UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.VISTPrecisionChannel3, systemNumber)), channel3Value);
                        // тепло
                        var heatPropertyInfo = typeof(FinalInstantParamsPrecisions).GetProperty(Resources.Common.HeatPhysicalParameter);
                        var heatValue = Convert.ToString(heatPropertyInfo.GetValue(precision));
                        UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.VISTPrecisionHeat, systemNumber)), heatValue);
                    }                   
                }
            }
        }

        /// <summary>
        /// Парсит измеряемые параметры теплосистем (т/с) прибора
        /// </summary>
        /// <param name="heatSysNumber">Номер системы</param>
        private void ParseDeviceSettings(int heatSysNumber)
        {
            var buf = Transport.Buffer;
            // t1
            var t1 =  (decimal)BitConverter.ToUInt16(new byte[] { buf[5], buf[4] }, 0) / 100;
            UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.TemperatureSystemSetPoint, 1, heatSysNumber)), string.Format(StringFormat.Celsius, t1));
            // t2
            var t2 = (decimal)BitConverter.ToUInt16(new byte[] { buf[7], buf[6] }, 0) / 100;
            UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.TemperatureSystemSetPoint, 2, heatSysNumber)), string.Format(StringFormat.Celsius, t2));
            // t3
            var t3 = (decimal)BitConverter.ToUInt16(new byte[] { buf[9], buf[8] }, 0) / 100;
            UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.TemperatureSystemSetPoint, 3, heatSysNumber)), string.Format(StringFormat.Celsius, t3));

            // P1
            var p1 = (decimal)BitConverter.ToUInt16(new byte[] { buf[11], buf[10] }, 0) / 10;
            UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.PressureSystemSetPoint, 1, heatSysNumber)), string.Format(StringFormat.Atmosphere, p1));
            // P2
            var p2 = (decimal)BitConverter.ToUInt16(new byte[] { buf[13], buf[12] }, 0) / 10;
            UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.PressureSystemSetPoint, 2, heatSysNumber)), string.Format(StringFormat.Atmosphere, p2));
            // P3
            var p3 = (decimal)BitConverter.ToUInt16(new byte[] { buf[15], buf[14] }, 0) / 10;
            UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.PressureSystemSetPoint, 3, heatSysNumber)), string.Format(StringFormat.Atmosphere, p3));

            // D1
            var d1 = (decimal)BitConverter.ToUInt16(new byte[] { buf[17], buf[16] }, 0);
            UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.DiametrSystemSetPoint, 1, heatSysNumber)), string.Format(StringFormat.Millimeter, d1));
            // D2
            var d2 = (decimal)BitConverter.ToUInt16(new byte[] { buf[19], buf[18] }, 0);
            UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.DiametrSystemSetPoint, 2, heatSysNumber)), string.Format(StringFormat.Millimeter, d2));
            // D3
            var d3 = (decimal)BitConverter.ToUInt16(new byte[] { buf[21], buf[20] }, 0);
            UpdateDeviceTechnicalParam(TechParams, Ex.GetDeviceParameterIdByName(string.Format(VistResources.DiametrSystemSetPoint, 3, heatSysNumber)), string.Format(StringFormat.Millimeter, d3));
        }
    }
}

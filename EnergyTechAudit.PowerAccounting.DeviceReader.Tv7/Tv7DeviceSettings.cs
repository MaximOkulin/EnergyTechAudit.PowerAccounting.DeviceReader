using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7
{
    public partial class Tv7
    {
        protected override void ReadDeviceSettings()
        {
            // активная БД
            _actionSteps.GetActiveDatabase();
            byte[] buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
            int activeDatabase = BitConverter.ToUInt16(new byte[] { buffer[4], buffer[3] }, 0);
            var activeDatabaseStr = activeDatabase == 0 ? Tv7Resources.Db1Active : activeDatabase == 2 ? Tv7Resources.Db2Active : string.Empty;
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ActiveDatabase, activeDatabaseStr);

            bool isFirmwareLess2 = new Firmware(1, 9).IsSupportFeature(Firmware);
            bool isFirmwareGreater2 = Firmware.IsSupportFeature(new Firmware(2, 0));

            if (_isNewFirmware) { _actionSteps.GetSystemSettingsNewFirmware(); } else { _actionSteps.GetSystemSettings(); }
            buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            // версия ПО
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_Firmware, MeasurementDevice.Firmware);
            // Версия ПО >=2.20
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_IsNewFirmware2_20, _isNewFirmware ? DeviceMessages.Yes : DeviceMessages.No);
            // час отчета
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ReportHour, Convert.ToString(buffer[4]));
            // день отчета
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ReportDay, Convert.ToString(buffer[3]));
            // БД1 с (день)
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_Database1DayFrom, Convert.ToString(buffer[6]));
            // БД1 с (месяц)
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_Database1MonthFrom, Convert.ToString(buffer[5]));
            // БД1 с (час)
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_Database1HourFrom, Convert.ToString(buffer[7]));
            // БД2 с (день)
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_Database2DayFrom, Convert.ToString(buffer[10]));
            // БД2 с (месяц)
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_Database2MonthFrom, Convert.ToString(buffer[9]));
            // БД2 с (час)
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_Database2HourFrom, Convert.ToString(buffer[11]));
            // использование БД2
            var isDatabase2Use = buffer[14] & 0x01;
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_Database2IsUse, isDatabase2Use == 0 ? DeviceMessages.NotUse : isDatabase2Use == 1 ? DeviceMessages.Use : string.Empty);
            // способ переключ. БД
            var databaseSwitchType = (buffer[14] & 0x06) >> 1;
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_DatabaseSwitchType, databaseSwitchType == 0 ? DeviceMessages.Manual : databaseSwitchType == 1 ? DeviceMessages.AutomaticDate : string.Empty);
            // доступ к перекл.БД с клавиат.
            var databaseSwitchAccess = (buffer[14] & 0x38) >> 3;
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_DatabaseSwitchAccess, databaseSwitchAccess == 0 ? DeviceMessages.Ban :
                                                                                                  databaseSwitchAccess == 1 ? DeviceMessages.WithPassword :
                                                                                                  databaseSwitchAccess == 2 ? DeviceMessages.PressAccessButton : string.Empty);
            // доступ к перекл. БД по сети
            var databaseSwitchNetworkAccess = (buffer[14] & 0xC0) >> 6;
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_DatabaseSwitchNetworkAccess, databaseSwitchNetworkAccess == 0 ? DeviceMessages.Ban :
                                                                                                         databaseSwitchNetworkAccess == 1 ? DeviceMessages.WithPassword : string.Empty);

            if (isFirmwareLess2)
            {
                var measurementUnit = buffer[16] & 0x01;
                UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_MeasurementUnit, measurementUnit == 0 ? DeviceMessages.SI :
                                                                                                         measurementUnit == 1 ? DeviceMessages.MKS : string.Empty);
            }

            // тип термодатчиков
            var thermoSensorType = (buffer[16] & 0x1E) >> 1;
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ThermoSensorType, thermoSensorType == 0 ? Tv7Resources.Thermo100 :
                                                                                              thermoSensorType == 1 ? Tv7Resources.Thermo500 :
                                                                                              thermoSensorType == 2 ? Tv7Resources.ThermoPt100 :
                                                                                              thermoSensorType == 3 ? Tv7Resources.ThermoPt500 : string.Empty);

            // перевод часов
            var clockChange = (buffer[16] & 0x40) >> 6;
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ClockChange, clockChange == 0 ? DeviceMessages.No : clockChange == 1 ? DeviceMessages.Yes : string.Empty);

            // инверсия дисплея
            var displayInversion = (buffer[16] & 0x80) >> 7;
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_DisplayInversion, displayInversion == 0 ? DeviceMessages.No : displayInversion == 1 ? DeviceMessages.Yes : string.Empty);


            // НАСТРОЙКИ ТРУБ
            int dbCount = Convert.ToBoolean(isDatabase2Use) ? 2 : 1;

            for (int dbNumber = 1; dbNumber <= 2; dbNumber++)
            {
                if (_isNewFirmware) { _actionSteps.GetPipesSettingsControlPipes_0_2NewFirmware(dbNumber); }
                else { _actionSteps.GetPipesSettingsControlPipes_0_2(dbNumber); }

                buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
                var pipeStructureSize = _isNewFirmware ? 36 : 34;
                // три трубы ТВ1
                for (var pipeNumber = 1; pipeNumber <= 3; pipeNumber++)
                {
                    var offset = (pipeNumber - 1) * pipeStructureSize;
                    ParsePipeSettingsControl(buffer[4 + offset], 1, pipeNumber, dbNumber, _isNewFirmware);
                    ParsePipeSingleSet(buffer, 5 + offset, 1, pipeNumber, dbNumber);

                    if (_isNewFirmware)
                    {
                        ParsePressureSensorForNewFirmware(buffer[3 + offset], 1, pipeNumber, dbNumber);
                        ParseEmptyPipeSettings(buffer[38 + offset], 1, pipeNumber, dbNumber);
                    }
                }

                if (_isNewFirmware) { _actionSteps.GetPipesSettingsControlPipes_3_5NewFirmware(dbNumber); }
                else { _actionSteps.GetPipesSettingsControlPipes_3_5(dbNumber); }
                buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
                // две трубы ТВ2
                for (var pipeNumber = 1; pipeNumber <= 2; pipeNumber++)
                {
                    var offset = (pipeNumber - 1) * pipeStructureSize;
                    ParsePipeSettingsControl(buffer[4 + offset], 2, pipeNumber, dbNumber, _isNewFirmware);
                    ParsePipeSingleSet(buffer, 5 + offset, 2, pipeNumber, dbNumber);

                    if (_isNewFirmware)
                    {
                        ParsePressureSensorForNewFirmware(buffer[3 + offset], 2, pipeNumber, dbNumber);
                        ParseEmptyPipeSettings(buffer[38 + offset], 2, pipeNumber, dbNumber);
                    }
                }

                // у модели 05 - нумерация другая, 7 труб и три ТВ
                int tvNumberModel05 = MeasurementDevice.SubModel.Contains(Tv7Resources.FiveModel) ? 3 : 2;
                int pipeNumberModel05 = MeasurementDevice.SubModel.Contains(Tv7Resources.FiveModel) ? 1 : 3;

                // для новой прошивки для последней трубы идет смещение в 3 байта, т.к. размер структуры 18 байтов, а не 17 байтов
                // создаем настройки для ТВ2 тр3 (для всех моделей, кроме 05) или ТВ3 тр1 (для модели 05)
                int offsetForNewFirmware = _isNewFirmware ? 76 : 72;
                ParsePipeSettingsControl(buffer[offsetForNewFirmware], tvNumberModel05, pipeNumberModel05, dbNumber, _isNewFirmware);
                ParsePipeSingleSet(buffer, offsetForNewFirmware + 1, tvNumberModel05, pipeNumberModel05, dbNumber);

                if (_isNewFirmware)
                {
                    ParsePressureSensorForNewFirmware(buffer[offsetForNewFirmware], tvNumberModel05, pipeNumberModel05, dbNumber);
                    ParseEmptyPipeSettings(buffer[110], tvNumberModel05, pipeNumberModel05, dbNumber);
                }

                // ТВ3 тр2 для модели 05
                if (MeasurementDevice.SubModel.Contains(Tv7Resources.FiveModel))
                {
                    if (_isNewFirmware) { _actionSteps.GetPipesSettingsControlPipe_6NewFirmware(dbNumber); } 
                    else { _actionSteps.GetPipesSettingsControlPipe_6(dbNumber); }
                    buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
                    ParsePipeSettingsControl(buffer[4], 3, 2, dbNumber, _isNewFirmware);
                    ParsePipeSingleSet(buffer, 5, 3, 2, dbNumber);

                    if (_isNewFirmware)
                    {
                        ParsePressureSensorForNewFirmware(buffer[4], 3, 2, dbNumber);
                        ParseEmptyPipeSettings(38, 3, 2, dbNumber);
                    }
                }
            }

            // НАСТРОЙКИ ТЕПЛОВЫХ ВВОДОВ
            if (_isNewFirmware) { _actionSteps.GetTvSettings_Db1NewFirmware(); } else { _actionSteps.GetTvSettings_Db1(); }
            buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
            ParseTvSettingsControl(buffer, 1, 1, isFirmwareGreater2, _isNewFirmware);
            ParseTvSettingsControl(buffer, 2, 1, isFirmwareGreater2, _isNewFirmware);

            // если БД2 используется
            if (Convert.ToBoolean(isDatabase2Use))
            {
                if (_isNewFirmware) { _actionSteps.GetTvSettings_Db2NewFirmware(); } else { _actionSteps.GetTvSettings_Db2(); }
                buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
                ParseTvSettingsControl(buffer, 1, 2, isFirmwareGreater2, _isNewFirmware);
                ParseTvSettingsControl(buffer, 2, 2, isFirmwareGreater2, _isNewFirmware);
            }

            // настройки дополнительного импульсного входа
            if (_isNewFirmware) { _actionSteps.GetImpulseInputSettingsNewFirmware(); } else { _actionSteps.GetImpulseInputSettings();  }
            buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            // назначение импульсного входа
            var impulseInputTarget = buffer[4] & 0x07;
            var impulseInputTargerStr = impulseInputTarget == 0 ? DeviceMessages.No :
                                        impulseInputTarget == 1 ? Tv7Resources.ImpulseInputTarget_1 :
                                        impulseInputTarget == 2 ? Tv7Resources.ImpulseInputTarget_2 :
                                        impulseInputTarget == 3 ? Tv7Resources.ImpulseInputTarget_3 : string.Empty;
            UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ImpulseInputTarget, impulseInputTargerStr);
            
            // уровень сигнала (только способа исп. "Сигнализация")
            if (impulseInputTargerStr.Equals(Tv7Resources.ImpulseInputTarget_3))
            {
                var impulseInputSignalLevel = (buffer[4] & 0x08) >> 3;
                UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ImpulseInputSignalLevel,
                                                        impulseInputSignalLevel == 0 ? Tv7Resources.ImpulseInputSignalLevel_0 :
                                                        impulseInputSignalLevel == 1 ? Tv7Resources.ImpulseInputSignalLevel_1 : string.Empty);
            }

            // единица измерения (только способа исп. "Счет имп.")
            if (impulseInputTargerStr.Equals(Tv7Resources.ImpulseInputTarget_2))
            {
                var impulseInputMeasurementUnit = (buffer[4] & 0xF0) >> 4;
                UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ImpulseInputMeasurementUnit,
                                                        impulseInputMeasurementUnit == 0 ? DeviceMessages.CubicMeter :
                                                        impulseInputMeasurementUnit == 1 ? DeviceMessages.WattPerHour : string.Empty);
            }

            // вес имп./Tподтв
            var impulseValue = ModbusProtocol.ParseFloat(buffer, 5);
            var impulseValueStr = impulseInputTargerStr.Equals(Tv7Resources.ImpulseInputTarget_3) ? string.Format(StringFormat.Second, impulseValue) :
                                  impulseInputTargerStr.Equals(Tv7Resources.ImpulseInputTarget_2) ? string.Format(StringFormat.LiterPerImpulse, impulseValue) : string.Empty;

            if (!string.IsNullOrEmpty(impulseValueStr))
            {
                UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ImpulseInputImpulseWeightOrConfirmTime, impulseValueStr);
            }

            // значения ЧН и ЧВ (только способа исп. "Счет имп.")
            if (impulseInputTargerStr.Equals(Tv7Resources.ImpulseInputTarget_2))
            {
                var low = ModbusProtocol.ParseFloat(buffer, 9);
                var high = ModbusProtocol.ParseFloat(buffer, 13);
                UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ImpulseInputLow, Convert.ToString(low));
                UpdateDeviceTechnicalParam(TechParams, (int)DeviceParameter.TV7_ImpulseInputHigh, Convert.ToString(high));
            }

        }

        private void ParseEmptyPipeSettings(byte b, int tvNumber, int pipeNumber, int dbNumber)
        {
            // учет пустой трубы
            int emptyPipeAccounting = b & 0x01;
            int emptyPipeAccountingDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe{1}EmptyPipeAccounting_Db{2}",
                                                    tvNumber, pipeNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, emptyPipeAccountingDeviceParameterId, emptyPipeAccounting == 0 ? DeviceMessages.No :
                                                                                         emptyPipeAccounting == 1 ? DeviceMessages.Yes : string.Empty);

            // вход пустой трубы
            int emptyPipeInput = (b & 0x0E) >> 1;
            int emptyPipeInputDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe{1}EmptyPipeInput_Db{2}",
                                                    tvNumber, pipeNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, emptyPipeInputDeviceParameterId, emptyPipeInput == 0 ? DeviceMessages.NotUseShort : Convert.ToString(emptyPipeInput));

            // вход реверса
            int reverseInput = (b & 0xE0) >> 5;
            int reverseInputDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe{1}ReverseInput_Db{2}",
                                                    tvNumber, pipeNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, reverseInputDeviceParameterId, reverseInput == 0 ? DeviceMessages.NotUseShort : Convert.ToString(reverseInput));

        }

        /// <summary>
        /// Парсит набор вещественных чисел-настроек (договорные температуры, давления и прочее)
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="startIndex"></param>
        /// <param name="tvNumber"></param>
        /// <param name="pipeNumber"></param>
        /// <param name="dbNumber"></param>
        private void ParsePipeSingleSet(byte[] buffer, int startIndex, int tvNumber, int pipeNumber, int dbNumber)
        {
            ParsePipeSingleValue(buffer, startIndex, Tv7Resources.ContractTemp, tvNumber, pipeNumber, dbNumber);
            ParsePipeSingleValue(buffer, startIndex + 4, Tv7Resources.ContractPressure, tvNumber, pipeNumber, dbNumber);
            ParsePipeSingleValue(buffer, startIndex + 8, Tv7Resources.HeightAdjustment, tvNumber, pipeNumber, dbNumber);
            ParsePipeSingleValue(buffer, startIndex + 12, Tv7Resources.HighLimitSensor, tvNumber, pipeNumber, dbNumber);
            ParsePipeSingleValue(buffer, startIndex + 16, Tv7Resources.ImpulseWeight, tvNumber, pipeNumber, dbNumber);
            ParsePipeSingleValue(buffer, startIndex + 20, Tv7Resources.VolumeMin, tvNumber, pipeNumber, dbNumber);
            ParsePipeSingleValue(buffer, startIndex + 24, Tv7Resources.VolumeMax, tvNumber, pipeNumber, dbNumber);
            ParsePipeSingleValue(buffer, startIndex + 28, Tv7Resources.ContractVolume, tvNumber, pipeNumber, dbNumber);
        }


        /// <summary>
        /// Парсинг настройки, представляющей собой вещественное число
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="index"></param>
        /// <param name="valueName"></param>
        /// <param name="tvNumber"></param>
        /// <param name="pipeNumber"></param>
        /// <param name="dbNumber"></param>
        private void ParsePipeSingleValue(byte[] buf, int index, string valueName, int tvNumber, int pipeNumber, int dbNumber)
        {
            var value = Convert.ToString(ModbusProtocol.ParseFloat(buf, index));
            int valueDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe{1}{2}_Db{3}",
                                                    tvNumber, pipeNumber, valueName, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, valueDeviceParameterId, value);
        }

        private void ParseTvSettingsControl(byte[] buffer, int tvNumber, int dbNumber, bool isFirmwareGreater2, bool isNewFirmware)
        {
            int offset = (tvNumber - 1) * 18;
            // СИ
            int measurementScheme = buffer[4 + offset];
            int measurementSchemeDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}MeasurementScheme_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, measurementSchemeDeviceParameterId, measurementScheme == 0 ? Tv7Resources.HeatInputNoUse : Convert.ToString(measurementScheme));

            // Исп.Qтв
            if (isFirmwareGreater2)
            {
                int useQtv = buffer[3 + offset];
                int useQtvDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}UseQtv_Db{1}", tvNumber, dbNumber));
                UpdateDeviceTechnicalParam(TechParams, useQtvDeviceParameterId, useQtv == 0 ? DeviceMessages.ThereIs :
                                                                                useQtv == 1 ? DeviceMessages.No :
                                                                                useQtv == 2 ? DeviceMessages.Sum :
                                                                                useQtv == 3 ? DeviceMessages.Diff : string.Empty);
            }

            // dMmax
            var dMmax = ModbusProtocol.ParseFloat(buffer, 5 + offset);
            int dMmaxDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}dMmax_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, dMmaxDeviceParameterId, Convert.ToString(dMmax));

            // txдог
            var txContract = ModbusProtocol.ParseFloat(buffer, 9 + offset);
            int txContractDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}txContract_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, txContractDeviceParameterId, Convert.ToString(txContract));

            // Pxдог
            var pxContract = ModbusProtocol.ParseFloat(buffer, 13 + offset);
            int pxContractDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}PxContract_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, pxContractDeviceParameterId, Convert.ToString(pxContract));

            // КТ3
            var kt3 = buffer[18 + offset] & 0x03;
            int kt3DeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe3Config_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, kt3DeviceParameterId, kt3 == 0 ? Tv7Resources.KT3_0 :
                                                                         kt3 == 1 ? Tv7Resources.KT3_1 :
                                                                         kt3 == 2 ? Tv7Resources.KT3_2 :
                                                                         kt3 == 3 ? Tv7Resources.KT3_3 : string.Empty);
            // ФРТ
            var ftr = (buffer[18 + offset] & 0x78) >> 3;
            int ftrDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}FRT_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, ftrDeviceParameterId, ftr == 0 ? Tv7Resources.FTR_0 :
                                                                         ftr == 1 ? Tv7Resources.FTR_1 :
                                                                         ftr == 2 ? Tv7Resources.FTR_2 :
                                                                         ftr == 3 ? Tv7Resources.FTR_3 :
                                                                         ftr == 4 ? Tv7Resources.FTR_4 :
                                                                         ftr == 5 ? Tv7Resources.FTR_5 :
                                                                         ftr == 6 ? Tv7Resources.FTR_6 :
                                                                         ftr == 7 ? Tv7Resources.FTR_7 :
                                                                         ftr == 8 ? Tv7Resources.FTR_8 :
                                                                         ftr == 9 ? Tv7Resources.FTR_9 :
                                                                         ftr == 10 ? Tv7Resources.FTR_10 : string.Empty);

            // контроль t
            var tControl = (buffer[18 + offset] & 0x80) >> 7;
            int tControlDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}tControl_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, tControlDeviceParameterId, tControl == 0 ? Tv7Resources.ControlV_WithSubstitution :
                                                                              tControl == 1 ? Tv7Resources.ControlV_CountCanceled : string.Empty);

            // контроль dM
            var dMControl = (buffer[17 + offset] & 0x0E) >> 1;
            int dMControlDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}dMControl_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, dMControlDeviceParameterId, dMControl == 0 ? DeviceMessages.No :
                                                                               dMControl == 1 ? Tv7Resources.WithoutSubstitution1 :
                                                                               dMControl == 2 ? Tv7Resources.WithoutSubstitution2 :
                                                                               dMControl == 3 ? Tv7Resources.WithSubstitution1 :
                                                                               dMControl == 4 ? Tv7Resources.WithSubstitution2 : string.Empty);

            // контроль Q
            var qControl = (buffer[17 + offset] & 0x70) >> 4;
            int qControlDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}QControl_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, qControlDeviceParameterId, qControl == 0 ? DeviceMessages.No :
                                                                              qControl == 1 ? Tv7Resources.WithoutSubstitution :
                                                                              qControl == 2 ? Tv7Resources.WithSubstitution :
                                                                              qControl == 3 ? Tv7Resources.ControlV_CountCanceled : string.Empty);

            // контроль dt
            var dtControlPart1 = (buffer[17 + offset] & 0x80) >> 7;
            var dtControlPart2 = (buffer[20 + offset] & 0x03) << 1;
            var dtControl = (byte)dtControlPart1 | (byte)dtControlPart2;
            int dtControlDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}dtControl_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, dtControlDeviceParameterId, dtControl == 0 ? Tv7Resources.WithoutSubstitution :
                                                                               dtControl == 1 ? Tv7Resources.WithSubstitution :
                                                                               dtControl == 2 ? Tv7Resources.ControlV_CountCanceled :
                                                                               dtControl == 3 && isNewFirmware ? DeviceMessages.No : string.Empty);

            // dtmin
            var dtmin = (buffer[20 + offset] & 0x0C) >> 2;
            int dtminDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}dtmin_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, dtminDeviceParameterId, dtmin == 0 ? "2" :
                                                                           dtmin == 1 ? "3" : string.Empty);

            // Исп.tx
            var usetx = (buffer[20 + offset] & 0xE0) >> 5;
            int usetxDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Usetx_Db{1}", tvNumber, dbNumber));
            string usetxResult = string.Empty;

            if (usetx == 0) { usetxResult = Tv7Resources.Usetx_0; }
            else if (usetx == 1) { usetxResult = Tv7Resources.Usetx_1;  }
            else if (usetx == 2)
            {
                if (isNewFirmware) { usetxResult = Tv7Resources.Usetx_2; }
                else { usetxResult = Tv7Resources.Usetx_2_old; }
            }
            else if (usetx == 3)
            {
                if (isNewFirmware) { usetxResult = Tv7Resources.Usetx_3; }
                else { usetxResult = Tv7Resources.Usetx_3_old; }
            }
            else if (usetx == 4) { usetxResult = Tv7Resources.Usetx_4; }
            else if (usetx == 5) { usetxResult = Tv7Resources.Usetx_5; }

            UpdateDeviceTechnicalParam(TechParams, usetxDeviceParameterId, usetxResult);

            // Исп.tнв
            var usetnv = (buffer[19 + offset] & 0x1E) >> 1;
            int usetnvDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Usetnv_Db{1}", tvNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, usetnvDeviceParameterId, usetnv == 0 ? Tv7Resources.Usetnv_0 :
                                                                            usetnv == 1 ? Tv7Resources.Usetnv_1 :
                                                                            usetnv == 2 ? Tv7Resources.Usetnv_2 :
                                                                            usetnv == 3 ? Tv7Resources.Usetnv_3 :
                                                                            usetnv == 4 ? Tv7Resources.Usetnv_4 :
                                                                            usetnv == 5 ? Tv7Resources.Usetnv_5 : string.Empty);
            
        }

        /// <summary>
        /// Парсинг наличия датчика P и направления потока при телеметрии для новой прошивки
        /// </summary>
        /// <param name="b"></param>
        /// <param name="tvNumber"></param>
        /// <param name="pipeNumber"></param>
        /// <param name="dbNumber"></param>
        private void ParsePressureSensorForNewFirmware(byte b, int tvNumber, int pipeNumber, int dbNumber)
        {
            // датчик P
            int pressureSensor = (b & 0x06) >> 1;
            int pressureSensorDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe{1}PressureSensor_Db{2}", tvNumber, pipeNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, pressureSensorDeviceParameterId, pressureSensor == 0 ? DeviceMessages.No :
                                                                               pressureSensor == 1 ? DeviceMessages.ThereIs : 
                                                                               pressureSensor == 2 ? DeviceMessages.ThereIsNotUse : string.Empty);

            // направление потока при телеметрии
            int flowDirection = (b & 0x18) >> 3;
            int flowDirectionDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe{1}FlowDirection_Db{2}", tvNumber, pipeNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, flowDirectionDeviceParameterId, flowDirection == 0 ? DeviceMessages.Direct :
                                                                                   flowDirection == 1 ? DeviceMessages.Return :
                                                                                   flowDirection == 2 ? DeviceMessages.Reverse : string.Empty);
        }

        private void ParsePipeSettingsControl(byte b, int tvNumber, int pipeNumber, int dbNumber, bool isNewFirmware)
        {
            // Контроль V
            int controlV = b & 0x07;
            int controlVDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe{1}ControlV_Db{2}", tvNumber, pipeNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, controlVDeviceParameterId, controlV == 0 ? DeviceMessages.No :
                                                                              controlV == 1 ? Tv7Resources.ControlV_WithoutSubstitution :
                                                                              controlV == 2 ? Tv7Resources.ControlV_WithSubstitution :
                                                                              controlV == 3 ? Tv7Resources.ControlV_WithSubstitutionAndU :
                                                                              controlV == 4 ? Tv7Resources.ControlV_CountCanceled : string.Empty);

            // Контроль ВС
            int controlWC = (b >> 3) & 0x03;
            int controlWCDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe{1}ControlWC_Db{2}", tvNumber, pipeNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, controlWCDeviceParameterId, controlWC == 0 ? DeviceMessages.No :
                                                                               controlWC == 1 ? Tv7Resources.ControlWC_Network :
                                                                               controlWC == 2 ? Tv7Resources.ControlWC_Individual : string.Empty);

            // Резерв / датчик P
            if (!isNewFirmware)
            {
                int pressureSensor = (b >> 5) & 0x01;
                int pressureSensorDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe{1}PressureSensor_Db{2}", tvNumber, pipeNumber, dbNumber));
                UpdateDeviceTechnicalParam(TechParams, pressureSensorDeviceParameterId, pressureSensor == 0 ? DeviceMessages.No :
                                                                                   pressureSensor == 1 ? DeviceMessages.ThereIs : string.Empty);
            }

            // Тип ВС
            int waterCounterType = (b >> 6) & 0x03;
            int waterCounterTypeDeviceParameterId = BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_Tv{0}Pipe{1}WaterCounterType_Db{2}", tvNumber, pipeNumber, dbNumber));
            UpdateDeviceTechnicalParam(TechParams, waterCounterTypeDeviceParameterId, waterCounterType == 0 ? DeviceMessages.Mechanic :
                                                                                      waterCounterType == 1 ? DeviceMessages.Electronic :
                                                                                      waterCounterType == 2 && isNewFirmware ? DeviceMessages.Telemetry : string.Empty);
        }
    }
}

using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.API
{
    internal sealed partial class Functions
    {
        /// <summary>
        /// Возвращает пакет байтов для записи нового часа приборного времени
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public byte[] SetDeviceTimeHour(int hour)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDeviceTimeHour, ActionHelper.SetIntValue(hour));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи новой минуты приборного времени
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public byte[] SetDeviceTimeMinute(int minute)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDeviceTimeMinute, ActionHelper.SetIntValue(minute));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового дня приборного времени
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public byte[] SetDeviceTimeDay(int day)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDeviceTimeDay, ActionHelper.SetIntValue(day));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового месяца приборного времени
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public byte[] SetDeviceTimeMonth(int month)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDeviceTimeMonth, ActionHelper.SetIntValue(month));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового года приборного времени
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public byte[] SetDeviceTimeYear(int year)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDeviceTimeYear, ActionHelper.SetIntValue(year));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11010
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11010(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11010, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11011
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11011(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11011, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11012
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11012(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11012, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11013
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11013(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11013, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11014
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11014(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11014, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11019
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11019(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11019, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11020
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11020(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11020, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11021
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11021(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11021, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11022
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11022(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11022, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11023
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11023(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11023, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11029
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11029(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11029, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11034
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11034(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11034, ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11035
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11035(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11035, ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11036
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11036(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11036, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11051
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11051(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11051, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11076
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11076(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11076, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11077
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11077(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11077, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11084
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11084(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11084, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11140
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11140(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11140, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11161
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11161(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11161, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11173
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11173(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11173, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11174
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11174(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11174, ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11175
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11175(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11175, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11176
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11176(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11176, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11177
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11177(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11177, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11178
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11178(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11178, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11181
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11181(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11181, ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11182
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11182(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11182, ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11183
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11183(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11183, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11184
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11184(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11184, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11185
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11185(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11185, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11186
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11186(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11186, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11188
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11188(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11188, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11179
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11179(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11179, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11180
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11180(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11180, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения регистра 11092
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11092(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11092, ActionHelper.SetIntValue(value));
        }
    }
}

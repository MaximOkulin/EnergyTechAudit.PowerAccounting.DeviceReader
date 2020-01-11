using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public class ActionHelper
    {
        /// <summary>
        /// Возвращает действие подстановки в ModbusFunctionData целочисленного значения
        /// </summary>
        /// <param name="value">Целое число</param>
        public static Action<ModbusFunctionData> SetIntValue(int value)
        {
            return data =>
            {
                data.Data = value.ToTwoBigEndianBytes();
            };
        }

        /// <summary>
        /// Возвращает действие подстановки в ModbusFunctionData булева значения
        /// </summary>
        /// <param name="value">Булево значение</param>
        public static Action<ModbusFunctionData> SetBoolValue(bool value)
        {
            return data =>
            {
                int k = value ? 1 : 0;
                data.Data = k.ToTwoBigEndianBytes();
            };
        }

        /// <summary>
        /// Возвращает действие подстановки в ModbusFunctionData вещественного числа
        /// в формате Danfoss ECL Comfort 210/310
        /// </summary>
        /// <param name="value">Вещественное число</param>
        public static Action<ModbusFunctionData> SetEcl310DoubleValue(double value)
        {
            return data =>
            {
                var val = (int) (value*10);
                data.Data = val.ToTwoBigEndianBytes();
            };
        }
    }
}

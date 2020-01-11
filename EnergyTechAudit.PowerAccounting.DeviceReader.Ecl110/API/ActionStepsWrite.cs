using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.API
{
    internal sealed partial class ActionSteps
    {
        /// <summary>
        /// Устанавливает новый час в текущее время прибора
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public bool SetDeviceTimeHour(int hour)
        {
            Transport.CurrentCommand = _commands.SetDeviceTimeHour;
            Transport.Send(_functions.SetDeviceTimeHour(hour), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новую минуту в текущее время прибора
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public bool SetDeviceTimeMinute(int minute)
        {
            Transport.CurrentCommand = _commands.SetDeviceTimeMinute;
            Transport.Send(_functions.SetDeviceTimeMinute(minute), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новый день в текущее время прибора
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public bool SetDeviceTimeDay(int day)
        {
            Transport.CurrentCommand = _commands.SetDeviceTimeDay;
            Transport.Send(_functions.SetDeviceTimeDay(day), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новый месяц в текущее время прибора
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public bool SetDeviceTimeMonth(int month)
        {
            Transport.CurrentCommand = _commands.SetDeviceTimeMonth;
            Transport.Send(_functions.SetDeviceTimeMonth(month), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новый год в текущее время прибора
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public bool SetDeviceTimeYear(int year)
        {
            Transport.CurrentCommand = _commands.SetDeviceTimeYear;
            Transport.Send(_functions.SetDeviceTimeYear(year), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11010
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11010(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11010;
            Transport.Send(_functions.SetPnu11010(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11011
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11011(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11011;
            Transport.Send(_functions.SetPnu11011(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11012
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11012(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11012;
            Transport.Send(_functions.SetPnu11012(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11013
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11013(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11013;
            Transport.Send(_functions.SetPnu11013(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11014
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11014(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11014;
            Transport.Send(_functions.SetPnu11014(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11019
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11019(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11019;
            Transport.Send(_functions.SetPnu11019(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11020
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11020(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11020;
            Transport.Send(_functions.SetPnu11020(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11021
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11021(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11021;
            Transport.Send(_functions.SetPnu11021(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11022
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11022(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11022;
            Transport.Send(_functions.SetPnu11022(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11023
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11023(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11023;
            Transport.Send(_functions.SetPnu11023(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11029
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11029(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11029;
            Transport.Send(_functions.SetPnu11029(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11034
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11034(double value)
        {
            Transport.CurrentCommand = _commands.SetPnu11034;
            Transport.Send(_functions.SetPnu11034(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11035
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11035(double value)
        {
            Transport.CurrentCommand = _commands.SetPnu11035;
            Transport.Send(_functions.SetPnu11035(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11036
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11036(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11036;
            Transport.Send(_functions.SetPnu11036(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11051
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11051(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11051;
            Transport.Send(_functions.SetPnu11051(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11076
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11076(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11076;
            Transport.Send(_functions.SetPnu11076(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11077
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11077(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11077;
            Transport.Send(_functions.SetPnu11077(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11084
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11084(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11084;
            Transport.Send(_functions.SetPnu11084(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11140
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11140(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11140;
            Transport.Send(_functions.SetPnu11140(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11161
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11161(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11161;
            Transport.Send(_functions.SetPnu11161(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11173
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11173(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11173;
            Transport.Send(_functions.SetPnu11173(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11174
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11174(double value)
        {
            Transport.CurrentCommand = _commands.SetPnu11174;
            Transport.Send(_functions.SetPnu11174(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11175
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11175(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11175;
            Transport.Send(_functions.SetPnu11175(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11176
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11176(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11176;
            Transport.Send(_functions.SetPnu11176(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11177
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11177(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11177;
            Transport.Send(_functions.SetPnu11177(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11178
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11178(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11178;
            Transport.Send(_functions.SetPnu11178(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11181
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11181(double value)
        {
            Transport.CurrentCommand = _commands.SetPnu11181;
            Transport.Send(_functions.SetPnu11181(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11182
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11182(double value)
        {
            Transport.CurrentCommand = _commands.SetPnu11182;
            Transport.Send(_functions.SetPnu11182(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11183
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11183(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11183;
            Transport.Send(_functions.SetPnu11183(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11184
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11184(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11184;
            Transport.Send(_functions.SetPnu11184(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11185
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11185(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11185;
            Transport.Send(_functions.SetPnu11185(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11186
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11186(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11186;
            Transport.Send(_functions.SetPnu11186(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11188
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11188(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11188;
            Transport.Send(_functions.SetPnu11188(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11179
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11179(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11179;
            Transport.Send(_functions.SetPnu11179(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11180
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11180(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11180;
            Transport.Send(_functions.SetPnu11180(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает новое значение регистра 11092
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPnu11092(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11092;
            Transport.Send(_functions.SetPnu11092(value), true);
            return Wait();
        }
    }
}

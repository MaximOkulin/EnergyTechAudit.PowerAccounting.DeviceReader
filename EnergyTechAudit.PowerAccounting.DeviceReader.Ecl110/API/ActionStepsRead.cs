using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.API
{
    internal sealed partial class ActionSteps : ActionStepsBase
    {
        private readonly Functions _functions;
        private readonly int _deviceAddress;
        private readonly Commands _commands;

        public ActionSteps(DeviceTransport eclConnection, ManualResetEvent autoEvent, int deviceAddress)
            : base(eclConnection, autoEvent)
        {
            _functions = new Functions(deviceAddress);
            _deviceAddress = deviceAddress;
            _commands = new Commands();
        }

        /// <summary>
        /// Возвращает значения регистров 11200-11203
        /// </summary>
        public bool GetPnu11200_11203()
        {
            Transport.CurrentCommand = _commands.GetPnu11200_11203;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11200_11203(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает текущее время прибора
        /// </summary>
        public void GetDeviceTime()
        {
            Transport.CurrentCommand = _commands.GetDeviceTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetDeviceTime(), true);
            Wait();
        }

        /// <summary>
        /// Возвращает значения регистров 11228 и 11229
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11228_11229()
        {
            Transport.CurrentCommand = _commands.GetPnu11228_11229;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11228_11229(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистров 11010-11014
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11010_11014()
        {
            Transport.CurrentCommand = _commands.GetPnu11010_11014;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11010_11014(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистров 11019-11023
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11019_11023()
        {
            Transport.CurrentCommand = _commands.GetPnu11019_11023;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11019_11023(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистров 11034-11036
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11034_11036()
        {
            Transport.CurrentCommand = _commands.GetPnu11034_11036;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11034_11036(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистра 11029
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11029()
        {
            Transport.CurrentCommand = _commands.GetPnu11029;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11029(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистра 11051
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11051()
        {
            Transport.CurrentCommand = _commands.GetPnu11051;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11051(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистра 11084
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11084()
        {
            Transport.CurrentCommand = _commands.GetPnu11084;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11084(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистра 11140
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11140()
        {
            Transport.CurrentCommand = _commands.GetPnu11140;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11140(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистра 11161
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11161()
        {
            Transport.CurrentCommand = _commands.GetPnu11161;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11161(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистров 11076-11077
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11076_11077()
        {
            Transport.CurrentCommand = _commands.GetPnu11076_11077;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11076_11077(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистров 11173-11180
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11173_11180()
        {
            Transport.CurrentCommand = _commands.GetPnu11173_11180;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11173_11180(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения регистров 11181-11186
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11181_11186()
        {
            Transport.CurrentCommand = _commands.GetPnu11181_11186;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11181_11186(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение регистра 11188
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11188()
        {
            Transport.CurrentCommand = _commands.GetPnu11188;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11188(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение регистров 11021-11022
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11021_11022()
        {
            Transport.CurrentCommand = _commands.GetPnu11021_11022;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11021_11022(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение регистра 11092
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11092()
        {
            Transport.CurrentCommand = _commands.GetPnu11092;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11092(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение регистров 11176-11177
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11176_11177()
        {
            Transport.CurrentCommand = _commands.GetPnu11176_11177;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11176_11177(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение регистров 11183-11186
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11183_11186()
        {
            Transport.CurrentCommand = _commands.GetPnu11183_11186;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11183_11186(), true);
            return Wait();
        }
    }
}

using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using System.Threading;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.EtaModem
{
    public class ActionSteps : ActionStepsBase
    {
        private readonly Functions _functions;
        private readonly Commands _commands;

        public ActionSteps(EtaModemConnection etaModemConnection, ManualResetEvent autoEvent, int networkAddress)
            : base(etaModemConnection, autoEvent)
        {
            _functions = new Functions(networkAddress);
            _commands = new Commands();
        }

        /// <summary>
        /// Установка скорости последовательного порта
        /// </summary>
        /// <param name="baudRate"></param>
        public void SetBaudRate(uint baudRate)
        {
            Transport.CurrentCommand = _commands.SetBaudRate;
            Transport.Send(_functions.SetBaudRate(baudRate), true);
            Wait();
        }

        /// <summary>
        /// Установка формата кадра данных
        /// </summary>
        /// <param name="dataFormat"></param>
        public void SetDataFormat(short dataFormat)
        {
            Transport.CurrentCommand = _commands.SetDataFormat;
            Transport.Send(_functions.SetDataFormat(dataFormat), true);
            Wait();
        }

        /// <summary>
        /// Чтение скорости последовательного порта
        /// </summary>
        public void GetBaudRate()
        {
            Transport.CurrentCommand = _commands.GetBaudRate;
            Transport.Send(_functions.GetBaudRate(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущей версии прошивки
        /// </summary>
        public void ReadSoftware()
        {
            Transport.CurrentCommand = _commands.ReadSoftware;
            Transport.Send(_functions.ReadSoftware(), true);
            Wait();
        }

        /// <summary>
        /// Чтение формата кадра данных последовательного порта
        /// </summary>
        public void GetDataFormat()
        {
            Transport.CurrentCommand = _commands.GetDataFormat;
            Transport.Send(_functions.GetDataFormat(), true);
            Wait();
        }

        public void SaveSettings()
        {
            Transport.CurrentCommand = _commands.SaveSettings;
            Transport.Send(_functions.SaveSettings(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих состояний дискретных входов
        /// </summary>
        public void GetInputs()
        {
            Transport.CurrentCommand = _commands.GetInputs;
            Transport.Send(_functions.GetInputs(), true);
            Wait();
        }
    }
}

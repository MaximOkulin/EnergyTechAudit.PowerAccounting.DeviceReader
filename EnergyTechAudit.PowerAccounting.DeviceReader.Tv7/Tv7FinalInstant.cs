using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7
{
    public partial class Tv7
    {
        /// <summary>
        /// Чтение текущих итоговых (нарастающим итогом)
        /// </summary>
        private void ReadFinalInstantArchives()
        {
            RaiseTraceInfoPassedEvent(DeviceMessages.Tv7ReadFinalInstantByPipes);
            ReadFinalInstantByPipes();
            RaiseTraceInfoPassedEvent(DeviceMessages.Tv7ReadFinalInstantByHeatInputs);
            ReadFinalInstantByHeatInputs();

            // текущее итоговое значение по доп. параметру
            _actionSteps.GetFinalInstantAdditionalParameter();
            byte[] buf = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            var apSum = BitConverter.ToDouble(new[] {buf[4], buf[3], buf[6], buf[5], buf[8], buf[7], buf[10], buf[9]}, 0);
            apSum = double.IsNaN(apSum) ? 0 : apSum;

            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)apSum,
                DeviceParameterId = (int)DeviceParameter.TV7_APSum
            }));            
        }

        /// <summary>
        /// Чтение текущих итоговых по трубам
        /// </summary>
        private void ReadFinalInstantByPipes()
        {
            _actionSteps.GetFinalInstantTv1Pipe1();
            AddFinalInstantPipeToArchives(1);

            _actionSteps.GetFinalInstantTv1Pipe2();
            AddFinalInstantPipeToArchives(2);

            _actionSteps.GetFinalInstantTv1Pipe3();
            AddFinalInstantPipeToArchives(3);

            _actionSteps.GetFinalInstantTv2Pipe1();
            AddFinalInstantPipeToArchives(4);

            _actionSteps.GetFinalInstantTv2Pipe2();
            AddFinalInstantPipeToArchives(5);

            _actionSteps.GetFinalInstantTv2Pipe3();
            AddFinalInstantPipeToArchives(6);
        }

        /// <summary>
        /// Чтение текущих итоговых по тепловым вводам
        /// </summary>
        private void ReadFinalInstantByHeatInputs()
        {
            _actionSteps.GetFinalInstantTv1();
            AddFinalInstantTvToArchives(1);

            _actionSteps.GetFinalInstantTv2();
            AddFinalInstantTvToArchives(2);
        }

        /// <summary>
        /// Добавляет в локальную коллекцию архивов текущие итоговые по трубопроводу
        /// </summary>
        /// <param name="pipeNumber">Номер трубопровода</param>
        private void AddFinalInstantPipeToArchives(int pipeNumber)
        {
            byte[] buf = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            // объем, нарастающим итогом
            var v = BitConverter.ToDouble(new[] {buf[4], buf[3], buf[6], buf[5], buf[8], buf[7], buf[10], buf[9]}, 0);
            v = double.IsNaN(v) ? 0 : v;
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal) v,
                DeviceParameterId = GetSumParamId("V", pipeNumber)
            }));

            // масса, нарастающим итогом
            var m = BitConverter.ToDouble(
                new[] { buf[12], buf[11], buf[14], buf[13], buf[16], buf[15], buf[18], buf[17] }, 0);
            m = double.IsNaN(m) ? 0 : m;
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal) m,
                DeviceParameterId = GetSumParamId("M", pipeNumber)
            }));
        }

        /// <summary>
        /// Добавляет в локальную коллекцию архивов текущие итоговые по тепловому вводу
        /// </summary>
        /// <param name="tvNumber">Номер теплового ввода (1 или 2)</param>
        private void AddFinalInstantTvToArchives(int tvNumber)
        {
            byte[] buf = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            // разность масс нарастающим итогом
            var dM = BitConverter.ToDouble(new[] { buf[4], buf[3], buf[6], buf[5], buf[8], buf[7], buf[10], buf[9] }, 0);
            dM = double.IsNaN(dM) ? 0 : dM;
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)dM,
                DeviceParameterId = GetSumParamId("dM", tvNumber)
            }));

            // тепло по тепловому вводу нарастающим итогом
            var qtv = BitConverter.ToDouble(new[] { buf[12], buf[11], buf[14], buf[13], buf[16], buf[15], buf[18], buf[17] }, 0);
            qtv = double.IsNaN(qtv) ? 0 : qtv;
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)qtv,
                DeviceParameterId = GetSumParamId("Qtv", tvNumber)
            }));

            // тепло контура труб 1,2 нарастающим итогом
            var q12 =
                BitConverter.ToDouble(new[] { buf[20], buf[19], buf[22], buf[21], buf[24], buf[23], buf[26], buf[25] }, 0);
            q12 = double.IsNaN(q12) ? 0 : q12;
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)q12,
                DeviceParameterId = GetSumParamId("Q12", tvNumber)
            }));

            // тепло горячего водоснабжения нарастающим итогом
            var qG = BitConverter.ToDouble(new[] { buf[28], buf[27], buf[30], buf[29], buf[32], buf[31], buf[34], buf[33]}, 0);
            qG = double.IsNaN(qG) ? 0 : qG;
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)qG,
                DeviceParameterId = GetSumParamId("Qg", tvNumber)
            }));

            // время нормальной работы нарастающим итогом
            var tNorm = BitConverter.ToInt16(new[] { buf[36], buf[35] }, 0);
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)tNorm,
                DeviceParameterId = GetSumParamId("Tnorm", tvNumber)
            }));

            // время отсутствия счета нарастающим итогом
            var tDen = BitConverter.ToInt16(new[] { buf[38], buf[37] }, 0);
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)tDen,
                DeviceParameterId = GetSumParamId("Tden", tvNumber)
            }));

            // время при НС V<min нарастающим итогом
            var tVmin = BitConverter.ToInt16(new[] { buf[40], buf[39] }, 0);
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)tVmin,
                DeviceParameterId = GetSumParamId("TVmin", tvNumber)
            }));

            // время при НС V>max нарастающим итогом
            var tVmax = BitConverter.ToInt16(new[] { buf[42], buf[41] }, 0);
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)tVmax,
                DeviceParameterId = GetSumParamId("TVmax", tvNumber)
            }));

            // время при НС по dt нарастающим итогом
            var tdt = BitConverter.ToInt16(new[] { buf[44], buf[43] }, 0);
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)tdt,
                DeviceParameterId = GetSumParamId("Tdt", tvNumber)
            }));

            // время отключения внешнего сетевого питания нарастающим итогом
            var tPo = BitConverter.ToInt16(new[] { buf[46], buf[45] }, 0);
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)tPo,
                DeviceParameterId = GetSumParamId("Tpo", tvNumber)
            }));

            // время неисправности t1 или t2
            var ttDen = BitConverter.ToInt16(new[] {buf[48], buf[47]}, 0);
            LocalArchives.Add(ArchiveCollector.CreateFinalInstantArchives(new ValueInfo
            {
                Value = (decimal)ttDen,
                DeviceParameterId = GetSumParamId("Ttden", tvNumber)
            }));
        }
    }
}


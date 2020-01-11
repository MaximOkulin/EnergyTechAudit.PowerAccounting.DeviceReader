using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7
{
    public partial class Tv7
    {

        private void ReadInstantTemparaturesAndPressures()
        {
            int paramsCount = _isNewFirmware ? 7 : 6;

            if (_isNewFirmware) { _actionSteps.GetInstantTemperaturesAndPressuresNewFirmware(); } 
            else { _actionSteps.GetInstantTemperaturesAndPressures(); }
            byte[] buf = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            LocalArchives.Clear();

            for (var channelNumber = 1; channelNumber <= paramsCount; channelNumber++)
            {
                var offset = (channelNumber - 1) * 4;
                // средние температуры по трубам
                var t = BitConverter.ToSingle(new[] { buf[4 + offset], buf[3 + offset], buf[6 + offset], buf[5 + offset] }, 0);
                t = float.IsNaN(t) ? 0 : t;
                LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                {
                    Value = (decimal)t,
                    DeviceParameterId = GetParamId(Resources.Common.t, channelNumber)
                }, false));

                var offset2 = offset + paramsCount * 4 + 4;

                // средние давления по трубам
                var p = BitConverter.ToSingle(new[] { buf[offset2], buf[offset2 - 1], buf[offset2 + 2], buf[offset2 + 1] }, 0);
                p = float.IsNaN(p) ? 0 : p;
                LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                {
                    Value = (decimal)p,
                    DeviceParameterId = GetParamId(Resources.Common.P, channelNumber)
                }, false));
            }
        }

        private void ReadInstantFlows()
        {
            int paramsCount = _isNewFirmware ? 7 : 6;

            if (_isNewFirmware) { _actionSteps.GetInstantFlowsNewFirmware(); } 
            else { _actionSteps.GetInstantFlows(); }

            byte[] buf = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            for (var channelNumber = 1; channelNumber <= paramsCount; channelNumber++)
            {
                var offset = (channelNumber - 1) * 4;
                // средние объемные расходы по трубам
                var go = BitConverter.ToSingle(new[] { buf[4 + offset], buf[3 + offset], buf[6 + offset], buf[5 + offset] }, 0);
                go = float.IsNaN(go) ? 0 : go;
                LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                {
                    Value = (decimal)go,
                    DeviceParameterId = GetParamId(Resources.Common.Go, channelNumber)
                }, false));

                var offset2 = offset + paramsCount * 4 + 4;

                // средние массовые расходы по трубам
                var gm = BitConverter.ToSingle(new[] { buf[offset2], buf[offset2 - 1], buf[offset2 + 2], buf[offset2 + 1] }, 0);
                gm = float.IsNaN(gm) ? 0 : gm;
                LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
                {
                    Value = (decimal)gm,
                    DeviceParameterId = GetParamId(Resources.Common.Gm, channelNumber)
                }, false));
            }             
        }

        private void ReadInstantThermalPowersAndEnthalpiesPipes()
        {
            int paramsCount = _isNewFirmware ? 7 : 6;

            if (_isNewFirmware) { _actionSteps.GetInstantThermalPowersAndEnthalpiesPipesNewFirmware(); }
            else { _actionSteps.GetInstantThermalPowersAndEnthalpiesPipes(); }
            byte[] buf = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            for (var channelNumber = 1; channelNumber <= paramsCount; channelNumber++)
            {

            }
                // средние тепловые потоки по отдельным трубам
                var f1 = BitConverter.ToSingle(new[] { buf[4], buf[3], buf[6], buf[5] }, 0);
            f1 = float.IsNaN(f1) ? 0 : f1;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)f1,
                DeviceParameterId = GetParamId("F", 1)
            }, false));

            var f2 = BitConverter.ToSingle(new[] { buf[8], buf[7], buf[10], buf[9] }, 0);
            f2 = float.IsNaN(f2) ? 0 : f2;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)f2,
                DeviceParameterId = GetParamId("F", 2)
            }, false));

            var f3 = BitConverter.ToSingle(new[] { buf[12], buf[11], buf[14], buf[13] }, 0);
            f3 = float.IsNaN(f3) ? 0 : f3;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)f3,
                DeviceParameterId = GetParamId("F", 3)
            }, false));

            var f4 = BitConverter.ToSingle(new[] { buf[16], buf[15], buf[18], buf[17] }, 0);
            f4 = float.IsNaN(f4) ? 0 : f4;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)f4,
                DeviceParameterId = GetParamId("F", 4)
            }, false));

            var f5 = BitConverter.ToSingle(new[] { buf[20], buf[19], buf[22], buf[21] }, 0);
            f5 = float.IsNaN(f5) ? 0 : f5;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)f5,
                DeviceParameterId = GetParamId("F", 5)
            }, false));

            var f6 = BitConverter.ToSingle(new[] { buf[24], buf[23], buf[26], buf[25] }, 0);
            f6 = float.IsNaN(f6) ? 0 : f6;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)f6,
                DeviceParameterId = GetParamId("F", 6)
            }, false));

            // средние значения энтальпии по отдельным трубам
            var h1 = BitConverter.ToSingle(new[] { buf[28], buf[27], buf[30], buf[29] }, 0);
            h1 = float.IsNaN(h1) ? 0 : h1;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)h1,
                DeviceParameterId = GetParamId("h", 1)
            }, false));

            var h2 = BitConverter.ToSingle(new[] { buf[32], buf[31], buf[34], buf[33] }, 0);
            h2 = float.IsNaN(h2) ? 0 : h2;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)h2,
                DeviceParameterId = GetParamId("h", 2)
            }, false));

            var h3 = BitConverter.ToSingle(new[] { buf[36], buf[35], buf[38], buf[37] }, 0);
            h3 = float.IsNaN(h3) ? 0 : h3;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)h3,
                DeviceParameterId = GetParamId("h", 3)
            }, false));

            var h4 = BitConverter.ToSingle(new[] { buf[40], buf[39], buf[42], buf[41] }, 0);
            h4 = float.IsNaN(h4) ? 0 : h4;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)h4,
                DeviceParameterId = GetParamId("h", 4)
            }, false));

            var h5 = BitConverter.ToSingle(new[] { buf[44], buf[43], buf[46], buf[45] }, 0);
            h5 = float.IsNaN(h5) ? 0 : h5;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)h5,
                DeviceParameterId = GetParamId("h", 5)
            }, false));

            var h6 = BitConverter.ToSingle(new[] { buf[48], buf[47], buf[50], buf[49] }, 0);
            h6 = float.IsNaN(h6) ? 0 : h6;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)h6,
                DeviceParameterId = GetParamId("h", 6)
            }, false));
        }

        private void ReadInstantThermalPowersAndEnthalpiesHeatInput()
        {
            _actionSteps.GetInstantThermalPowersAndEnthalpiesHeatInput();
            byte[] buf = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            // тепловые потоки по тепловым вводам
            var ftv1 = BitConverter.ToSingle(new[] { buf[4], buf[3], buf[6], buf[5] }, 0);
            ftv1 = float.IsNaN(ftv1) ? 0 : ftv1;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)ftv1,
                DeviceParameterId = GetParamId("Ftv", 1)
            }, false));

            var ftv2 = BitConverter.ToSingle(new[] { buf[8], buf[7], buf[10], buf[9] }, 0);
            ftv2 = float.IsNaN(ftv2) ? 0 : ftv2;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)ftv2,
                DeviceParameterId = GetParamId("Ftv", 2)
            }, false));

            // энтальпии холодной воды по тепловым вводам
            var hx1 = BitConverter.ToSingle(new[] { buf[12], buf[11], buf[14], buf[13] }, 0);
            hx1 = float.IsNaN(hx1) ? 0 : hx1;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)hx1,
                DeviceParameterId = GetParamId("hx", 1)
            }, false));

            var hx2 = BitConverter.ToSingle(new[] { buf[16], buf[15], buf[18], buf[17] }, 0);
            hx2 = float.IsNaN(hx2) ? 0 : hx2;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)hx2,
                DeviceParameterId = GetParamId("hx", 2)
            }, false));

            var ap = BitConverter.ToSingle(new[] { buf[20], buf[19], buf[22], buf[21] }, 0);
            ap = float.IsNaN(ap) ? 0 : ap;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)ap,
                DeviceParameterId = GetParamId("AP", 0)
            }, false));
        }

        private void ReadInstantHeatInputParameters()
        {
            _actionSteps.GetInstantHeatInputParameters();
            byte[] buf = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

            // значения температуры холодной воды в тепловых вводах
            var tx1 = BitConverter.ToSingle(new[] { buf[4], buf[3], buf[6], buf[5] }, 0);
            tx1 = float.IsNaN(tx1) ? 0 : tx1;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)tx1,
                DeviceParameterId = GetParamId("tx", 1)
            }, false));

            var tx2 = BitConverter.ToSingle(new[] { buf[8], buf[7], buf[10], buf[9] }, 0);
            tx2 = float.IsNaN(tx2) ? 0 : tx2;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)tx2,
                DeviceParameterId = GetParamId("tx", 2)
            }, false));

            // значения давления холодной воды в тепловых вводах
            var px1 = BitConverter.ToSingle(new[] { buf[12], buf[11], buf[14], buf[13] }, 0);
            px1 = float.IsNaN(px1) ? 0 : px1;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)px1,
                DeviceParameterId = GetParamId("Px", 1)
            }, false));

            var px2 = BitConverter.ToSingle(new[] { buf[16], buf[15], buf[18], buf[17] }, 0);
            px2 = float.IsNaN(px2) ? 0 : px2;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)px2,
                DeviceParameterId = GetParamId("Px", 2)
            }, false));

            // значения разности температур в тепловых вводах
            var dt1 = BitConverter.ToSingle(new[] { buf[20], buf[19], buf[22], buf[21] }, 0);
            dt1 = float.IsNaN(dt1) ? 0 : dt1;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)dt1,
                DeviceParameterId = GetParamId("dt", 1)
            }, false));

            var dt2 = BitConverter.ToSingle(new[] { buf[24], buf[23], buf[26], buf[25] }, 0);
            dt2 = float.IsNaN(dt2) ? 0 : dt2;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)dt2,
                DeviceParameterId = GetParamId("dt", 2)
            }, false));

            // значения температур наружного воздуха в тепловых вводах
            var toa1 = BitConverter.ToSingle(new[] { buf[28], buf[27], buf[30], buf[29] }, 0);
            toa1 = float.IsNaN(toa1) ? 0 : toa1;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)toa1,
                DeviceParameterId = GetParamId("toa", 1)
            }, false));

            // testComment
            var toa2 = BitConverter.ToSingle(new[] { buf[32], buf[31], buf[34], buf[33] }, 0);
            toa2 = float.IsNaN(toa2) ? 0 : toa2;
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)toa2,
                DeviceParameterId = GetParamId("toa", 2)
            }, false));
        }

        /// <summary>
        /// Чтение мгновенных значений
        /// </summary>
        private void ReadInstantArchives()
        {
            RaiseTraceInfoPassedEvent(DeviceMessages.Tv7ReadInstantTemperaturesAndPressures);
            ReadInstantTemparaturesAndPressures();
            RaiseTraceInfoPassedEvent(DeviceMessages.Tv7ReadInstantFlows);
            ReadInstantFlows();
            RaiseTraceInfoPassedEvent(DeviceMessages.Tv7ReadInstantThermalPowersAndEnthalpiesPipes);
            ReadInstantThermalPowersAndEnthalpiesPipes();
            RaiseTraceInfoPassedEvent(DeviceMessages.Tv7ReadInstantThermalPowersAndEnthalpiesHeatInput);
            ReadInstantThermalPowersAndEnthalpiesHeatInput();
            RaiseTraceInfoPassedEvent(DeviceMessages.Tv7ReadInstantHeatInputParameters);
            ReadInstantHeatInputParameters();

            // текущее время прибора
            LocalArchives.Add(ArchiveCollector.CreateInstantArchives(new ValueInfo
            {
                Value = (decimal)DeviceTime.ToOADate(),
                DeviceParameterId = 7215
            }, false));
        }
    }
}

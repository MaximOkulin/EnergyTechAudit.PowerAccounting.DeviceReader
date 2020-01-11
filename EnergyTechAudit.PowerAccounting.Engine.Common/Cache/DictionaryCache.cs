using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using System.Collections.Generic;
using System.Linq;
using res = EnergyTechAudit.PowerAccounting.DeviceReader.Resources.DictionariesCache;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Cache
{
    public class DictionaryCache
    {
        public List<Parity> Parities = new List<Parity>
        {
            new Parity  {  Id = 1, Code = res.None, Description = res.ParityNone  },
            new Parity  {  Id = 2, Code = res.Odd, Description = res.ParityOdd },
            new Parity  {  Id = 3, Code = res.Even, Description = res.ParityEven },
            new Parity  {  Id = 4, Code = res.Mark, Description = res.ParityMark },
            new Parity  {  Id = 5, Code = res.Space, Description = res.ParitySpace },
            new Parity  {  Id = 6, Code = res.Empty, Description = res.Absent }
        };

        public string GetParityCode(int id)
        {
            return Parities.First(p => p.Id == id).Code;
        }

        public List<DataBit> DataBits = new List<DataBit>
        {
            new DataBit { Id = 1, Code = res.Seven, Description = res.DataBit7 },
            new DataBit { Id = 2, Code = res.Eight, Description = res.DataBit8 },
            new DataBit { Id = 3, Code = res.Five, Description = res.DataBit5 },
            new DataBit { Id = 4, Code = res.Six, Description = res.DataBit6 },
            new DataBit { Id = 5, Code = res.Empty, Description = res.Absent },
            new DataBit { Id = 6, Code = res.Nine, Description = res.DataBit9 }
        };

        public string GetDataBitCode(int id)
        {
            return DataBits.First(p => p.Id == id).Code;
        }

        public List<Baud> Bauds = new List<Baud>
        {
            new Baud { Id = 1, Code = res.None, Description = res.Absent },
            new Baud { Id = 2, Code = res.Number1200, Description = res.Baud1200 },
            new Baud { Id = 3, Code = res.Number2400, Description = res.Baud2400 },
            new Baud { Id = 4, Code = res.Number4800, Description = res.Baud4800 },
            new Baud { Id = 5, Code = res.Number9600, Description = res.Baud9600 },
            new Baud { Id = 6, Code = res.Number14400, Description = res.Baud14400 },
            new Baud { Id = 7, Code = res.Number19200, Description = res.Baud19200 },
            new Baud { Id = 8, Code = res.Number28800, Description = res.Baud28800 },
            new Baud { Id = 9, Code = res.Number38400, Description = res.Baud38400 },
            new Baud { Id = 10, Code = res.Number57600, Description = res.Baud57600 },
            new Baud { Id = 11, Code = res.Number115200, Description = res.Baud115200 },
            new Baud { Id = 12, Code = res.Number230400, Description = res.Baud230400 },
            new Baud { Id = 13, Code = res.Number300, Description = res.Baud300 }
        };

        public string GetBaudCode(int id)
        {
            return Bauds.First(p => p.Id == id).Code;
        }

        public List<StopBit> StopBits = new List<StopBit>
        {
            new StopBit { Id = 1, Code = res.None, Description = res.StopBitNone },
            new StopBit { Id = 2, Code = res.One, Description = res.StopBitOne },
            new StopBit { Id = 3, Code = res.Two, Description = res.StopBitTwo },
            new StopBit { Id = 4, Code = res.OnePointFive, Description = res.StopBitOnePointFive },
            new StopBit { Id = 5, Code = res.Empty, Description = res.Absent }
        };

        public string GetStopBitCode(int id)
        {
            return StopBits.First(p => p.Id == id).Code;
        }


        public List<ComPort> ComPorts = new List<ComPort>
        {
            new ComPort { Id = 1, Code = res.Empty, Description = res.Absent },
            new ComPort { Id = 2, Code = res.Com1, Description = res.Com1Name },
            new ComPort { Id = 3, Code = res.Com2, Description = res.Com2Name },
            new ComPort { Id = 4, Code = res.Com3, Description = res.Com3Name },
            new ComPort { Id = 5, Code = res.Com4, Description = res.Com4Name },
            new ComPort { Id = 6, Code = res.Com5, Description = res.Com5Name },
            new ComPort { Id = 7, Code = res.Com6, Description = res.Com6Name },
            new ComPort { Id = 8, Code = res.Com7, Description = res.Com7Name },
            new ComPort { Id = 9, Code = res.Com8, Description = res.Com8Name },
            new ComPort { Id = 10, Code = res.Com9, Description = res.Com9Name },
            new ComPort { Id = 11, Code = res.Com10, Description = res.Com10Name },
            new ComPort { Id = 12, Code = res.Com11, Description = res.Com11Name },
            new ComPort { Id = 13, Code = res.Com12, Description = res.Com12Name },
            new ComPort { Id = 14, Code = res.Com13, Description = res.Com13Name }
        };

        public string GetComPortDescription(int id)
        {
            return ComPorts.First(p => p.Id == id).Description;
        }

        public string GetComPortCode(int id)
        {
            return ComPorts.First(p => p.Id == id).Code;
        }

        public List<PortType> PortTypes = new List<PortType>
        {
            new PortType { Id = 1, Code = res.RS232, Description = res.RS232Desc },
            new PortType { Id = 2, Code = res.RS232Power, Description = res.RS232PowerDesc },
            new PortType { Id = 3, Code = res.RS485_2Wire, Description = res.RS485_2WireDesc },
            new PortType { Id = 4, Code = res.RS485_4Wire, Description = res.RS485_4WireDesc },
            new PortType { Id = 5, Code = res.RS422, Description = res.RS422Desc }
        };

        public string GetPortTypeCode(int id)
        {
            return PortTypes.First(p => p.Id == id).Code;
        }

        public List<TransportServerModel> TransportServerModels = new List<TransportServerModel>
        {
            new TransportServerModel { Id = 1, Code = res.None, Description = res.None },
            new TransportServerModel { Id = 2, Code = res.Moxa5110, Description = res.None },
            new TransportServerModel { Id = 3, Code = res.Maestro, Description = res.None },
            new TransportServerModel { Id = 4, Code = res.Gammy, Description = res.None },
            new TransportServerModel { Id = 5, Code = res.MoxaOnCellG2111, Description = res.None },
            new TransportServerModel { Id = 6, Code = res.Bars02, Description = res.None },
            new TransportServerModel { Id = 7, Code = res.SbtEthernet, Description = res.None },
            new TransportServerModel { Id = 8, Code = res.Moxa5150A, Description = res.None },
            new TransportServerModel { Id = 9, Code = res.WIZ107SR, Description = res.None },
            new TransportServerModel { Id = 10, Code = res.WIZ108SR, Description = res.None },
            new TransportServerModel { Id = 11, Code = res.Bars02PXM, Description = res.None },
            new TransportServerModel { Id = 12, Code = res.Moxa5150, Description = res.None },
            new TransportServerModel { Id = 13, Code = res.Bars02WXM, Description = res.None },
            new TransportServerModel { Id = 14, Code = res.I7188, Description = res.None },
            new TransportServerModel { Id = 15, Code = res.Moxa5250A, Description = res.None },
            new TransportServerModel { Id = 16, Code = res.iRZATM2_232, Description = res.None },
            new TransportServerModel { Id = 17, Code = res.iRZATM2_485, Description = res.None },
            new TransportServerModel { Id = 18, Code = res.LersGsmPlus, Description = res.None },
            new TransportServerModel { Id = 19, Code = res.LersGsmLite, Description = res.None },
            new TransportServerModel { Id = 20, Code = res.Moxa5650_8, Description = res.None },
            new TransportServerModel { Id = 21, Code = res.LogikaAds99, Description = res.None },
            new TransportServerModel { Id = 22, Code = res.EtaModem, Description = res.None },
            new TransportServerModel { Id = 23, Code = res.iRZ_MC52iT, Description = res.None },
            new TransportServerModel { Id = 24, Code = res.Tbn_KSPD5G_old, Description = res.None },
            new TransportServerModel { Id = 25, Code = res.Tbn_KSPD5G_new, Description = res.None },
            new TransportServerModel { Id = 26, Code = res.Virtual, Description = res.None },
            new TransportServerModel { Id = 27, Code = res.PulsarGsmModem, Description = res.None },
            new TransportServerModel { Id = 28, Code = res.Bars02_Old, Description = res.None },
            new TransportServerModel { Id = 29, Code = res.LoraNetServer, Description = res.None },
            new TransportServerModel { Id = 30, Code = res.Strij, Description = res.None }
        };

        public string GetTransportServerModelCode(int id)
        {
            return TransportServerModels.First(p => p.Id == id).Code;
        }
    }
}

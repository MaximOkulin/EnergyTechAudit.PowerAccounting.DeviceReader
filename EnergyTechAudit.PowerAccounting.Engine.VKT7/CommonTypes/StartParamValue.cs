using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.CommonTypes
{
    public class StartParamValue
    {
        public string ParameterCode { get; set; }
        public decimal StartValue { get; set; }
        public DateTime Time { get; set; }
        public List<PeriodType> PeriodTypes { get; set; }
    }
}

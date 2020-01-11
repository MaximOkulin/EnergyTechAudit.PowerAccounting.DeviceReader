using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public class DoubleToDecimalConvertResult
    {
        public decimal Value { get; set; }
        public bool IsValid { get; set; }
    }
}

using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public class MnemoschemeParametersInfo
    {
        public List<MnemoschemeParameter> Parameters;
        public int[] MeasurementDevices;
        public bool IsPartialUpdateKey;
    }
}

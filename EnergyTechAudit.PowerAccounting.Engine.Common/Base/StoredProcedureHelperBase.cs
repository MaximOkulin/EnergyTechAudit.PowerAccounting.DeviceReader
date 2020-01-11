using EnergyTechAudit.PowerAccounting.LightDataAccess;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base
{
    public class StoredProcedureHelperBase
    {
        protected readonly LightDatabaseContext Context;
        protected readonly int MeasurementDeviceId;

        public StoredProcedureHelperBase(LightDatabaseContext context, int measurementDeviceId)
        {
            Context = context;
            MeasurementDeviceId = measurementDeviceId;
        }
    }
}

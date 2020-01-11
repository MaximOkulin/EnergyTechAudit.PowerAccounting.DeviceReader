using System;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces
{
    public interface ISuccessConnectionPercent
    {
        double SuccessConnectionPercent { get; set; }

        DateTime LastConnectionTime { get; set; }
    }
}

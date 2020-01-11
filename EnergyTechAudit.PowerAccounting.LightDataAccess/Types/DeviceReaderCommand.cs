namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Types
{
    public class DeviceReaderCommand
    {
        public string Name { get; set; }

        public bool IsRequireControlService { get; set; }

        public bool IsEntityIndependent { get; set; }
    }
}

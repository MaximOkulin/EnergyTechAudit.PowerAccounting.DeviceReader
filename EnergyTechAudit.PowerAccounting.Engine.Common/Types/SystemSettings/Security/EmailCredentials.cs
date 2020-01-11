namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.SystemSettings.Security
{
    public class EmailCredentials : Credentials
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

    }
}

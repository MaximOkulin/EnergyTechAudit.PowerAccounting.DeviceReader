namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces
{
    public interface ICryptoMethodsProvider
    {
        string GetHashString(string source);

        byte[] ProtectData(byte[] clearText);

        byte[] UnprotectData(byte[] encryptedText);
    }
}

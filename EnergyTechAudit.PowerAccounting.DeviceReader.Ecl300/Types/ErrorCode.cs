namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Types
{
    public enum ErrorCode : byte
    {
        NormalAnswer = 0x02,
        UnknownValue = 0x00, 
        InvalidValueDate = 0x10,
        NonExistingCircuit = 0x20,
        NonExistingMode = 0x30,
        NonExistingPort = 0x40,
        CommunicationError = 0xF0
    }
}

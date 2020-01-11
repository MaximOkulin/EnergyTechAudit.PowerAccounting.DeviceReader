namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy
{
    public enum ErrorType
    {
        Unknown = 1,
        ErrorDeviceResponse = 2,
        OpenSerialPortError = 3,
        TransportServerConfigurationError = 4,
        ConnectionError = 5,
        MissingAccessPoint = 6,
        ManualResetPolling = 7,
        WrongMakeCallException = 8,
        WrongFactoryNumberException = 9,
        SpecificDeviceError = 10,
        StartSignalrError = 11,
        AssemblyNotFound = 12,
        ServerDispatcherInitError = 13,
        PollingError = 14,
        MissingUnitConverter = 15,
        DbTransactionReadUncommitted = 16,
        Vkt7SaveArchiveError = 17,
        Esko06WrongResponseCommand = 18,
        Ecl300ErrorResponse = 19,
        MagikaOldGateVersion = 20,
        MagikaGateVersionWithBugs = 21,
        MagikaTemplateDeviceParameterNotFound = 22,
        Mercury230WrongDayStartValues = 23
    }
}

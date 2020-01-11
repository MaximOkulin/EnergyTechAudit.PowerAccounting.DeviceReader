namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    /// <summary>
    /// Структура для хранения значений энергии
    /// </summary>
    public struct PowerValues
    {
        private readonly decimal _tariff0;
        private readonly decimal _tariff1;
        private readonly decimal _tariff2;
        private readonly decimal _tariff3;
        private readonly decimal _tariff4;
        private readonly decimal _tariff5;

        public decimal Tariff0 { get { return _tariff0; } }
        public decimal Tariff1 { get { return _tariff1; } }
        public decimal Tariff2 { get { return _tariff2; } }
        public decimal Tariff3 { get { return _tariff3; } }
        public decimal Tariff4 { get { return _tariff4; } }
        public decimal Tariff5 { get { return _tariff5; } }

        public PowerValues(decimal tariff0, decimal tariff1, decimal tariff2, decimal tariff3, decimal tariff4, decimal tariff5)
        {
            _tariff0 = tariff0;
            _tariff1 = tariff1;
            _tariff2 = tariff2;
            _tariff3 = tariff3;
            _tariff4 = tariff4;
            _tariff5 = tariff5;
        }
    }
}

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public enum CalcType
    {
        /// <summary>
        /// Согласно алгоритму
        /// </summary>
        Native = 0,
        /// <summary>
        /// За последние сутки
        /// </summary>
        LastDay = 1,
        /// <summary>
        /// За последнюю неделю
        /// </summary>
        LastWeek = 2,
        /// <summary>
        /// За последний месяц
        /// </summary>
        LastMonth = 3,
        /// <summary>
        /// Применено значение по умолчанию
        /// </summary>
        Default = 4
    }
}

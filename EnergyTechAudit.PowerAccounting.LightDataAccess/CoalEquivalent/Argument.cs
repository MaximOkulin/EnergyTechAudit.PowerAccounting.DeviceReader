namespace EnergyTechAudit.PowerAccounting.LightDataAccess.CoalEquivalent
{
    public class Argument
    {
        public int MeasurementDeviceId { get; set; }
        /// <summary>
        /// Идентификатор исходного девайсового параметра
        /// </summary>
        public int SourceDeviceParameterId { get; set; }
        /// <summary>
        /// Идентификатор девайсового параметра, в который будет сохранено рассчитанное значение
        /// </summary>
        public int ArchiveDeviceParameterId { get; set; }
        /// <summary>
        /// Идентификатор девайсового параметра, в который будет сохранен тип расчета
        /// </summary>
        public int CalcTypeDeviceParameterId { get; set; }
        /// <summary>
        /// Тип периода архива, на основании которого будет производиться поиск и расчет
        /// </summary>
        public int PeriodTypeId { get; set; }
        /// <summary>
        /// Значение по умолчанию, которое будет применено в случае неудачного расчета
        /// </summary>
        public decimal DefaultValue { get; set; }
        /// <summary>
        /// Является ли текущий параметр дифференсом
        /// </summary>
        public bool IsDiffValue { get; set; }
        /// <summary>
        /// Название параметра, которое будет участвовать в результирующем выражении
        /// </summary>
        public string ScopeParameterName { get; set; }
        /// <summary>
        /// Модель прибора
        /// </summary>
        public int DeviceModelId { get; set; }
    }
}

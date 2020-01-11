using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    /// <summary>
    /// Обертка значения измеряемого параметра 
    /// </summary>
    public class ValueInfo : ICloneable
    {
        public PeriodType PeriodType { get; set; }
        public DateTime Time { get; set; }
        public decimal Value { get; set; }
        public bool IsValid { get; set; }
        public int MeasurementDeviceId { get; set; }
        public int DeviceParameterId { get; set; }

        public bool IsSeriesEnd { get; set; }

        public ValueInfo()
        {
            IsValid = true;
            IsSeriesEnd = false;
        }

        private readonly Archive _archive;
        /// <summary>
        /// Конструктор для приведения к типу Business.Archive
        /// </summary>
        /// <param name="archive"></param>
        public ValueInfo(Archive archive)
        {
            _archive = archive;
        }

        public Archive ToArchive()
        {
            return new Archive {
                Value = Value,
                MeasurementDeviceId = MeasurementDeviceId,
                DeviceParameterId = DeviceParameterId,
                PeriodTypeId = (int)PeriodType,
                IsValid = IsValid,
                Time = Time
            };
        }

        public static implicit operator ValueInfo(Archive a)
        {
            return new ValueInfo
            {
                Value = a.Value,
                MeasurementDeviceId = a.MeasurementDeviceId,
                DeviceParameterId = a.DeviceParameterId,
                PeriodType = (PeriodType)a.PeriodTypeId,
                IsValid = a.IsValid,
                Time = a.Time
            };
        }

        public static explicit operator Archive(ValueInfo vi)
        {
            return vi.ToArchive();
        }

        /// <summary>
        /// Устанавливает значение и параметр
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="parameter">Параметр прибора</param>
        public void SetValueAndParameter(double value, DeviceParameter parameter)
        {
            Value = (decimal)value;
            DeviceParameterId = (int)parameter;
        }

        /// <summary>
        /// Устанавливает значение и параметр
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="parameter">Параметр прибора</param>
        public void SetValueAndParameter(decimal value, DeviceParameter parameter)
        {
            Value = value;
            DeviceParameterId = (int)parameter;
        }

        public object Clone()
        {
            return new ValueInfo
            {
                PeriodType = PeriodType,
                Time = Time,
                Value = Value,
                IsValid = IsValid,
                IsSeriesEnd = IsSeriesEnd
            };
        }


    }
}

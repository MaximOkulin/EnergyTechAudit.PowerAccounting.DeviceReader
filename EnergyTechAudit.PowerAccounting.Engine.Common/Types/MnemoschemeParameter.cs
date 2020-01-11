using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public class MnemoschemeParameter
    {
        public int ChannelId { get; set; }
        public int ChannelTemplateId { get; set; }
        public int DeviceId { get; set; }
        public string DictionaryValueCode { get; set; }
        public string DictionaryValueDescription { get; set; }
        public string DimensionPrefix { get; set; }
        public int Id { get; set; }
        public int MeasurementDeviceId { get; set; }
        public string MeasurementUnitDescription { get; set; }
        public string ParameterCode { get; set; }
        public string ParameterDescription { get; set; }
        public string PhysicalParameterCode { get; set; }
        public DateTime Time { get; set; }
        public decimal Value { get; set; }
        public bool IsValid { get; set; }
    }
}

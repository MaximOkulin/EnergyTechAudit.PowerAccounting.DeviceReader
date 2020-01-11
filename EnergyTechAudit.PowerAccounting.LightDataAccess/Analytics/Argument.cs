using EnergyTechAudit.PowerAccounting.LightDataAccess.EnumTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics
{
    public class Argument
    {
        public string ParameterName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PeriodType PeriodType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Operation Operation { get; set; }
        public int? Interval { get; set; }
        public int? DeviceTimeTolerance { get; set; }
        public string ScopeParameterName { get; set; }
        public string TargetMeasurementUnit { get; set; }
        public string TargetDimension { get; set; }
        public decimal TargetDimensionCoef { get; set; }
        public List<SurrogateArgument> SurrogateArguments { get; set; }

        public bool UseParameterDictionary { get; set; }

        public bool HasIdenticalInList(List<Argument> list)
        {
            if (list.Any(destParam => destParam.ScopeParameterName.Equals(ScopeParameterName) && destParam.PeriodType == PeriodType &&
                                      destParam.Operation == Operation && destParam.Interval == Interval && destParam.DeviceTimeTolerance == DeviceTimeTolerance))
            {
                return true;
            }
            return false;
        }
    }
}

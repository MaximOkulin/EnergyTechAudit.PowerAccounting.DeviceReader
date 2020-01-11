using EnergyTechAudit.PowerAccounting.LightDataAccess.EnumTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using PeriodType = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.PeriodType;


namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types
{
    public class ParameterArgument
    {
        public string ParameterName { get; set; }
        public PeriodType PeriodType { get; set; }
        public Operation Operation { get; set; }
        public int? Interval { get; set; }
        public string ScopeParameterName { get; set; }

        public ParameterArgument(string parameterName, string[] paramsString)
        {
            ParameterName = parameterName;

            PeriodType = (PeriodType)Enum.Parse(typeof (PeriodType), paramsString[0]);

            if (paramsString.Length > 1)
            {
                Interval = Convert.ToInt32(paramsString[1]);
                Operation = (Operation)Enum.Parse(typeof (Operation), paramsString[2]);
            }

            CalculateScopeParameterName();
        }

        public bool HasIdenticalInList(List<ParameterArgument> list)
        {
            return list.Any(destParam => destParam.ParameterName.Equals(ParameterName) && destParam.PeriodType == PeriodType &&
                                         destParam.Operation == Operation && destParam.Interval == Interval);
        }

        private void CalculateScopeParameterName()
        {
            var stringBuilder = new List<string>();
            stringBuilder.Add(ParameterName.Replace(".", "_"));
            stringBuilder.Add(Convert.ToString(PeriodType));

            if (Interval != null)
            {
                stringBuilder.Add(Convert.ToString(Interval.Value));
            }

            if (Operation != Operation.None)
            {
                stringBuilder.Add(Convert.ToString(Operation));
            }

            ScopeParameterName = String.Join("_", stringBuilder);
        }
    }
}

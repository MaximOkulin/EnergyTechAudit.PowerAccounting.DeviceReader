using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types
{
    public class ParseExpressionResult
    {
        public string TransformedPredicateExpression { get; set; }

        public List<ParameterArgument> ParameterArguments { get; set; }
    }
}

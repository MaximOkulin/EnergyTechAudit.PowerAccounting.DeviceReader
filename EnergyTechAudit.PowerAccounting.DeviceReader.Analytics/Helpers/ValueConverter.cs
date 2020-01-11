using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Helpers
{
    public class ValueConverter
    {
        public void ConvertValue(ScopeValue scopeValue)
        {
            if(scopeValue.Value != null && scopeValue.IsNeedToConvertUnit)
            {
                if(scopeValue.MeasurementUnitConverter != null)
                {
                    var scriptScope = CreateScriptEngineScope(scopeValue.Value.Value);
                    
                    var source = scriptScope.Engine.CreateScriptSourceFromString(scopeValue.MeasurementUnitConverter.Expression);

                    try
                    {
                        scopeValue.Value = Convert.ToDecimal(source.Execute(scriptScope));
                    }
                    catch
                    {
                        // зануляем значение, так как оно вычислилось с ошибкой
                        scopeValue.Value = null;
                    }
                }
                else
                {
                    // зануляем значение, так как оно без конвертации некорректно
                    scopeValue.Value = null;
                }
            }

            if(scopeValue.Value != null && scopeValue.IsNeedToConvertDimension)
            {
                scopeValue.Value = scopeValue.Value * scopeValue.DeviceParameterDimensionCoef / scopeValue.Argument.TargetDimensionCoef;
            }
        }

        private ScriptScope CreateScriptEngineScope(decimal value)
        {
            var scriptEngine = Python.CreateEngine();
            var scriptScope = scriptEngine.CreateScope();

            scriptScope.SetVariable("x", value);

            return scriptScope;
        }
    }
}

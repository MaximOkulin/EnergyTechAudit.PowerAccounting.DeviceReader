using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.Parsers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using System;
using System.Linq;
using System.Reflection;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.Applications
{
    internal class Application : ApplicationBase
    {
        protected ActionSteps ActionSteps;
        protected ParserBase ParserBase;


        public void Init(Common.Logic.Device device, ActionSteps actionSteps,
            DynamicParameterHelper dynamicParameterHelper)
        {
            Init(device, dynamicParameterHelper);

            ActionSteps = actionSteps;

            ParserBase = new ParserBase(actionSteps.Transport, MeasurementDevice);
        }

        protected override MethodInfo GetSetMethod(string paramName)
        {
            MethodInfo result = null;

            // ищем сначал среди общих методов
            result = typeof(ActionSteps).GetMethods().FirstOrDefault(mi => mi.Name.Equals(string.Format(StringFormat.Set, paramName), StringComparison.Ordinal));

            // если среди общих не нашли, то пытаемся найти среди специфичных для текущего ключа
            if (result == null)
            {
                result = typeof(ActionSteps).GetMethods().FirstOrDefault(mi => mi.Name.Equals(string.Format(StringFormat.SetRS, paramName, KeyName), StringComparison.Ordinal));
            }

            return result;
        }

        protected override bool SetValue(MethodInfo setMethod, string newVal, string oldVal = null)
        {
            if (setMethod != null)
            {
                ParameterInfo argParameter = setMethod.GetParameters().FirstOrDefault();

                if (argParameter != null)
                {
                    var parType = argParameter.ParameterType;
                    if (parType == typeof(Int32) || parType == typeof(bool))
                    {
                        // для целочисленных и булевых избавляемся от точки и знаков после точки
                        newVal = newVal.Split('.')[0];
                        if (oldVal != null)
                        {
                            oldVal = oldVal.Split('.')[0];
                        }

                        if (parType == typeof(bool))
                        {
                            newVal = newVal.Equals(Resources.Common.One) ? Resources.Common.True : Resources.Common.False;
                            oldVal = oldVal.Equals(Resources.Common.One) ? Resources.Common.True : Resources.Common.False;
                        }
                    }

                    // меняем строковый тип на целевой, попутно меняя сепаратор чисел согласно региональной настройке 
                    var newValue = Convert.ChangeType(newVal.Replace(Resources.Common.DotSymbol, NumberDecimalSeparator), parType);

                    if (oldVal != null)
                    {
                        var oldValue = Convert.ChangeType(oldVal.Replace(Resources.Common.DotSymbol, NumberDecimalSeparator), parType);
                    }

                    var setResult = Convert.ToBoolean(setMethod.Invoke(ActionSteps, new[] { newValue }));

                    return setResult;
                }
            }
            return false;
        }

        /// <summary>
        /// Выполняет чтение регулирующих параметров прибора
        /// </summary>
        /// <param name="methodNames">Список методов для чтения</param>
        protected override bool ExecuteReadRegulatorParameters(string[] methodNames)
        {
            var result = true;
            foreach (var methodName in methodNames)
            {
                var readMethod = typeof(ActionSteps).GetMethod(string.Format(StringFormat.Get, methodName));
                DebugTrace(string.Format("Чтение регулирующего параметра: {0}", readMethod));

                if ((bool)readMethod.Invoke(ActionSteps, null))
                {
                    var parseMethod = typeof(ParserBase).GetMethod(string.Format(StringFormat.Parse, methodName));
                    parseMethod.Invoke(ParserBase, null);
                }
                else
                {
                    result = false;
                    if (LogHelper != null)
                    {
                        LogHelper.CreateLog(string.Format(DeviceMessages.Ecl310ReadMethodError, methodName), ErrorType.SpecificDeviceError);
                    }
                }
            }
            return result;
        }
    }
}

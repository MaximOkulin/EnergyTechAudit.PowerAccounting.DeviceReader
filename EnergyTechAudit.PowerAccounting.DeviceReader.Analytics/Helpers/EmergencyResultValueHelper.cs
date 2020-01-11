using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Helpers
{
    public class EmergencyResultValueHelper
    {
        public Tuple<string, string> GetEmergencyResultString(PreparedEmergencyCondition preparedEmergencyCondition, ScriptScope scriptScope, LogHelper logHelper)
        {
            var resultEmergencyValues = new List<string>();
            var shortTitles = new List<string>();

            foreach (var conditionPart in preparedEmergencyCondition.Expression.ConditionParts)
            {
                // если указано условие, по которому мы должны выбрать эту ветку
                if (!string.IsNullOrEmpty(conditionPart.Check))
                {
                    var checkSource = scriptScope.Engine.CreateScriptSourceFromString(conditionPart.Check);
                    bool checkResult = checkSource.Execute<bool>(scriptScope);
                    // эту ветку выбирать нельзя, продолжаем цикл
                    if (!checkResult) continue;
                }

                try
                {
                    // если итоговая строка форматирования содержит несколько вставок-значений
                    if (conditionPart.MultipleTitle != null)
                    {
                        var stringFormatArgs = new List<object>();

                        var orderedFormatParts = conditionPart.MultipleTitle.StringFormatParts.OrderBy(p => p.Order);

                        foreach (var formatPart in orderedFormatParts)
                        {
                            var formatPartSource = scriptScope.Engine.CreateScriptSourceFromString(formatPart.Expression);
                            stringFormatArgs.Add(Math.Round(formatPartSource.Execute<decimal>(scriptScope), 2));
                        }

                        if (!string.IsNullOrEmpty(conditionPart.MultipleTitle.Title))
                        {
                            resultEmergencyValues.Add(string.Format(conditionPart.MultipleTitle.Title, stringFormatArgs.ToArray()));
                        }
                        if (!string.IsNullOrEmpty(conditionPart.MultipleTitle.ShortTitle))
                        {
                            shortTitles.Add(string.Format(conditionPart.MultipleTitle.ShortTitle, stringFormatArgs.ToArray()));
                        }                        
                    }
                    else
                    {
                        dynamic emergencyValue = null;

                        if (!string.IsNullOrEmpty(conditionPart.Expression))
                        {

                            var emergencyValueSource =
                                scriptScope.Engine.CreateScriptSourceFromString(conditionPart.Expression);

                            if (conditionPart.ExpressionResultType != null && conditionPart.ExpressionResultType.Equals(Resources.Common.StringType,
                                StringComparison.Ordinal))
                            {
                                emergencyValue = emergencyValueSource.Execute<string>(scriptScope);
                            }
                            else
                            {
                                emergencyValue = Math.Round(emergencyValueSource.Execute<decimal>(scriptScope), 2);
                            }
                        }

                        // если для результирующей строки должен использоваться специфичный формат
                        if (!string.IsNullOrEmpty(conditionPart.CustomFormatter))
                        {
                            // инициализация класса форматирования
                            var formatterType =
                                Type.GetType(string.Format(DeviceMessages.FormatterAssemblyPattern,
                                    conditionPart.CustomFormatter));

                            if (formatterType != null)
                            {
                                var formatter = (IFormatProvider)Activator.CreateInstance(formatterType);
                                resultEmergencyValues.Add(string.Format(formatter, conditionPart.Title, emergencyValue));

                                if (!string.IsNullOrEmpty(conditionPart.ShortTitle))
                                {
                                    shortTitles.Add(string.Format(formatter, conditionPart.ShortTitle, emergencyValue));
                                }
                            }
                            else
                            {
                                logHelper.CreateLog(string.Format(DeviceMessages.EmergencySituationConditionPartFormatterNotFound, conditionPart.CustomFormatter));
                            }
                        }
                        else
                        {
                            if (emergencyValue != null)
                            {
                                resultEmergencyValues.Add(string.Format(conditionPart.Title, emergencyValue));
                                if (!string.IsNullOrEmpty(conditionPart.ShortTitle))
                                {
                                    shortTitles.Add(string.Format(conditionPart.ShortTitle, emergencyValue));
                                }
                            }
                            else
                            {
                                resultEmergencyValues.Add(conditionPart.Title);
                            }
                        }
                    }
                }
                catch
                {
                    resultEmergencyValues.Add(conditionPart.AlternativeTitle);
                }
            }

            string resultValues = string.Empty;

            if (resultEmergencyValues.Count > 0)
            {
                resultValues = string.Join(Resources.Common.SemicolonSymbol, resultEmergencyValues.ToArray());
            }

            string shortTitlesValues = string.Empty;
            if (shortTitles.Count > 0)
            {
                shortTitlesValues = string.Join(Resources.Common.SemicolonSymbol, shortTitles.ToArray());
            }

            return new Tuple<string, string>(resultValues, shortTitlesValues);
        }
    }
}

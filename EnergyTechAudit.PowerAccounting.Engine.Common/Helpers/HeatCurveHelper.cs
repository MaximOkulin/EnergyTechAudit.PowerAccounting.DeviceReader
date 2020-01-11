using System;
using System.Collections.Generic;
using System.Globalization;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.HeatCurve;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using Newtonsoft.Json;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    /// <summary>
    /// Вспомогательный класс, преобразующий JSON-представление температурного графика, хранящегося в динамическом параметре,
    /// в тип HeatCurve
    /// </summary>
    public class HeatCurveHelper
    {
        private readonly List<DynamicParameterValue> _dynamicParameterValues;

        public HeatCurveHelper(List<DynamicParameterValue> dynamicParameterValues)
        {
            _dynamicParameterValues = dynamicParameterValues;
        }

        /// <summary>
        /// Возвращает температурные графики
        /// </summary>
        public List<HeatCurve> GetHeatCurves()
        {
            var heatCurves = new List<HeatCurve>();

            foreach (var dynamicParameter in _dynamicParameterValues)
            {
                var heatCurve = new HeatCurve
                {
                    HeatCurveType = (HeatCurveType)dynamicParameter.DynamicParameterId,
                    OrganizationId = dynamicParameter.EntityId
                };

                var rawHeatCurve = JsonConvert.DeserializeObject<RawHeatCurve>(dynamicParameter.Value);
                heatCurve.Points = GetPoints(rawHeatCurve);

                heatCurves.Add(heatCurve);
            }

            return heatCurves;
        }

        /// <summary>
        /// Возвращает коллекцию точек температурного графика
        /// </summary>
        /// <param name="rawHeatCurve">"Сырое" описание точек</param>
        private List<HeatCurvePoint> GetPoints(RawHeatCurve rawHeatCurve)
        {
            var heatCurvePoints = new List<HeatCurvePoint>();

            foreach (var point in rawHeatCurve.UserInputValues)
            {
                var outdoorTemperature = ParseOutdoorTemperature(point.Name);

                if (outdoorTemperature != null)
                {
                    heatCurvePoints.Add(new HeatCurvePoint
                    {
                        OutdoorTemperature = outdoorTemperature.Value,
                        Temperature = Convert.ToDecimal(point.Value, CultureInfo.InvariantCulture)
                    });
                }
            }

            return heatCurvePoints;
        }

        /// <summary>
        /// Возвращает температуру наружного воздуха
        /// </summary>
        /// <param name="outdoorTemp">Строка типа "Sign_Value" (Sign - "Plus" или "Minus"; Value - значение)</param>
        private int? ParseOutdoorTemperature(string outdoorTemp)
        {
            string[] temperatureParts = outdoorTemp.Split(new string[] { Resources.Common.UnderscoreSymbol }, StringSplitOptions.None);
            
            if(temperatureParts.Length == 2)
            {
                int koef = temperatureParts[0].Equals(Resources.Common.Minus, StringComparison.Ordinal) ? -1 : 1;
                return koef * Convert.ToInt32(temperatureParts[1]);
            }
            else if(outdoorTemp.Equals(Resources.Common.Zero, StringComparison.Ordinal))
            {
                return 0;
            }

            return null;
        }
    }
}

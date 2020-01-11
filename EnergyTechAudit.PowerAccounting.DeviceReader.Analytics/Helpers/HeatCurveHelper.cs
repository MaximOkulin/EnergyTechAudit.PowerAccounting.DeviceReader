using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.HeatCurve;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using DynParameter = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.DynamicParameter;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Snips;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Helpers
{

    /// <summary>
    /// Вспомогательный класс, упрощающий работу с температурными графиками организаций
    /// </summary>
    public class HeatCurveHelper
    {
        private static Dictionary<string, int> CitiesTemperDeviceParameters = new Dictionary<string, int>
        {
        { Cities.Kazan, 12001 },
        { Cities.Chelny, 12002 },
        { Cities.Almet, 12003 },
        { Cities.Zdk, 12004 },
        { Cities.Innopolis, 12005 },
        { Cities.Tver, 12006 },
        { Cities.Elabuga, 12007 }
        };

        private readonly List<HeatCurve> _heatCurves;
        private readonly List<District> _districtCache;
        private readonly List<City> _cities;
        private int _cityId;
        private string _cityLatinCode;
        private int? _meteoStationId;
        private decimal _correctionValue = 0;
        private readonly int _accessPointId;

        // флаг - в базе данных есть актуальное значение температуры наружного воздуха (по умолчанию считаем, что оно актуально)
        private bool _isOutdoorTemperatureActual = true;

        private decimal? _outdoorTemperature;
        
        public decimal? OutdoorTemperature
        {
            get
            {
                if (_outdoorTemperature == null)
                {
                    GetOutdoorTemperature();
                }
                return _outdoorTemperature;
            }
        }

        public HeatCurveHelper(DeviceReaderCache cache, int accessPointId)
        {
            _heatCurves = cache.HeatCurves;
            _districtCache = cache.Districts;
            _cities = cache.Cities;
            _meteoStationId = cache.MeteoStationId;
            _accessPointId = accessPointId;

            InitCityIdAndCorrectionValue();
        }

        private void InitCityIdAndCorrectionValue()
        {
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var apLinkBuilding = context.Set<AccessPointLinkBuilding>().FirstOrDefault(p => p.AccessPointId == _accessPointId);

                        if (apLinkBuilding != null)
                        {
                            var building = context.Set<Building>().Select(p => new BuildingSnip
                            {
                                DistrictId = p.DistrictId,
                                Id = p.Id
                            }).FirstOrDefault(p => p.Id == apLinkBuilding.BuildingId);

                            if (building != null)
                            {
                                _cityId = _districtCache.First(p => p.Id == building.DistrictId).CityId;
                                _cityLatinCode = _cities.First(p => p.Id == _cityId).LatinCode;

                                _correctionValue = new DynamicParameterHelper(context).
                                                       GetDynamicValue<decimal>(DynParameter.BuildingOutdoorTemperatureCorrection, building.Id);
                            }
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }
        }

        public void CalculateHeatSysTemperatureByHeatCurve(ScopeValue scopeValue, HeatCurveType heatCurveType)
        {
            int? organizationId = scopeValue.ParentChannelEmergencyInfo.Channel.OrganizationId;

            var emergencySituationParameters = new int[] { ((int)heatCurveType - 44), 19, 32, 33 };

            var emergencySituation = scopeValue.ParentChannelEmergencyInfo.EmergencySituationParameters.FirstOrDefault(p => emergencySituationParameters.Contains(p.EmergencySituationParameterTemplateId));

            if (organizationId != null && emergencySituation != null)
            {
                // поиск температурного графика по подаче
                var heatCurve = _heatCurves.FirstOrDefault(p => p.OrganizationId == organizationId.Value && p.HeatCurveType == heatCurveType);

                if (heatCurve != null)
                {
                    if (OutdoorTemperature != null)
                    {
                        decimal currentTemperature = OutdoorTemperature.Value;
                        int minOutdoorTemperature = heatCurve.Points.Min(p => p.OutdoorTemperature);
                        int maxOutdoorTemperature = heatCurve.Points.Max(p => p.OutdoorTemperature);

                        // если текущая температура наружного воздуха находится внутри точек температурного графика
                        if (minOutdoorTemperature < currentTemperature && currentTemperature < maxOutdoorTemperature)
                        {
                            // если текущая температура совпадает с какой-либо точкой температурного графика
                            if (currentTemperature.IsInteger())
                            {
                                var point = heatCurve.Points.FirstOrDefault(p => p.OutdoorTemperature == currentTemperature);
                                if (point != null)
                                {
                                    scopeValue.Value = point.Temperature;
                                }
                            }
                            else
                            {
                                var lowerBorder = currentTemperature.GetNearestLowerInt();
                                var upperBorder = currentTemperature.GetNearestUpperInt();

                                var lowerPoint = heatCurve.Points.FirstOrDefault(p => p.OutdoorTemperature == lowerBorder);
                                var upperPoint = heatCurve.Points.FirstOrDefault(p => p.OutdoorTemperature == upperBorder);

                                if (lowerPoint != null && upperPoint != null)
                                {
                                    var heatCurveLine = new HeatCurveLine(lowerPoint.OutdoorTemperature, lowerPoint.Temperature,
                                                                          upperPoint.OutdoorTemperature, upperPoint.Temperature);
                                    scopeValue.Value = heatCurveLine.Calculate(currentTemperature);
                                }
                            }
                        }
                        else if (currentTemperature <= minOutdoorTemperature)
                        {
                            var point = heatCurve.Points.FirstOrDefault(p => p.OutdoorTemperature == minOutdoorTemperature);
                            if (point != null)
                            {
                                scopeValue.Value = point.Temperature;
                            }
                        }
                        else if (currentTemperature >= maxOutdoorTemperature)
                        {
                            var point = heatCurve.Points.FirstOrDefault(p => p.OutdoorTemperature == maxOutdoorTemperature);
                            if (point != null)
                            {
                                scopeValue.Value = point.Temperature;
                            }
                        }
                    }
                    else
                    {
                        scopeValue.EmergencyLogs.Add(new EmergencyLog
                        {
                            EmergencySituationParameterId = emergencySituation.Id,
                            Value = Resources.Common.OutdoorTemperatureNotFound
                        });
                    }
                }
                else
                {
                    scopeValue.EmergencyLogs.Add(new EmergencyLog
                    {
                        EmergencySituationParameterId = emergencySituation.Id,
                        Value = heatCurveType == HeatCurveType.SupplyPipe ? Resources.Common.HeatCurveSupplyPipeNotFound :
                                                                            Resources.Common.HeatCurveReturnPipeNotFound
                    });
                }
            }
        }
        

        private void GetOutdoorTemperature()
        {
            int deviceParameterId = CitiesTemperDeviceParameters[_cityLatinCode];

            if (_meteoStationId != null)
            {
                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            var endPeriod = DateTime.Now;
                            var beginPeriod = endPeriod.AddHours(-1);

                            var meteoData = context.Set<Archive>().Where(p => p.PeriodTypeId == 1 && p.MeasurementDeviceId == _meteoStationId.Value &&
                            p.DeviceParameterId == deviceParameterId).OrderByDescending(p => p.Time).Take(7).ToList();
                            
                            if (meteoData != null && meteoData.Count > 0)
                            {
                                var averageTemp = meteoData.Where(p => p.Time >= beginPeriod && p.Time <= endPeriod).Select(p => p.Value).Average();
                                _outdoorTemperature = averageTemp + _correctionValue;
                                _isOutdoorTemperatureActual = true;
                            }
                            else

                            {
                                _isOutdoorTemperatureActual = false;
                            }
                           
                            tran.Commit();
                        }
                        catch
                        {
                            _isOutdoorTemperatureActual = false;
                            tran.Rollback();
                        }
                    }
                }
            }
            else
            {
                _isOutdoorTemperatureActual = false;
            }
        }
    }
}

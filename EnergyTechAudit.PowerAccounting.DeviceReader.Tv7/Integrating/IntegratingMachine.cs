using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.EqualityComparers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Helpers;
using CommonPeriodType = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.PeriodType;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Integrating
{
    internal class IntegratingMachine
    {
        private NotCalculatedDates _notCalculatedDates;
        private readonly int _measurementDeviceId;

        private List<Archive> _finalArchives;
        private List<Archive> _lastSummaryArchives;
        private List<DateTime> _finalTimes;

        private LightDatabaseContext _context;
        private readonly StoredProceduresHelper _storedProceduresHelper;

        private IntegratingParameters _summaries;

        private readonly PropertyInfo[] _integParamsFields;
        private const int AccumulationCount = 750;

        private readonly List<Archive> _calculatedArchives = new List<Archive>();

        public IntegratingMachine(int measurementDeviceId)
        {
            _measurementDeviceId = measurementDeviceId;
            _context = new LightDatabaseContext();
            _storedProceduresHelper = new StoredProceduresHelper(_context, measurementDeviceId);
            _integParamsFields = typeof (IntegratingParameters).GetProperties();
        }

        /// <summary>
        /// Инициализирует диапазон дат, в котором не было рассчетов суммарных параметров
        /// </summary>
        private void InitNotCalculatedDates()
        {
            _notCalculatedDates = _storedProceduresHelper.GetNotCalculatedDates();
        }

        /// <summary>
        /// Инициализирует точки отсчета (итоговые архивы, хранящиеся в суточных), которые были после начальной даты нерассчитанных архивов
        /// </summary>
        private void InitFinalArchives()
        {
            // в диапазоне [4049-4072] находятся идентификаторы интеграторов-девайсовых параметров ТВ7
            _finalArchives = _context.Set<Archive>().Where(p => p.PeriodTypeId == (int)CommonPeriodType.Day &&
                                                          p.DeviceParameterId >= 4049 && p.DeviceParameterId <= 4072 &&
                                                          p.MeasurementDevice.Id == _measurementDeviceId &&
                                                          p.Time >= _notCalculatedDates.Min).ToList();
            _finalTimes =
                _finalArchives.Distinct(new ArchiveTimeComparer()).OrderBy(p => p.Time).Select(p => p.Time).ToList();
        }

        private bool InitStartingPoint(out bool hasLastSummaryArchive)
        {
            using (var context = new LightDatabaseContext())
            {
                var lastSummaryArchive =
                    context.Set<Archive>().OrderByDescending(p => p.Time)
                        .FirstOrDefault(p => p.PeriodTypeId == (int)CommonPeriodType.Hour &&
                                             p.MeasurementDeviceId == _measurementDeviceId &&
                                             p.DeviceParameterId == (int)DeviceParameter.TV7_V1Sum);

                // если не находим, то высчитываем относительно ближайшего итогового архива
                if (lastSummaryArchive == null)
                {
                    hasLastSummaryArchive = false;

                    if (_finalTimes.Any())
                    {
                        var nearestFinalTime = _finalTimes.First();
                        if (_notCalculatedDates.Min != null && _notCalculatedDates.Max != null)
                        {
                            if (_notCalculatedDates.Min.Value <= nearestFinalTime &&
                                _notCalculatedDates.Max.Value >= nearestFinalTime)
                            {
                                _summaries =
                                    _storedProceduresHelper.CalculateStartingPoint(_notCalculatedDates.Min.Value,
                                        nearestFinalTime);

                                return true;
                            }
                        }
                    }
                    return false;
                }

                hasLastSummaryArchive = true;

                _summaries = _storedProceduresHelper.GetIntegratingParametersByTime(lastSummaryArchive.Time);

                _lastSummaryArchives =
                    context.Set<Archive>().Where(
                        p =>
                            p.PeriodTypeId == (int)CommonPeriodType.Hour && p.MeasurementDeviceId == _measurementDeviceId &&
                            p.Time == lastSummaryArchive.Time).ToList();

                return true;
            }
        }

        public void Calculate()
        {
            InitNotCalculatedDates();

            if (_notCalculatedDates.Min != null && _notCalculatedDates.Max != null)
            {
                InitFinalArchives();

                bool hasLastSummaryArchive;

                if (InitStartingPoint(out hasLastSummaryArchive))
                {
                    while (_notCalculatedDates.Min.Value <= _notCalculatedDates.Max.Value)
                    {
#if DEBUG
                        Console.WriteLine(_notCalculatedDates.Min.Value);
#endif
                        var currentValues = hasLastSummaryArchive
                            ? _storedProceduresHelper.GetIntegratingParametersByTime(_notCalculatedDates.Min.Value, true)
                            : _summaries;

                        if (!CheckFinalArchiveEquality(_notCalculatedDates.Min.Value, _summaries, _integParamsFields))
                        {
                            // вычисляет новые суммы для каждого интегрируемого значения
                            foreach (var propertieInfo in _integParamsFields)
                            {
                                if (propertieInfo.CanWrite)
                                {

                                    var currentValue = (decimal?)propertieInfo.GetValue(currentValues);
                                    var currentSumValue = (decimal?)propertieInfo.GetValue(_summaries);

                                    // если уже были расчеты, то суммируем; иначе суммировать не надо, т.к. идет выравнивание по исходной сумме
                                    if (hasLastSummaryArchive)
                                    {
                                        if (currentValue != null)
                                        {
                                            if (currentSumValue != null)
                                            {
                                                currentSumValue += currentValue.Value;
                                            }
                                            else
                                            {
                                                currentSumValue = currentValue;
                                            }

                                            propertieInfo.SetValue(_summaries, currentSumValue);
                                        }
                                    }

                                    // шаблон архива, на базе которого строится интегрируемого значение
                                    Archive templateArchive = null;

                                    // если вычисляем по предыдущему рассчитанному, то в качестве шаблона выбираем его
                                    if (_lastSummaryArchives != null && _lastSummaryArchives.Count > 0)
                                    {
                                        templateArchive =
                                            _lastSummaryArchives.FirstOrDefault(
                                                p =>
                                                    p.DeviceParameterId ==
                                                    _summaries.ParametersId[propertieInfo.Name]);
                                    }
                                    // если вычисляем относительно ближайшего итогового архива, то в качестве шаблона выбираем итоговый архив
                                    else if (_finalArchives != null && _finalArchives.Count > 0)
                                    {
                                        templateArchive =
                                            _finalArchives.FirstOrDefault(
                                                p =>
                                                    p.DeviceParameterId ==
                                                    _summaries.ParametersId[propertieInfo.Name]);
                                    }

                                    // конструируем новое интегрированное значение

                                    if (templateArchive != null && currentSumValue != null)
                                    {
                                        var archive = new Archive
                                        {
                                            MeasurementDeviceId = _measurementDeviceId,
                                            PeriodTypeId = (int)CommonPeriodType.Hour,
                                            Time = _notCalculatedDates.Min.Value,
                                            DeviceParameterId = _summaries.ParametersId[propertieInfo.Name],
                                            TimeSignatureId = templateArchive.TimeSignatureId,
                                            Value = currentSumValue.Value,
                                            IsValid = true
                                        };
                                        _calculatedArchives.Add(archive);
                                    }
                                }
                            }
                        }
                        if (_calculatedArchives.Count >= AccumulationCount)
                        {
                            SaveCalculatedArchives();
                        }
                        hasLastSummaryArchive = true;

                        _notCalculatedDates.Min = _notCalculatedDates.Min.Value.AddHours(1);
                    }
                }
            }

            SaveCalculatedArchives();
        }

        private void SaveCalculatedArchives()
        {
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        context.Set<Archive>().AddRange(_calculatedArchives);
                        context.SaveChanges();
                        _calculatedArchives.Clear();
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw new Exception();
                    }
                }
            }
        }


        /// <summary>
        /// Проверяет совпадает ли текущее время архива с временем какой-либо точки отсчета (итогового архива)
        /// </summary>
        /// <param name="time">Текущее время архива</param>
        /// <param name="summaries">Суммы параметров</param>
        /// <param name="integParamsFields">Описание полей-интеграторов</param>
        /// <returns>0 - не совпадает; 1 - совпадает</returns>
        private bool CheckFinalArchiveEquality(DateTime time, IntegratingParameters summaries,
            PropertyInfo[] integParamsFields)
        {
            var equalFinalArchive = _finalArchives.FirstOrDefault(p => p.Time == time);

            if (equalFinalArchive != null)
            {
                // время совпало - отбираем все значения накопительных параметров из итогового (суточного) архива
                var equalFinalArchives = _finalArchives.Where(p => p.Time == time);

                foreach (var finalArchive in equalFinalArchives)
                {
                    var periodSumArchive = (Archive)finalArchive.Clone();
                    periodSumArchive.PeriodTypeId = (int)CommonPeriodType.Hour;
                    periodSumArchive.Time = time;
                    _calculatedArchives.Add(periodSumArchive);

                    var parameterName =
                        summaries.ParametersId.First(p => p.Value == periodSumArchive.DeviceParameterId).Key;
                    var parameterField = integParamsFields.First(p => p.Name == parameterName);
                    parameterField.SetValue(summaries, periodSumArchive.Value);
                }
                return true;
            }
            return false;
        }
    }
}

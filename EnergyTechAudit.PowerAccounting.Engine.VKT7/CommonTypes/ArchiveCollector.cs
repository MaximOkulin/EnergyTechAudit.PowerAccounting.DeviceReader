using System;
using System.Collections.Generic;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.CommonTypes
{
    /// <summary>
    /// Класс, собирающий и сохраняющий архивные показания
    /// </summary>
    internal class ArchiveCollector : ArchiveCollectorBase
    {
        public ParametersCollection ParametersCollection;
        private List<Archive> _localArchiveCache;
        private readonly List<StartParamValue> _startParamValues;
       
        // список количеств точек после запятой для параметров текущей измерительной схемы
        private Dictionary<string, int> _decimals = new Dictionary<string, int>();
        // сопоставление кодов параметров прибора с их идентификаторами в базе данных
        private readonly Dictionary<string, int> _deviceParametersMapping = new Dictionary<string, int>();

        public ArchiveCollector(DateTime deviceTime, MeasurementDevice device, List<StartParamValue> startParamValues) :
            base(deviceTime, device)
        {
            ParametersCollection = ParametersCollection.GetParametersCollection();
            _startParamValues = startParamValues;
            _localArchiveCache = new List<Archive>();
        }

        private const byte OPC_QUALITY_GOOD = 0xC0;
        private const byte OPC_QUALITY_SENSOR_CAL = 0x50;
        /// <summary>
        /// Собирает значения параметров из входного буфера в сущность Archive
        /// и сохраняет в список архивных записей для сохранения в БД
        /// </summary>
        /// <param name="paramsToRead">Список параметров, присутствующих во входном буфере</param>
        /// <param name="buffer">Буфер</param>
        /// <param name="periodType">Тип периода значений (дневные, мгновенные...)</param>
        /// <param name="time">Время архивной записи</param>
        public bool CollectParameters(Dictionary<Parameter, int> paramsToRead, byte[] buffer, 
                                      PeriodType periodType, DateTime time, DateTime deviceTime, bool canSave)
        {
            int position = 3;

            _localArchiveCache.Clear();

            try
            {
                decimal t1_1Type = 0;
                decimal qntType_1Hip = 0;
                decimal v1_1Type = 0;

                foreach (var param in paramsToRead)
                {
                    double value = 0;
                    var decimals = _decimals.FirstOrDefault(p => p.Key == param.Key.DecimalCode);
                    double divider = Math.Pow(10, decimals.Value);

                    string emergency = null;
                    // если длина значения параметра 1 байт
                    if (param.Value == 1)
                    {
                        value = buffer[position++];
                    }

                    // если длина значения параметра 2 байта
                    if (param.Value == 2)
                    {
                        value = BitConverter.ToInt16(new[] {buffer[position++], buffer[position++]}, 0)/divider;

                        switch (param.Key.Name)
                        {
                            case "t1_1Type":
                                t1_1Type = Convert.ToDecimal(value);
                                break;
                        }
                    }
                    // если длина значения параметра 4 байта
                    else if (param.Value == 4 && param.Key.ParseType == Resources.Common.IntType)
                    {
                        // "Глюк" прибора - в итоговых часах наработки некоторые приборы в старших байтах присылают 0xFF, 0xFF
                        if ((param.Key.Name.Equals(Vkt7Resources.QntType_1HIPParam) ||
                             param.Key.Name.Equals(Vkt7Resources.QntType_2HIPParam)) && buffer[position + 2] == 0xFF &&
                            buffer[position + 3] == 0xFF)
                        {
                            value =
                                BitConverter.ToInt32(
                                    new byte[] {buffer[position++], buffer[position++], 0x00, 0x00}, 0)/divider;
                            position = position + 2;
                        }
                        else
                        {
                            value =
                                BitConverter.ToInt32(
                                    new[]
                                    {buffer[position++], buffer[position++], buffer[position++], buffer[position++]},
                                    0)/
                                divider;
                        }

                        switch (param.Key.Name)
                        {
                            case "V1_1Type":
                                v1_1Type = Convert.ToDecimal(value);
                                break;
                            case "QntType_1HIP":
                                qntType_1Hip = Convert.ToDecimal(value);
                                break;
                        }
                    }
                    // число представлено вещественным (величины расхода и величина, измеряемая на дополнительном входе)
                    else if (param.Value == 4 && param.Key.ParseType == Resources.Common.FloatType)
                    {
                        value =
                            BitConverter.ToSingle(
                                new[] {buffer[position++], buffer[position++], buffer[position++], buffer[position++]},
                                0);
                        if (double.IsNaN(value))
                        {
                            value = 0;
                        }
                    }
                    else if (param.Value == 1)
                    {
                        byte b = buffer[position++];
                    }

                    // анализируем байт качества
                    byte qualityByte = buffer[position++];
                    bool isValid = qualityByte == OPC_QUALITY_GOOD || qualityByte == OPC_QUALITY_SENSOR_CAL;
                    // читаем байт нештатной ситуации
                    byte emergencySituationByte = buffer[position++];
                    // если байт качества вернул "плохо", то уже нет смысла анализировать нештатную ситуацию
                    if (isValid)
                    {
                        isValid = emergencySituationByte == 0x00 || emergencySituationByte == 0xFF;
                    }

                    value = value < -2000000 ? 0 : value;

                    // сохранение в мгновенные текущего времени прибора
                    if (periodType == PeriodType.Instant)
                    {
                        var deviceTimeArchive = Archives.FirstOrDefault(p => p.DeviceParameterId == 7206);
                        if (deviceTimeArchive == null)
                        {
                            Archives.Add(new Archive
                            {
                                PeriodTypeId = 1,
                                Time = time,
                                Value = (decimal)deviceTime.ToOADate(),
                                MeasurementDeviceId = Device.Id,
                                IsValid = true,
                                DeviceParameterId = 7206
                            });
                        }
                    }

                    decimal startValue = 0;

                    if (_startParamValues != null && _startParamValues.Select(p => p.ParameterCode).Contains(param.Key.IntegrationDeviceParameterCode))
                    {
                        var startParamValue = _startParamValues.FirstOrDefault(p => p.ParameterCode.Equals(param.Key.IntegrationDeviceParameterCode, StringComparison.Ordinal));
                        if (startParamValue != null && startParamValue.PeriodTypes.Contains(periodType) && time >= startParamValue.Time)
                        {
                            startValue = startParamValue.StartValue;
                        }
                    }

                    var archive = new Archive
                    {
                        PeriodTypeId = (int) periodType,
                        Time = time,
                        Value = Convert.ToDecimal(value) + startValue,
                        MeasurementDeviceId = Device.Id,
                        DeviceParameterId = GetDeviceParameterId(param, periodType),
                        IsValid = isValid
                    };

                    if (TimeSignature.Id > 0)
                    {
                        archive.TimeSignatureId = TimeSignature.Id;
                    }
                    else
                    {
                        archive.TimeSignature = TimeSignature;
                    }

                    Archives.Add(archive);
                }

                // hook: пришла некорректная строчка, содержащая в поле температуры 0.63
                if (t1_1Type == 0.63M && qntType_1Hip == 0 && v1_1Type == 0)
                {
                    Archives.Clear();
                    MeasurementDeviceJournals.Clear();
                    throw new Exception(string.Format(DeviceMessages.Vkt7Incorrect063ArchiveValue, periodType, time));
                }

                // сохраняем архивы, если накоплено кол-во достаточное для сохранения,
                // а также это последний читаемый параметр последовательности (чтобы вся пачка параметров одновременно сохранилась в БД)
                // мгновенные также не сохраняем; они должны сохранится синхронно с текущими итоговыми
                if (periodType != PeriodType.Instant && canSave)
                {
                    _localArchiveCache.AddRange(Archives);
                    var saveResult = SaveArchives();

                    if (saveResult)
                    {
                        ArchiveCache.AddRange(_localArchiveCache);
                    }

                    return saveResult;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Archives.Clear();
                MeasurementDeviceJournals.Clear();
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Возвращает идентификатор параметра прибора в БД
        /// </summary>
        /// <param name="parameter">Параметр</param>
        /// <param name="periodType">Тип периода</param>
        public int GetDeviceParameterId(KeyValuePair<Parameter, int> parameter, PeriodType periodType)
        {
            // для итоговых значений сохраняем всегда в накопительный параметр;
            // для остальных в дифференциальный параметр
            string param = periodType == PeriodType.Final || periodType == PeriodType.FinalInstant
                ? parameter.Key.IntegrationDeviceParameterCode
                : parameter.Key.DeviceParameterCode;

            return _deviceParametersMapping.First(p => p.Key == param).Value;
        }

        public void InitUnitNamesAndDecimals(object obj)
        {
            var tuple = obj as Tuple<Dictionary<string, string>, Dictionary<string, int>>;
            if (tuple != null)
            {
                _decimals = tuple.Item2;
            }
            ParametersAndPropertiesMapping();
        }

        

        /// <summary>
        /// Осуществляет сопоставление параметров и свойств взятых из XML-описания,
        /// с параметрами и свойствами из базы данных
        /// </summary>
        private void ParametersAndPropertiesMapping()
        {
            var uniqueDeviceParameterCodes = ParametersCollection.Parameters.Select(p => p.DeviceParameterCode).Distinct().ToList();
            uniqueDeviceParameterCodes.AddRange(ParametersCollection.Parameters.Select(p => p.IntegrationDeviceParameterCode).Distinct());

            using (var context = new LightDatabaseContext())
            {
                // проецирование идентификаторов параметров прибора в словарь
                foreach (var uniqueDeviceParameterCode in uniqueDeviceParameterCodes)
                {
                    var deviceParameter =
                        context.Set<LightDataAccess.Dictionaries.DeviceParameter>().FirstOrDefault(p => p.Code == uniqueDeviceParameterCode);
                    if (deviceParameter != null)
                    {
                        _deviceParametersMapping.Add(uniqueDeviceParameterCode, deviceParameter.Id);
                    }
                }
            }
        }
    }
}

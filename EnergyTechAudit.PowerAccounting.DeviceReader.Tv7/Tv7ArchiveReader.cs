using System;
using System.Linq.Expressions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Helpers;
using PeriodType = EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types.PeriodType;
using CommonPeriodType = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.PeriodType;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7
{
    public partial class Tv7
    {
        private void ReadHourArchives()
        {
            if (MeasurementDevice.GiveHArcData)
            {
#if DEBUG
                Console.WriteLine("Чтение часовых архивов");
#endif 
                ReadArchive(PeriodType.Hour, ArchiveReadConditionHelper.GetHourArchiveReadCondition(_archiveDatesInfo));
            }
        }

        private void ReadDayArchives()
        {
            if (MeasurementDevice.GiveDArcData)
            {
#if DEBUG
                Console.WriteLine("Чтение суточных архивов");
#endif
                ReadArchive(PeriodType.Day, ArchiveReadConditionHelper.GetDayArchiveReadCondition(_archiveDatesInfo));
            }
        }

        private void ReadMonthArchives()
        {
            if (MeasurementDevice.GiveMArcData)
            {
#if DEBUG
                Console.WriteLine("Чтение месячных архивов");
#endif
                ReadArchive(PeriodType.Month, ArchiveReadConditionHelper.GetMonthArchiveReadCondition(_archiveDatesInfo));
            }
        }

        private void ReadFinalArchives()
        {
            if (MeasurementDevice.GiveDArcData)
            {
#if DEBUG
                Console.WriteLine("Чтение итоговых архивов");
#endif
                ReadFinalArchive(ArchiveReadConditionHelper.GetFinalArchiveReadCondition(_archiveDatesInfo));
            }
        }


        /// <summary>
        /// Читает итоговый архив
        /// </summary>
        /// <param name="archiveReadCondition">Условия чтения архива</param>
        private void ReadFinalArchive(ArchiveReadConditionBase archiveReadCondition)
        {
            Expression<Func<Archive, bool>> filter =
                (archive) => archive.DeviceParameterId == (int) DeviceParameter.TV7_V1Sum;

            var lastPeriodArchive = GetLastArchiveByPeriod(CommonPeriodType.Day, filter);

            DateTime startDateRead = archiveReadCondition.StartDateCalculator(lastPeriodArchive);
            DateTime endDateRead = archiveReadCondition.EndDateCalculator(DateTime.Now);

            TimeSpan ts = startDateRead - endDateRead;

            if (archiveReadCondition.Condition(ts))
            {
                while (startDateRead < endDateRead)
                {
                    LocalArchives.Clear();

                    startDateRead = archiveReadCondition.NextArchiveDateIterator(startDateRead);

#if DEBUG
                    Console.WriteLine("Чтение на дату: " + startDateRead);
#endif
                    RaiseTraceInfoPassedEvent(string.Format(TraceMessages.GetArchiveByDate, startDateRead));

                    byte[] controlBytes = _actionSteps.SpeedReadFinalArchive(startDateRead);
                    
                    byte[] buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

                    if (controlBytes[0] != buffer[4] || controlBytes[1] != buffer[5])
                    {
                        throw new Exception(Tv7Resources.SpeedReadArchiveWrongControlBytes);
                    }

                    var archiveTime = _parser.GetSpeedArchiveDate(buffer);

                    // значения по трубам
                    for (var i = 1; i <= 6; i++)
                    {
                        CreatePipeFinalArchive(buffer, archiveTime, i);
                    }

                    // значения по тепловым вводам
                    for (var i = 1; i <= 2; i++)
                    {
                        CreateHeatInputFinalArchive(buffer, archiveTime, i);
                    }

                    // значение по доп. параметру (ДП)

                    var apSum =
                        BitConverter.ToDouble(
                            new[]
                            {buffer[199], buffer[198], buffer[201], buffer[200], buffer[203], buffer[202], buffer[205], buffer[204]}, 0);
                    apSum = double.IsNaN(apSum) ? 0 : apSum;

                    LocalArchives.Add(new ValueInfo
                    {
                        PeriodType = CommonPeriodType.Day,
                        Value = (decimal)apSum,
                        DeviceParameterId = (int)DeviceParameter.TV7_APSum,
                        MeasurementDeviceId = MeasurementDevice.Id,
                        Time = archiveTime,
                        IsValid = true
                    });

                    if (archiveTime.Day == 25)
                    {
                        LocalArchives.Add(new ValueInfo
                        {
                            PeriodType = CommonPeriodType.Month,
                            Value = (decimal)apSum,
                            DeviceParameterId = (int)DeviceParameter.TV7_APSum,
                            MeasurementDeviceId = MeasurementDevice.Id,
                            Time = archiveTime,
                            IsValid = true
                        });
                    }

                    ArchiveCollector.CreateArchives(LocalArchives);

                    if (!ArchiveCollector.SaveArchives())
                    {
                        throw new Exception(string.Format(DeviceMessages.SaveArchiveError, CommonPeriodType.Final, archiveTime));
                    }
                }
            }
        }

        /// <summary>
        /// Читает часовой, суточный и месячный архивы
        /// </summary>
        /// <param name="tv7PeriodType">Тип периода ТВ-7</param>
        /// <param name="archiveReadCondition">Условия чтения архива</param>
        private void ReadArchive(PeriodType tv7PeriodType, ArchiveReadConditionBase archiveReadCondition)
        {
            // преобразуем в классический тип периода из периода ТВ7
            var periodType = (Common.Types.Proxy.PeriodType) ((int) tv7PeriodType + 2);

            var lastPeriodArchive = GetLastArchiveByPeriod(periodType);

            DateTime startDateRead = archiveReadCondition.StartDateCalculator(lastPeriodArchive);
            DateTime endDateRead = archiveReadCondition.EndDateCalculator(DateTime.Now);

            TimeSpan ts = startDateRead - endDateRead;

            if (archiveReadCondition.Condition(ts))
            {
                while (startDateRead < endDateRead)
                {
                    LocalArchives.Clear();

                    startDateRead = archiveReadCondition.NextArchiveDateIterator(startDateRead);

#if DEBUG
                    Console.WriteLine("Чтение на дату: " + startDateRead);
#endif
                    RaiseTraceInfoPassedEvent(string.Format(TraceMessages.GetArchiveByDate, startDateRead));

                    byte[] controlBytes = _actionSteps.SpeedReadArchive(startDateRead, tv7PeriodType);

                    byte[] buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);

                    if (controlBytes[0] != buffer[4] || controlBytes[1] != buffer[5])
                    {
                        throw new Exception(Tv7Resources.SpeedReadArchiveWrongControlBytes);
                    }

                    // если архивная запись на заданную дату отсутствует, то переходим к чтению следующей даты
                    if (Transport.CurrentErrorCode == ErrorCode.ArchiveDataNotAvailable)
                    {
                        RaiseTraceInfoPassedEvent(string.Format(Resources.Device.Tv7Resources.ArchiveDataNotAvailable, startDateRead));
                        continue;
                    }

                    var archiveTime = _parser.GetSpeedArchiveDate(buffer);

                    // если время архива больше чем приборное, то выходим из цикла
                    if (archiveTime > DeviceTime)
                    {
                         break;
                    }                        

                    // значения по трубам
                    for (var i = 1; i <= 6; i++)
                    {
                        CreatePipeArchive(buffer, archiveTime, periodType, i);
                    }

                    // значения по тепловым вводам
                    for (var i = 1; i <= 2; i++)
                    {
                        CreateHeatInputArchive(buffer, archiveTime, periodType, i);
                    }

                    // значение по ДП
                    var apDiff = BitConverter.ToSingle(new[] {buffer[179], buffer[178], buffer[181], buffer[180]}, 0);
                    apDiff = float.IsNaN(apDiff) ? 0 : apDiff;

                    LocalArchives.Add(new ValueInfo
                    {
                        PeriodType = periodType,
                        DeviceParameterId = (int)DeviceParameter.TV7_APDiff,
                        Time = archiveTime,
                        Value = (decimal)apDiff,
                        MeasurementDeviceId = MeasurementDevice.Id,
                        IsValid = true
                    });

                    ArchiveCollector.CreateArchives(LocalArchives);

                    if (!ArchiveCollector.SaveArchives())
                    {
                        throw new Exception(string.Format(DeviceMessages.SaveArchiveError, periodType, archiveTime));
                    }
                }
            }
        }

        /// <summary>
        /// Создает из полученного пакета архивы по тепловому вводу
        /// </summary>
        /// <param name="archiveTime">Время архива</param>
        /// <param name="periodType">Тип периода</param>
        /// <param name="inputNumber">Номер теплового ввода</param>
        private void CreateHeatInputArchive(byte[] buf, DateTime archiveTime, Common.Types.Proxy.PeriodType periodType,
            int inputNumber)
        {
            int offset = 36 * (inputNumber - 1);

            // температура наружного воздуха
            var toa = BitConverter.ToSingle(new[] {buf[107 + offset], buf[106 + offset], buf[109 + offset], buf[108 + offset]}, 0);
            toa = float.IsNaN(toa) ? 0 : toa;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)toa,
                DeviceParameterId = GetParamId(Tv7Resources.toa, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // температура холодной воды
            var tx = BitConverter.ToSingle(new[] {buf[111 + offset], buf[110 + offset], buf[113 + offset], buf[112 + offset]}, 0);
            tx = float.IsNaN(tx) ? 0 : tx;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)tx,
                DeviceParameterId = GetParamId(Tv7Resources.tx, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // давление холодной воды
            var px = BitConverter.ToSingle(new[] {buf[115 + offset], buf[114 + offset], buf[117 + offset], buf[116 + offset]}, 0);
            px = float.IsNaN(px) ? 0 : px;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)px,
                DeviceParameterId = GetParamId(Tv7Resources.Px, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // разность температур
            var dt = BitConverter.ToSingle(new[] {buf[119 + offset], buf[118 + offset], buf[121 + offset], buf[120 + offset]}, 0);
            dt = float.IsNaN(dt) ? 0 : dt;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)dt,
                DeviceParameterId = GetParamId(Tv7Resources.dt, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // разность масс
            var dM = BitConverter.ToSingle(new[] {buf[123 + offset], buf[122 + offset], buf[125 + offset], buf[124 + offset]}, 0);
            dM = float.IsNaN(dM) ? 0 : dM;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)dM,
                DeviceParameterId = GetDiffParamId(Tv7Resources.dM, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // тепло по тепловому вводу
            var qtv = BitConverter.ToSingle(new[] {buf[127 + offset], buf[126 + offset], buf[129 + offset], buf[128 + offset]}, 0);
            qtv = float.IsNaN(qtv) ? 0 : qtv;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)qtv,
                DeviceParameterId = GetDiffParamId(Tv7Resources.Qtv, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // тепло контура труб 1,2
            var q12 = BitConverter.ToSingle(new[] {buf[131 + offset], buf[130 + offset], buf[133 + offset], buf[132 + offset]}, 0);
            q12 = float.IsNaN(q12) ? 0 : q12;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)q12,
                DeviceParameterId = GetDiffParamId(Tv7Resources.Q12, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // тепло горячего водоснабжения
            var qg = BitConverter.ToSingle(new[] {buf[135 + offset], buf[134 + offset], buf[137 + offset], buf[136 + offset]}, 0);
            qg = float.IsNaN(qg) ? 0 : qg;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)qg,
                DeviceParameterId = GetDiffParamId(Tv7Resources.Qg, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // время нормальной работы
            var tNorm = BitConverter.ToInt16(new[] {buf[139 + offset], buf[138 + offset]}, 0);

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)tNorm,
                DeviceParameterId = GetDiffParamId(Tv7Resources.Tnorm, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // время отсутствия счета
            var tDen = BitConverter.ToInt16(new[] {buf[141 + offset], buf[140 + offset]}, 0);

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)tDen,
                DeviceParameterId = GetDiffParamId(Tv7Resources.Tden, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });
        }

        /// <summary>
        /// Создает из полученного пакета архивы по трубе
        /// </summary>
        /// <param name="archiveTime">Время архива</param>
        /// <param name="periodType">Тип периода</param>
        /// <param name="pipeNumber">Номер трубы</param>
        private void CreatePipeArchive(byte[] buf, DateTime archiveTime, Common.Types.Proxy.PeriodType periodType, int pipeNumber)
        {
            int offset = 16 * (pipeNumber - 1);

            // средняя температура на интервале
            var t = BitConverter.ToSingle(new[] {buf[11 + offset], buf[10 + offset], buf[13 + offset], buf[12 + offset]}, 0);
            t = float.IsNaN(t) ? 0 : t;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)t,
                DeviceParameterId = GetParamId(Tv7Resources.t, pipeNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // среднее давление на интервале
            var p = BitConverter.ToSingle(new[] {buf[15 + offset], buf[14 + offset], buf[17 + offset], buf[16 + offset]}, 0);
            p = float.IsNaN(p) ? 0 : p;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)p,
                DeviceParameterId = GetParamId(Tv7Resources.P, pipeNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // потребленный объем на интервале
            var v = BitConverter.ToSingle(new[] {buf[19 + offset], buf[18 + offset], buf[21 + offset], buf[20 + offset]}, 0);
            v = float.IsNaN(v) ? 0 : v;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)v,
                DeviceParameterId = GetDiffParamId(Tv7Resources.V, pipeNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // потребленная масса на интервале
            var m = BitConverter.ToSingle(new[] {buf[23 + offset], buf[22 + offset], buf[25 + offset], buf[24 + offset]}, 0);
            m = float.IsNaN(m) ? 0 : m;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = periodType,
                Value = (decimal)m,
                DeviceParameterId = GetDiffParamId(Tv7Resources.M, pipeNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });
        }

        /// <summary>
        /// Создает из полученного пакета итоговые архивы по трубе
        /// </summary>
        /// <param name="archiveTime">Время архива</param>
        /// <param name="pipeNumber">Номер трубы</param>
        private void CreatePipeFinalArchive(byte[] buf, DateTime archiveTime, int pipeNumber)
        {
            int offset = 16 * (pipeNumber - 1);

            var vSum  = BitConverter.ToDouble(new[] {buf[11 + offset], buf[10 + offset], buf[13 + offset], buf[12 + offset], buf[15 + offset], buf[14 + offset], buf[17 + offset], buf[16 + offset] }, 0);
            vSum = double.IsNaN(vSum) ? 0 : vSum;

            // объем нарастающим итогом
            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)vSum,
                DeviceParameterId = GetSumParamId(Tv7Resources.V, pipeNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            // формирование месячных интеграторов, если настал день отчета
            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)vSum,
                    DeviceParameterId = GetSumParamId(Tv7Resources.V, pipeNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }

            var mSum = BitConverter.ToDouble(new[] { buf[19 + offset], buf[18 + offset], buf[21 + offset], buf[20 + offset], buf[23 + offset], buf[22 + offset], buf[25 + offset], buf[24 + offset] }, 0);
            mSum = double.IsNaN(mSum) ? 0 : mSum;

            // масса нарастающим итогом
            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)mSum,
                DeviceParameterId = GetSumParamId(Tv7Resources.M, pipeNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)mSum,
                    DeviceParameterId = GetSumParamId(Tv7Resources.M, pipeNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }
        }

        private void CreateHeatInputFinalArchive(byte[] buf, DateTime archiveTime, int inputNumber)
        {
            int offset = 46 * (inputNumber - 1);

            // разность масс нарастающим итогом
            var dM = BitConverter.ToDouble(new[] {buf[107 + offset], buf[106 + offset], buf[109 + offset], buf[108 + offset], buf[111 + offset], buf[110 + offset], buf[113 + offset], buf[112 + offset]}, 0);
            dM = double.IsNaN(dM) ? 0 : dM;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal) dM,
                DeviceParameterId = GetSumParamId(Tv7Resources.dM, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)dM,
                    DeviceParameterId = GetSumParamId(Tv7Resources.dM, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }

            // тепло по тепловому вводу нарастающим итогом
            var qtv =
                BitConverter.ToDouble(new[] {buf[115 + offset], buf[114 + offset], buf[117 + offset], buf[116 + offset], buf[119 + offset], buf[118 + offset], buf[121 + offset], buf[120 + offset]}, 0);
            qtv = double.IsNaN(qtv) ? 0 : qtv;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal) qtv,
                DeviceParameterId = GetSumParamId(Tv7Resources.Qtv, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)qtv,
                    DeviceParameterId = GetSumParamId(Tv7Resources.Qtv, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }


            // тепло контура труб 1,2 нарастающим итогом
            var q12 =
                BitConverter.ToDouble(new[] {buf[123 + offset], buf[122 + offset], buf[125 + offset], buf[124 + offset], buf[127 + offset], buf[126 + offset], buf[129 + offset], buf[128 + offset]}, 0);
            q12 = double.IsNaN(q12) ? 0 : q12;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)q12,
                DeviceParameterId = GetSumParamId(Tv7Resources.Q12, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)q12,
                    DeviceParameterId = GetSumParamId(Tv7Resources.Q12, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }

            // тепло горячего водоснабжения нарастающим итогом
            var qG =
                BitConverter.ToDouble(new[] {buf[131 + offset], buf[130 + offset], buf[133 + offset], buf[132 + offset], buf[135 + offset], buf[134 + offset], buf[137 + offset], buf[136 + offset]}, 0);
            qG = double.IsNaN(qG) ? 0 : qG;

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)qG,
                DeviceParameterId = GetSumParamId(Tv7Resources.Qg, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)qG,
                    DeviceParameterId = GetSumParamId(Tv7Resources.Qg, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }

            // время нормальной работы нарастающим итогом
            var tNorm = BitConverter.ToInt16(new[] {buf[139 + offset], buf[138 + offset]}, 0);

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)tNorm,
                DeviceParameterId = GetSumParamId(Tv7Resources.Tnorm, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)tNorm,
                    DeviceParameterId = GetSumParamId(Tv7Resources.Tnorm, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }

            // время отсутствия счета нарастающим итогом
            var tDen = BitConverter.ToInt16(new[] {buf[141 + offset], buf[140 + offset]}, 0);

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)tDen,
                DeviceParameterId = GetSumParamId(Tv7Resources.Tden, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)tDen,
                    DeviceParameterId = GetSumParamId(Tv7Resources.Tden, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }

            // время при НС V<min нарастающим итогом
            var tvMin = BitConverter.ToInt16(new[] {buf[143 + offset], buf[142 + offset]}, 0);

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)tvMin,
                DeviceParameterId = GetSumParamId(Tv7Resources.TVmin, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)tvMin,
                    DeviceParameterId = GetSumParamId(Tv7Resources.TVmin, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }

            // время при НС V>max нарастающим итогом
            var tvMax = BitConverter.ToInt16(new[] {buf[145 + offset], buf[144 + offset]}, 0);
            
            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)tvMax,
                DeviceParameterId = GetSumParamId(Tv7Resources.TVmax, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)tvMax,
                    DeviceParameterId = GetSumParamId(Tv7Resources.TVmax, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }

            // время при НС по dt нарастающим итогом
            var tdt = BitConverter.ToInt16(new[] {buf[147 + offset], buf[146 + offset]}, 0);

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)tdt,
                DeviceParameterId = GetSumParamId(Tv7Resources.Tdt, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)tdt,
                    DeviceParameterId = GetSumParamId(Tv7Resources.Tdt, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }

            // время отключения внешнего сетевого питания нарастающим итогом
            var tPo = BitConverter.ToInt16(new[] {buf[149 + offset], buf[148 + offset]}, 0);

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)tPo,
                DeviceParameterId = GetSumParamId(Tv7Resources.Tpo, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)tPo,
                    DeviceParameterId = GetSumParamId(Tv7Resources.Tpo, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }

            // время неисправности t1 или t2
            var ttDen = BitConverter.ToInt16(new[] {buf[151 + offset], buf[150 + offset]}, 0);

            LocalArchives.Add(new ValueInfo
            {
                PeriodType = CommonPeriodType.Day,
                Value = (decimal)ttDen,
                DeviceParameterId = GetSumParamId(Tv7Resources.Ttden, inputNumber),
                Time = archiveTime,
                MeasurementDeviceId = MeasurementDevice.Id,
                IsValid = true
            });

            if (archiveTime.Day == 25)
            {
                LocalArchives.Add(new ValueInfo
                {
                    PeriodType = CommonPeriodType.Month,
                    Value = (decimal)ttDen,
                    DeviceParameterId = GetSumParamId(Tv7Resources.Ttden, inputNumber),
                    Time = archiveTime,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    IsValid = true
                });
            }
        }
    }
}

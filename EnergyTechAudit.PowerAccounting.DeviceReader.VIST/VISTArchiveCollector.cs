using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using Ex = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions.BaseExtensions;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System.Reflection;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types.Precisions;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST
{
    public partial class VIST
    {
        private void ReadArchives()
        {
            for(var systemNumber = 1; systemNumber <= _systemsCount; systemNumber++)
            {
                var archiveInfo = _archiveInfo.FirstOrDefault(p => p.SystemNumber == systemNumber);

                if (archiveInfo != null)
                {
                    _actionSteps.GetArchiveHeaderSystem(systemNumber);
                    archiveInfo.ArchiveLen = Transport.Buffer[11];

                    // для начала сохраняем тотальные параметры в нужный час, если они еще не были сохранены
                    SaveTotalParameters(archiveInfo);

                    int diffDeviceParameterId = GetFirstDiffDeviceParameterId(archiveInfo.ArchiveHeatSystemParams, systemNumber);

                    if (diffDeviceParameterId != 0)
                    {
                        var lastPeriodArchive = GetLastArchiveByPeriod(PeriodType.Hour, (a) => a.DeviceParameterId == diffDeviceParameterId && a.MeasurementDeviceId == MeasurementDevice.Id); 

                        var startDate = default(DateTime);
                        var endDate = archiveInfo.RefreshDate.AddHours(-1);

                        if (lastPeriodArchive == null)
                        {
                            if (archiveInfo.ArchiveRecordCount > 10)
                            {
                                startDate = archiveInfo.RefreshDate.AddHours((double)-archiveInfo.ArchiveRecordCount + 11);
                            }
                            else
                            {
                                startDate = archiveInfo.RefreshDate.AddHours((double)-archiveInfo.ArchiveRecordCount + 1);
                            }
                        }
                        else
                        {
                            startDate = lastPeriodArchive.Time.AddHours(1);
                        }

                        var archiveRegistersCount = (archiveInfo.ArchiveLen + 1) / 2;

                        var archiveAddressMapHelper = new ArchiveAddressMapHelper(archiveInfo.MaxArchiveRecord, archiveInfo.ArchiveRecordCount, archiveInfo.NextRecordIndex, archiveInfo.RefreshDate);

                        for (var archiveTime = startDate; archiveTime <= endDate; archiveTime = archiveTime.AddHours(1))
                        {
                            var index = archiveAddressMapHelper.GetIndexByDate(archiveTime);

                            if (index != -1)
                            {
#if DEBUG
                                Console.WriteLine(string.Format("Дата {1}. Читаю индекс {0}", index, archiveTime));
#endif
                                _actionSteps.ReadArchiveByIndex(systemNumber, (ushort)index, (ushort)archiveRegistersCount);
                                var archiveBytes = Transport.Buffer.Take(Transport.Buffer.Length - 2).ToArray();
                                Array.Reverse(archiveBytes);
                                archiveBytes = archiveBytes.Take(archiveBytes.Length - 5).ToArray();
                                Array.Reverse(archiveBytes);

                                // берем первый байт контрольной суммы
                                var checkSum = archiveBytes[0];

                                // отщепляем байт контрольной суммы и оставляем чистый массив архивных значений
                                Array.Reverse(archiveBytes);
                                archiveBytes = archiveBytes.Take(archiveBytes.Length - 1).ToArray();
                                Array.Reverse(archiveBytes);
                                var calcCheckSum = archiveBytes.SumCrc();

                                if (checkSum == calcCheckSum)
                                {
#if DEBUG
                                    Console.WriteLine("Контрольная сумма совпала");
#endif
                                    ParseAndSaveArchives(archiveBytes, archiveInfo, archiveTime);
                                }
                                else
                                {
                                    throw new Exception(DeviceMessages.WrongCheckSum);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ParseAndSaveArchives(byte[] buf, ArchiveInfo archiveInfo, DateTime archiveTime)
        {
            LocalArchives.Clear();

            int offset = -1;
            int deviceParameterId = 0;
            decimal value = decimal.MinValue;

            foreach (var aph in ArchiveParametersHelper.ParameterDescriptions)
            {
                if (archiveInfo.ArchiveHeatSystemParams.HasFlag(aph.ArchiveHeatSystemParams))
                {
                    offset += aph.Size;
                    deviceParameterId = 0;
                    value = decimal.MinValue;

                    if (aph.IsIncrease)
                    {
                        deviceParameterId = GetDiffDeviceParameterId(aph.Name, archiveInfo.SystemNumber);
                    }
                    else
                    {
                        deviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.VISTSystemArchive, aph.Name, archiveInfo.SystemNumber));
                    }

                    if (aph.ParseType.Equals(Resources.Common.Byte, StringComparison.Ordinal))
                    {
                        value = buf[offset];
                    }
                    else if (aph.ParseType.Equals(Resources.Common.ToInt32, StringComparison.Ordinal))
                    {
                        value = BitConverter.ToInt32(new byte[] { buf[offset], buf[offset - 1], buf[offset - 2], buf[offset - 3] }, 0);
                    }
                    else if (aph.ParseType.Equals(Resources.Common.ToInt16, StringComparison.Ordinal))
                    {
                        value = BitConverter.ToInt16(new byte[] { buf[offset], buf[offset - 1] }, 0);
                    }

                    int precision = 0;
                    if (aph.IsExternalPrecision)
                    {
                        var propertyInfo = typeof(FinalInstantParamsPrecisions).GetProperty(aph.PrecisionName);
                        if (propertyInfo != null)
                        {
                            precision = (int)propertyInfo.GetValue(archiveInfo.Precisions);
                        }
                    }
                    else
                    {
                        precision = aph.Precision;
                    }

                    value = value / (decimal)Math.Pow(10, precision);

                    if (deviceParameterId != 0 && value != decimal.MinValue)
                    {
                        LocalArchives.Add(new ValueInfo
                        {
                            PeriodType = PeriodType.Hour,
                            DeviceParameterId = deviceParameterId,
                            Value = value,
                            MeasurementDeviceId = MeasurementDevice.Id,
                            Time = archiveTime
                        });
                    }
                    else
                    {
                        throw new Exception(string.Format(VistResources.InvalidArchive, archiveTime));
                    }

                    
                }
            }

            ArchiveCollector.CreateArchives(LocalArchives);

            if (!ArchiveCollector.SaveArchives())
            {
                // поиск дубликата
                var archive = LocalArchives.First();
                var lastArchive = GetLastArchiveByPeriod(PeriodType.Hour, (a) => a.DeviceParameterId == archive.DeviceParameterId &&
                                                            a.MeasurementDeviceId == MeasurementDevice.Id &&
                                                            a.Time == archiveTime);

                if (lastArchive == null)
                {
                    throw new Exception(string.Format(DeviceMessages.SaveArchiveError, PeriodType.Hour, archiveTime));
                }
            }
        }


        /// <summary>
        /// Возвращает идентификатор любого диф-параметра архива, который присутствует в записи
        /// </summary>
        /// <param name="archiveHeatSystemParams">Маска присутствующих параметров</param>
        /// <param name="systemNumber">Номер системы</param>
        /// <returns></returns>
        private int GetFirstDiffDeviceParameterId(ArchiveHeatSystemParams archiveHeatSystemParams, int systemNumber)
        {
            int deviceParameterId = 0;
            foreach(var apd in ArchiveParametersHelper.ParameterDescriptions)
            {
                if (archiveHeatSystemParams.HasFlag(apd.ArchiveHeatSystemParams) && apd.IsIncrease)
                {
                    deviceParameterId = GetDiffDeviceParameterId(apd.Name, systemNumber);
                    break;
                }
            }

            return deviceParameterId;
        }

        private int GetDiffDeviceParameterId(string name, int systemNumber)
        {
            return Ex.GetDeviceParameterIdByName(string.Format(VistResources.VISTDiffSystemArchive, name, systemNumber));
        }


        private void SaveTotalParameters(ArchiveInfo archiveInfo)
        {
            LocalArchives.Clear();
            var dynamicParameter = Ex.GetDynamicParameterByName(string.Format(VistResources.DeviceLastSumArchiveTimeSystem, archiveInfo.SystemNumber));
            var lastSumArchiveTime = DynamicParameterHelper.GetDynamicValue<DateTime>(dynamicParameter);

            if (archiveInfo.RefreshDate > lastSumArchiveTime)
            {
                foreach(var archiveParameter in ArchiveParametersHelper.ParameterDescriptions)
                {
                    if (archiveInfo.ArchiveHeatSystemParams.HasFlag(archiveParameter.ArchiveHeatSystemParams) && archiveParameter.IsIncrease)
                    {
                        var propertyInfo = typeof(FinalInstantValuesForHour).GetProperty(archiveParameter.Name);
                        var value = (decimal)propertyInfo.GetValue(archiveInfo.FinalInstantValues);
                        LocalArchives.Add(new ValueInfo
                        {
                            DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(VistResources.VISTIncreaseSystemArchive, archiveParameter.Name, archiveInfo.SystemNumber)),
                            Value = value,
                            Time = archiveInfo.RefreshDate,
                            MeasurementDeviceId = MeasurementDevice.Id,
                            PeriodType = PeriodType.Hour,
                            IsValid = true
                        });
                    }
                }

                if (LocalArchives.Count > 0)
                {
                    ArchiveCollector.CreateArchives(LocalArchives);

                    if (ArchiveCollector.SaveArchives())
                    {
                        DynamicParameterHelper.SetDynamicParameter(dynamicParameter, archiveInfo.RefreshDate);
                    }
                    else
                    {
                        var deviceParameterId = LocalArchives.FirstOrDefault().DeviceParameterId;
                        var archive = Context.Set<Archive>().FirstOrDefault(p => p.PeriodTypeId == 2 && p.MeasurementDeviceId == MeasurementDevice.Id &&
                        p.Time == archiveInfo.RefreshDate &&  p.DeviceParameterId == deviceParameterId);

                        if (archive != null)
                        {
                            DynamicParameterHelper.SetDynamicParameter(dynamicParameter, archiveInfo.RefreshDate);
                        }
                    }
                }
            }
        }
    }
}

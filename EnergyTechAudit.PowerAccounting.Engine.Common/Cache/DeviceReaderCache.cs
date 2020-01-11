using System.Collections.Generic;
using System;
using System.Data;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.SystemSettings;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using Newtonsoft.Json;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Snips;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.HeatCurve;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Rules;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Admin;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using Db_DeviceReader = EnergyTechAudit.PowerAccounting.LightDataAccess.Business.DeviceReader;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache
{
    public class DeviceReaderCache
    {
        public List<ParameterMapDeviceParameter> ChannelTemplates { get; set; }
        public SignalrInfo SignalrInfo { get; set; }
        public SignalrInfo MobileMessagingSignalrInfo { get; set; }

        public HeatingSeason HeatingSeason { get; set; }

        public List<MeasurementUnitConverter> MeasurementUnitConverters { get; set; }

        public List<Dimension> Dimensions { get; set; }
        public List<District> Districts { get; set; }

        public List<City> Cities { get; set; }

        public ServerCommunicatorSettings ServerCommunicatorSettings { get; set; }

        public List<DeviceParameterSetting> DeviceParameterSettings { get; set; }

        public List<ParameterDictionaryValue> ParameterDictionaryValues { get; set; }

        /// <summary>
        /// Температурные графики
        /// </summary>
        public List<HeatCurve> HeatCurves { get; set; }

        public List<DynamicParameter> DynamicParameters { get; set; }

        /// <summary>
        /// Модели приборов
        /// </summary>
        public List<DeviceSnip> DeviceSnips { get; set; }

        /// <summary>
        /// Правила конвертации архивных времен приборов
        /// </summary>
        public List<DeviceArchiveTimeConverter> DeviceArchiveTimeConverters { get; set; }

        public List<TransportServerModel> TransportServerModels { get; set; }

        public List<Db_DeviceReader> DeviceReaders { get; set; }

        public List<CsdModem> CsdModems { get; set; }
        public List<MeasurementUnit> MeasurementUnits { get; set; }
        public List<Parameter> Parameters { get; set; }
        public List<PhysicalParameter> PhysicalParameters { get; set; }

        public List<UserLinkChannel> UserLinksChannel { get; set; }
        public List<MobileDevice> MobileDevices { get; set; }
        public List<Placement> Placements { get; set; }
        public List<Building> Buildings { get; set; }

        public DateTime LastUserLinkChannelSyncTime { get; set; }

        public List<UserLinkEmergencyNotificationType> MobileEmergencyNotifications { get; set; }
        

        // идентификатор измерительного устройства, являющегося метеостанцией
        public int? MeteoStationId { get; set; }

        public DeviceReaderCache(int deviceReaderId)
        {
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        DeviceReaders = context.Set<Db_DeviceReader>().ToList();

                        var deviceReader = DeviceReaders.FirstOrDefault(p => p.Id == deviceReaderId);
                        context.Set<User>().FirstOrDefault(p => p.Id == deviceReader.UserId);

                        ServerCommunicatorSettings serverCommunicatorSettings = null;

                        if (deviceReader != null)
                        {
                            serverCommunicatorSettings = new ServerCommunicatorSettings(deviceReader);
                        }

                        ChannelTemplates = context.Set<ParameterMapDeviceParameter>()
                                    .Include("Parameter")
                                    .Include("Dimension")
                                    .Include("MeasurementUnit")
                                    .ToList();
                        MeasurementUnitConverters = context.Set<MeasurementUnitConverter>()
                            .Include("MeasurementUnit1")
                            .Include("MeasurementUnit2")
                            .ToList();
                        Dimensions = context.Set<Dimension>().ToList();
                        Districts = context.Set<District>().ToList();
                        DeviceParameterSettings = context.Set<DeviceParameterSetting>().ToList();
                        ServerCommunicatorSettings = serverCommunicatorSettings;
                        DynamicParameters = context.Set<DynamicParameter>().ToList();
                        ParameterDictionaryValues = context.Set<ParameterDictionaryValue>().ToList();
                        MeasurementUnits = context.Set<MeasurementUnit>().ToList();
                        Parameters = context.Set<Parameter>().ToList();
                        PhysicalParameters = context.Set<PhysicalParameter>().ToList();
                        Cities = context.Set<City>().ToList();
                        UserLinksChannel = context.Set<UserLinkChannel>().ToList();
                        MobileDevices = context.Set<MobileDevice>().ToList();
                        Placements = context.Set<Placement>().ToList();
                        Buildings = context.Set<Building>().ToList();

                        LastUserLinkChannelSyncTime = DateTime.Now;

                        // инициализация идентификатора метеостанции
                        var meteoStation = context.Set<MeasurementDevice>().FirstOrDefault(p => p.DeviceId == (int)Types.Proxy.DeviceModel.MeteoStation);

                        if (meteoStation != null)
                        {
                            MeteoStationId = meteoStation.Id;
                        }

                        // поиск всех динамических значений, связанных с температурными графиками
                        var heatCurveDynamicParameters = context.Set<DynamicParameterValue>()
                            .Where(p => p.DynamicParameterId == (int)Types.Proxy.DynamicParameter.OrganizationHeatCurveSupplyPipe ||
                                        p.DynamicParameterId == (int)Types.Proxy.DynamicParameter.OrganizationHeatCurveReturnPipe).ToList();

                        // инициализация температурных графиков
                        var heatCurveHelper = new HeatCurveHelper(heatCurveDynamicParameters);
                        HeatCurves = heatCurveHelper.GetHeatCurves();

                        var systemSettings = context.Set<SystemSetting>().FirstOrDefault();

                        if (systemSettings != null)
                        {
                            var systemSettingFromCustomData =
                                JsonConvert.DeserializeObject<SystemSettingFromCustomData>(systemSettings.CustomData);

                            HeatingSeason = systemSettingFromCustomData.Analytics.HeatingSeason;
                        }

                        // служба рассылки сообщений
                        var deliveryService = context.Set<Db_DeviceReader>().FirstOrDefault(
                            p => p.DeviceReaderTypeId == (int)Types.Proxy.DeviceReaderType.Delivery);

                        if (deliveryService != null)
                        {
                            SignalrInfo = new SignalrInfo(deliveryService.SignalRNetAddress, deliveryService.SignalRPort, deliveryService.SignalRHub);
                        }

                        // служба отправки сообщений мобильным клиентам
                        var mobileMessageService = context.Set<Db_DeviceReader>().FirstOrDefault(
                            p => p.DeviceReaderTypeId == (int)Types.Proxy.DeviceReaderType.MobileMessage);

                        if (mobileMessageService != null)
                        {
                            MobileMessagingSignalrInfo = new SignalrInfo(mobileMessageService.SignalRNetAddress, mobileMessageService.SignalRPort, mobileMessageService.SignalRHub);
                        }

                        // подписки на оповещения нештаток для мобилок
                        MobileEmergencyNotifications = context.Set<UserLinkEmergencyNotificationType>().Where(p => p.NotificationTypeId == 3).ToList();

                        // подгрузка в кэш основных сущностей
                        // модели приборов
                        DeviceSnips = context.Set<Device>().Select(
                            p => new DeviceSnip
                            {
                                Id = p.Id,
                                ArchiveDepthHour = p.ArchiveDepthHour,
                                ArchiveDepthDay = p.ArchiveDepthDay,
                                ArchiveDepthMonth = p.ArchiveDepthMonth,
                                Code = p.Code,
                                IsIntegralArchiveValue = p.IsIntegralArchiveValue,
                                BaudId = p.BaudId,
                                ParityId = p.ParityId,
                                StopBitId = p.StopBitId,
                                DataBitId = p.DataBitId
                            }).ToList();

                        // правила конвертации архивных времен приборов
                        DeviceArchiveTimeConverters = context.Set<DeviceArchiveTimeConverter>().ToList();
                        // модели транспортных серверов
                        TransportServerModels = context.Set<TransportServerModel>().ToList();

                        CsdModems = context.Set<CsdModem>().ToList();

                        tran.Commit();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("Ошибка инициализации кэша службы считывателей");
                    }
                }
            }
        }

        /// <summary>
        /// Синхронизирует каждые 15 минут списки каналов пользователей и их мобильных устройств
        /// </summary>
        public void UserLinkChannelSync()
        {
            if ((DateTime.Now - LastUserLinkChannelSyncTime).TotalMinutes > 15)
            {
                var userLinksChannel = new List<UserLinkChannel>();
                var mobileDevices = new List<MobileDevice>();
                var placements = new List<Placement>();
                var buildings = new List<Building>();

                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            userLinksChannel = context.Set<UserLinkChannel>().ToList();
                            mobileDevices = context.Set<MobileDevice>().ToList();
                            placements = context.Set<Placement>().ToList();
                            buildings = context.Set<Building>().ToList();
                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                        }
                    }
                }

                if (userLinksChannel != null && userLinksChannel.Count > 0)
                {
                    UserLinksChannel = userLinksChannel;
                }

                if (mobileDevices != null && mobileDevices.Count > 0)
                {
                    MobileDevices = mobileDevices;
                }

                if (placements != null && placements.Count > 0)
                {
                    Placements = placements;
                }

                if (buildings != null & buildings.Count > 0)
                {
                    Buildings = buildings;
                }

                LastUserLinkChannelSyncTime = DateTime.Now;
            }
        }
        public DeviceSnip GetDeviceSnip(int deviceId)
        {
            return DeviceSnips.First(p => p.Id == deviceId);
        }

        public TransportServerModel GetTransportServerModel(int id)
        {
            return TransportServerModels.First(p => p.Id == id);
        }

        public Db_DeviceReader GetDeviceReader(int deviceReaderId)
        {
            return DeviceReaders.First(p => p.Id == deviceReaderId);
        }

        public List<DeviceArchiveTimeConverter> GetDeviceArchiveTimeConverters(int deviceId)
        {
            return DeviceArchiveTimeConverters.Where(p => p.DeviceId == deviceId).ToList();
        }

        public CsdModem GetCsdModem(int csdModemId)
        {
            return CsdModems.First(p => p.Id == csdModemId);
        }

        /// <summary>
        /// Возвращает коэффициент размерности
        /// </summary>
        /// <param name="dimensionDescription">Приставка (мега, кило и т.д.)</param>
        /// <returns></returns>
        public decimal GetDimensionCoef(string dimensionDescription)
        {
            if (Dimensions != null && Dimensions.Any())
            {
                var dimension = Dimensions.FirstOrDefault(p => p.Description.Equals(dimensionDescription, StringComparison.Ordinal));

                if(dimension != null)
                {
                    return dimension.Value;
                }
            }

            return 1M;
        }
    }
}


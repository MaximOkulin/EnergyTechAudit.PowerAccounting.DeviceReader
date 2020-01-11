using EnergyTechAudit.PowerAccounting.LightDataAccess.Admin;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Rules;
using System.Data.Entity;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess
{
    public class LightDatabaseContext : DbContext, IDatabaseContext
    {
        static LightDatabaseContext()
        {
            Database.SetInitializer<LightDatabaseContext>(null);
        }

        public LightDatabaseContext() : base("Name=DatabaseContext")
        {
            Configuration.EnsureTransactionsForFunctionsAndCommands = true;

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Admin
            modelBuilder.Entity<EntityHistory>().ToTable("EntityHistory", "Admin");
            modelBuilder.Entity<SystemSetting>().ToTable("SystemSetting", "Admin");
            modelBuilder.Entity<User>().ToTable("User", "Admin");

            // Business
            modelBuilder.Entity<AccessPoint>().ToTable("AccessPoint", "Business");
            modelBuilder.Entity<AccessPointLinkBuilding>().ToTable("AccessPointLinkBuilding", "Business");
            modelBuilder.Entity<AccessPointStatusConnectionLog>().ToTable("AccessPointStatusConnectionLog", "Business");
            modelBuilder.Entity<Archive>().ToTable("Archive", "Business");
            modelBuilder.Entity<Building>().ToTable("Building", "Business");
            modelBuilder.Entity<Channel>().ToTable("Channel", "Business");
            modelBuilder.Entity<CsdModem>().ToTable("CsdModem", "Business");
            modelBuilder.Entity<DeviceEvent>().ToTable("DeviceEvent", "Business");
            modelBuilder.Entity<DeviceLinkDynamicParameter>().ToTable("DeviceLinkDynamicParameter", "Business");
            modelBuilder.Entity<DeviceParameterSetting>().ToTable("DeviceParameterSetting", "Business");
            modelBuilder.Entity<DeviceReader>().ToTable("DeviceReader", "Business");
            modelBuilder.Entity<DeviceReaderErrorLog>().ToTable("DeviceReaderErrorLog", "Business");
            modelBuilder.Entity<DeviceReaderLinkScheduleItem>().ToTable("DeviceReaderLinkScheduleItem", "Business");
            modelBuilder.Entity<DeviceTechnicalParameter>().ToTable("DeviceTechnicalParameter", "Business");
            modelBuilder.Entity<EmergencyLog>().ToTable("EmergencyLog", "Business");
            modelBuilder.Entity<EmergencyMessage>().ToTable("EmergencyMessage", "Business");
            modelBuilder.Entity<EmergencySituationParameter>().ToTable("EmergencySituationParameter", "Business");
            modelBuilder.Entity<EmergencyTimeSignature>().ToTable("EmergencyTimeSignature", "Business");
            modelBuilder.Entity<Hub>().ToTable("Hub", "Business");
            modelBuilder.Entity<IntegrationArchiveInfo>().ToTable("IntegrationArchiveInfo", "Business");
            modelBuilder.Entity<MeasurementDevice>().ToTable("MeasurementDevice", "Business");
            modelBuilder.Entity<MeasurementDeviceJournal>().ToTable("MeasurementDeviceJournal", "Business");
            modelBuilder.Entity<MeasurementDeviceStatusConnectionLog>().ToTable("MeasurementDeviceStatusConnectionLog", "Business");
            modelBuilder.Entity<ParameterMapDeviceParameter>().ToTable("ParameterMapDeviceParameter", "Business");
            modelBuilder.Entity<Placement>().ToTable("Placement", "Business");
            modelBuilder.Entity<RegulatorParameterValue>().ToTable("RegulatorParameterValue", "Business");
            modelBuilder.Entity<TimeSignature>().ToTable("TimeSignature", "Business");
            modelBuilder.Entity<UserAdditionalInfo>().ToTable("UserAdditionalInfo", "Business");
            modelBuilder.Entity<UserAdditionalInfoLinkScheduleItem>().ToTable("UserAdditionalInfoLinkScheduleItem", "Business");
            modelBuilder.Entity<UserLinkChannel>().ToTable("UserLinkChannel", "Business");
            modelBuilder.Entity<UserLinkEmergencyNotificationType>().ToTable("UserLinkEmergencyNotificationType", "Business");
            modelBuilder.Entity<MobileDevice>().ToTable("MobileDevice", "Business");
            modelBuilder.Entity<MobileEmergencyMessage>().ToTable("MobileEmergencyMessage", "Business");
            modelBuilder.Entity<MeasurementDeviceLinkScheduleItem>().ToTable("MeasurementDeviceLinkScheduleItem", "Business");

            // Core
            modelBuilder.Entity<DynamicParameterValue>().ToTable("DynamicParameterValue", "Core");
            modelBuilder.Entity<ScheduleItem>().ToTable("ScheduleItem", "Core");

            // Dictionaries
            modelBuilder.Entity<Baud>().ToTable("Baud", "Dictionaries");
            modelBuilder.Entity<City>().ToTable("City", "Dictionaries");
            modelBuilder.Entity<ComPort>().ToTable("ComPort", "Dictionaries");
            modelBuilder.Entity<DataBit>().ToTable("DataBit", "Dictionaries");
            modelBuilder.Entity<Device>().ToTable("Device", "Dictionaries");
            modelBuilder.Entity<DeviceEventParameter>().ToTable("DeviceEventParameter", "Dictionaries");
            modelBuilder.Entity<DeviceParameter>().ToTable("DeviceParameter", "Dictionaries");
            modelBuilder.Entity<DeviceReaderType>().ToTable("DeviceReaderType", "Dictionaries");
            modelBuilder.Entity<Dimension>().ToTable("Dimension", "Dictionaries");
            modelBuilder.Entity<District>().ToTable("District", "Dictionaries");
            modelBuilder.Entity<DynamicParameter>().ToTable("DynamicParameter", "Dictionaries");
            modelBuilder.Entity<InternalDeviceEvent>().ToTable("InternalDeviceEvent", "Dictionaries");
            modelBuilder.Entity<MeasurementUnit>().ToTable("MeasurementUnit", "Dictionaries");
            modelBuilder.Entity<MeteoDataSourceType>().ToTable("MeteoDataSourceType", "Dictionaries");
            modelBuilder.Entity<Parameter>().ToTable("Parameter", "Dictionaries");
            modelBuilder.Entity<ParameterDictionaryValue>().ToTable("ParameterDictionaryValue", "Dictionaries");
            modelBuilder.Entity<Parity>().ToTable("Parity", "Dictionaries");
            modelBuilder.Entity<PhysicalParameter>().ToTable("PhysicalParameter", "Dictionaries");
            modelBuilder.Entity<PortType>().ToTable("PortType", "Dictionaries");
            modelBuilder.Entity<ResourceSystemType>().ToTable("ResourceSystemType", "Dictionaries");
            modelBuilder.Entity<ScheduleType>().ToTable("ScheduleType", "Dictionaries");
            modelBuilder.Entity<StopBit>().ToTable("StopBit", "Dictionaries");
            modelBuilder.Entity<TransportServerModel>().ToTable("TransportServerModel", "Dictionaries");
                

            // Rules
            modelBuilder.Entity<MeasurementUnitConverter>().ToTable("MeasurementUnitConverter", "Rules");
            modelBuilder.Entity<DeviceArchiveTimeConverter>().ToTable("DeviceArchiveTimeConverter", "Rules");

            modelBuilder.Entity<Dimension>().Property(e => e.Value).HasPrecision(20, 7);
            modelBuilder.Entity<Archive>().Property(e => e.Value).HasPrecision(19, 7);

            modelBuilder.Entity<AccessPointLinkBuilding>().HasKey(k => new
            {
                k.AccessPointId,
                k.BuildingId
            });

            modelBuilder.Entity<DeviceLinkDynamicParameter>().HasKey(k => new
            {
                k.DeviceId,
                k.DynamicParameterId
            });

            modelBuilder.Entity<DeviceReaderLinkScheduleItem>().HasKey(k => new
            {
                k.DeviceReaderId,
                k.ScheduleItemId
            });

            modelBuilder.Entity<UserAdditionalInfoLinkScheduleItem>().HasKey(k => new
            {
                k.UserAdditionalInfoId,
                k.ScheduleItemId
            });

            modelBuilder.Entity<UserLinkChannel>().HasKey(k => new
            {
                k.UserId,
                k.ChannelId
            });

            modelBuilder.Entity<MeasurementDeviceLinkScheduleItem>().HasKey(k => new
            {
                k.MeasurementDeviceId,
                k.ScheduleItemId
            });

            modelBuilder.Entity<DeviceParameterSetting>().HasRequired(c => c.DeviceParameter);
        }

        IQueryable<T> IDatabaseContext.Set<T>()
        {
            return Set<T>();
        }
    }
}

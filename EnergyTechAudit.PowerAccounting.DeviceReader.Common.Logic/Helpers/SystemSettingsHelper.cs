using System.Data;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.SystemSettings;
using System.Linq;
using Newtonsoft.Json;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Admin;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic.Helpers
{
    /// <summary>
    /// Вспомогательный класс для работы с параметрами системы
    /// </summary>
    public class SystemSettingsHelper
    {
        /// <summary>
        /// Возвращает параметры системы
        /// </summary>
        public SystemSettingFromCustomData GetSettings()
        {
            SystemSettingFromCustomData settings = null;

            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var systemSetting = context.Set<SystemSetting>().FirstOrDefault();

                        if(systemSetting != null)
                        {
                            try
                            {
                                settings = JsonConvert.DeserializeObject<SystemSettingFromCustomData>(systemSetting.CustomData);
                            }
                            catch
                            {

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

            return settings;
        }
    }
}

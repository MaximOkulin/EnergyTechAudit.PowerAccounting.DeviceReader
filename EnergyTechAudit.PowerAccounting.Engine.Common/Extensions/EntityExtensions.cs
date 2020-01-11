using System.Data;
using System.Linq;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using DynamicParameter = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.DynamicParameter;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions
{
    public static class EntityExtensions
    {
        /// <summary>
        /// Возвращает значение динамического параметра из БД
        /// </summary>
        /// <param name="entity">Объект, реализующий интерфейс IEntity</param>
        /// <param name="dynamicParameter">Тип динамического параметра</param>
        public static DynamicParameterValue GetDynamicParameterValue(this IEntity entity, DynamicParameter dynamicParameter)
        {
            DynamicParameterValue result = null;
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        result = context.Set<DynamicParameterValue>()
                            .FirstOrDefault(
                                p =>
                                    p.EntityId == entity.Id && p.DynamicParameterId == (int)dynamicParameter);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }
            return result;
        }
    }
}

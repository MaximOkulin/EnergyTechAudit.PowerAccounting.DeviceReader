using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using Db_DynamicParameter = EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries.DynamicParameter;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    /// <summary>
    /// Класс, упрощающий работу с динамическими параметрами
    /// </summary>
    public class DynamicParameterHelper
    {
        private LightDatabaseContext _sidedContext;
        private static List<Db_DynamicParameter> _dynamicParameters;

        static DynamicParameterHelper()
        {
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        _dynamicParameters = context.Set<Db_DynamicParameter>().ToList();
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }
        }

        public DynamicParameterHelper(LightDatabaseContext context = null)
        {
            _sidedContext = context;
        }

        /// <summary>
        /// Возвращает значение динамического параметра
        /// </summary>
        /// <param name="dynamicParameter">Тип динамического параметра</param>
        /// <param name="entityId">Идентификатор сущности</param>
        public DynamicParameterValue GetDynamicParameterValue(DynamicParameter dynamicParameter, int entityId)
        {
            DynamicParameterValue dynamicParameterValue = null;

            if (_sidedContext != null)
            {
                dynamicParameterValue = _sidedContext.Set<DynamicParameterValue>()
                                .FirstOrDefault(p => p.DynamicParameterId == (int)dynamicParameter && p.EntityId == entityId);
            }
            else
            {
                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            dynamicParameterValue = context.Set<DynamicParameterValue>()
                                                           .FirstOrDefault(p => p.DynamicParameterId == (int)dynamicParameter && p.EntityId == entityId);
                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                        }
                    }
                }
            }

            return dynamicParameterValue;
        }

        /// <summary>
        /// Возвращает преобразованное значение динамического параметра в примитивный тип
        /// </summary>
        /// <typeparam name="T">Примитивный тип</typeparam>
        /// <param name="dynamicParameter">Тип динамического параметра</param>
        /// <param name="entityId">Идентификатор сущности</param>
        public T GetDynamicValue<T>(DynamicParameter dynamicParameter, int entityId)
        {
            var dynamicParameterTemplate = _dynamicParameters.First(p => p.Id == (int)dynamicParameter);
            var type = typeof(Convert);
            var method = type.GetMethod(string.Format("To{0}", dynamicParameterTemplate.Type), new[] { typeof(object), typeof(IFormatProvider) });
            
            var dynamicValue = GetDynamicParameterValue(dynamicParameter, entityId);

            string value = string.Empty;

            if(dynamicValue != null)
            {
                value = dynamicValue.Value;
            }
            else
            {
                value = dynamicParameterTemplate.DefaultValue;
            }
           
            return (T)method.Invoke(null, new object[] { value, CultureInfo.InvariantCulture });
        }
    }
}

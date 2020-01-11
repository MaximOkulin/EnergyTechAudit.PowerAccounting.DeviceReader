using System;
using System.Data;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic
{
    /// <summary>
    /// Вспомогательный класс, хранящий сведения о первоначальной инициализации прибора
    /// (используется в приборах, типа регулятор)
    /// </summary>
    public class DeviceInitiator
    {
        public DynamicParameterValue InitDateValue;
        public DynamicParameterValue IsInitValue;
        private readonly int _measurementDeviceId;
        private readonly LightDatabaseContext _context;

        public DeviceInitiator(int measurementDeviceId)
        {
            _measurementDeviceId = measurementDeviceId;
            _context = new LightDatabaseContext();
            _context.Configuration.AutoDetectChangesEnabled = true;
        }

        public bool IsNeedToInit
        {
            get { return !Convert.ToBoolean(IsInitValue.Value); }
        }

        public void InitDynamicParameters()
        {

            using (var tran = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    InitDateValue =
                        _context.Set<DynamicParameterValue>().FirstOrDefault(
                            p => p.DynamicParameterId == (int) DynamicParameter.DeviceInitDate &&
                                 p.EntityId == _measurementDeviceId);

                    IsInitValue =
                        _context.Set<DynamicParameterValue>().FirstOrDefault(
                            p => p.DynamicParameterId == (int) DynamicParameter.DeviceIsInit &&
                                 p.EntityId == _measurementDeviceId);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw new Exception(DeviceMessages.DynamicDataReadError);
                }
            }

            // создаем динамические параметры, если их нет
            if (InitDateValue == null)
            {
                InitDateValue = new DynamicParameterValue
                {
                    DynamicParameterId = (int) DynamicParameter.DeviceInitDate,
                    EntityId = _measurementDeviceId,
                    Value = "0001-01-01T00:00:00"
                };
                _context.Set<DynamicParameterValue>().Add(InitDateValue);
            }

            if (IsInitValue == null)
            {
                IsInitValue = new DynamicParameterValue
                {
                    DynamicParameterId = (int) DynamicParameter.DeviceIsInit,
                    EntityId = _measurementDeviceId,
                    Value = "false"
                };
                _context.Set<DynamicParameterValue>().Add(IsInitValue);
            }

            using (var tran = _context.Database.BeginTransaction(IsolationLevel.Snapshot))
            {
                try
                {
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw new Exception(DeviceMessages.DynamicDataCreateError);
                }
            }
        }

        public void SaveChanges()
        {
            using (var tran = _context.Database.BeginTransaction(IsolationLevel.Snapshot))
            {
                try
                {
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
        }
    }
}

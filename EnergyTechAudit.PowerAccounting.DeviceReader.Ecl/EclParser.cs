using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl
{
    public class EclParser
    {
        private readonly MeasurementDevice _mDevice;
        protected readonly ITransport Transport;

        protected byte[] Buffer
        {
            get { return Transport.Buffer; }
        }

        protected MeasurementDevice MDevice
        {
            get { return _mDevice; }
        }

        public EclParser(ITransport iTransport, MeasurementDevice mDevice)
        {
            Transport = iTransport;
            _mDevice = mDevice;
        }

        protected void UpdateRegulatorParameter(DeviceParameter deviceParameter, object value)
        {
            var param =
               _mDevice.RegulatorParameterValues.FirstOrDefault(p => p.DeviceParameterId == (int)deviceParameter);

            // обновляем параметр
            if (param != null)
            {
                param.DeviceValue = Convert.ToDecimal(value);
                param.UserValue = Convert.ToDecimal(value);
                param.SyncDeviceTime = DateTime.Now;
            }
            // создаем параметр
            else
            {
                _mDevice.RegulatorParameterValues.Add(new RegulatorParameterValue
                {
                    DeviceParameterId = (int)deviceParameter,
                    DeviceValue = Convert.ToDecimal(value),
                    UserValue = Convert.ToDecimal(value),
                    SyncDeviceTime = DateTime.Now,
                    MeasurementDeviceId = _mDevice.Id,
                    CreatedBy = DeviceMessages.DeviceReaderUser,
                    UpdatedBy = DeviceMessages.DeviceReaderUser,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
            }
        }
    }
}

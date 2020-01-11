using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.IISInteraction
{
    public class Ecl310Communicator : ServerCommunicator
    {
        public Ecl310Communicator(string userName, ServerCommunicatorSettings settings): base(userName, settings)
        {
        }


        public void SetValue(RegulatorParameterValue regulatorParameterValue)
        {
            /*
            var ecl310 = new Ecl310(regulatorParameterValue);
            var result = ecl310.ExecuteCustomAction(ecl310.SetRegulatorParameterValue);
            SendResponse(result, regulatorParameterValue);
            */
        }
    }
}

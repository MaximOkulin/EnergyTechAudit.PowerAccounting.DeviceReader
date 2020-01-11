using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public class InstallServiceHelper
    {
        public static void ParseServiceNameSwitches(string[] commandlineArgs, out string servicename,
            out string servicedisplayname)
        {
            string serviceNameVal = string.Empty;
            string serviceDisplayNameVal = string.Empty;

            foreach (var args in commandlineArgs)
            {
                var parts = args.Split('=');

                if (parts[0].Contains("servicename"))
                {
                    serviceNameVal = parts[1];
                }
                else if (parts[0].Contains("servicedisplayname"))
                {
                    serviceDisplayNameVal = parts[1];
                }
            }

            servicename = serviceNameVal;
            servicedisplayname = serviceDisplayNameVal;

            if (string.IsNullOrEmpty(servicename) || string.IsNullOrEmpty(servicedisplayname))
            {
                throw new Exception(TraceMessages.WrongInstallServiceKeys);
            }
        }
    }
}

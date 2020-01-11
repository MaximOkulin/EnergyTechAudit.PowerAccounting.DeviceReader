namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.API
{
    internal sealed class CallbackFunctions
    {
        public static object GetDataCallback(byte[] buffer, GetDataMode mode, int serverType = -1)
        {
            if (mode == GetDataMode.ServerType)
            {
                return Parser.ParseServerType(buffer);
            }
            if (mode == GetDataMode.Properties)
            {
                return Parser.ParsePropertiesElementsList(buffer, serverType);
            }
            return null;
        }
    }
}

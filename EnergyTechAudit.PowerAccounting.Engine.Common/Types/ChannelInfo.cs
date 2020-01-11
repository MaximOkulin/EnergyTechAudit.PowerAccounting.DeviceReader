namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public class ChannelInfo
    {
        public int Id;
        public int Number;

        public ChannelInfo(int id, int number)
        {
            Id = id;
            Number = number;
        }
    }
}

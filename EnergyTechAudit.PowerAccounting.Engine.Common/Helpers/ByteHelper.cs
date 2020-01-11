namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public class ByteHelper
    {
        /// <summary>
        /// Массив байтов CR-LF (Возврат каретки-Перевод строки)
        /// </summary>
        public static byte[] CrLf
        {
            get
            {
                return new byte[] {0x0D, 0x0A};
            }
        }
    }
}

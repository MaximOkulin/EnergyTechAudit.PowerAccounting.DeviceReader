using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    /// <summary>
    /// Версия ПО измерительного прибора
    /// </summary>
    public class Firmware
    {
        public int Major;
        public int SubMajor;
        public int Minor;
        public int SubMinor;
        private int partsCount;

        public string DeviceCode;

        public Firmware(int major, int minor)
        {
            Major = major;
            Minor = minor;
            partsCount = 2;
        }

        public Firmware(int major, int subMajor, int minor, int subMinor)
        {
            Major = major;
            SubMajor = subMajor;
            Minor = minor;
            SubMinor = subMinor;
            partsCount = 4;
        }

        public Firmware(int major, int subMajor, int minor, int subMinor, string deviceCode)
            :this(major, subMajor, minor, subMinor)
        {
            DeviceCode = deviceCode;
        }

        public static Firmware GetFirmwareFromString(string firmware, int partsCount = 2)
        {
            string[] firmwareParts = firmware.Split(new [] {'.'});
            if (partsCount == 2)
            {
                return new Firmware(Convert.ToInt32(firmwareParts[0]), Convert.ToInt32(firmwareParts[1]));
            }
            if (partsCount == 4)
            {
                return new Firmware(Convert.ToInt32(firmwareParts[0]), Convert.ToInt32(firmwareParts[1]),
                    Convert.ToInt32(firmwareParts[2]), Convert.ToInt32(firmwareParts[3]));
            }
            return null;
        }

        /// <summary>
        /// Проверяет, поддерживает ли данная версия ПО определенную возможность
        /// </summary>
        /// <param name="featureFirmware">Версия ПО, с которой поддерживается определенная возможность</param>
        /// <returns>true - поддерживается, false - не поддерживается</returns>
        public bool IsSupportFeature(Firmware featureFirmware)
        {
            if (partsCount == 2)
            {
                if (featureFirmware.Major < Major || (featureFirmware.Major == Major && featureFirmware.Minor <= Minor))
                {
                    return true;
                }
            }
            if (partsCount == 4)
            {
                if (featureFirmware.Major < Major ||
                    (featureFirmware.Major == Major && featureFirmware.SubMajor <= SubMajor) ||
                    (featureFirmware.Major == Major && featureFirmware.SubMajor == SubMajor &&
                     featureFirmware.Minor <= Minor) ||
                    (featureFirmware.Major == Major && featureFirmware.SubMajor == SubMajor &&
                     featureFirmware.Minor == Minor && featureFirmware.SubMinor <= SubMinor))
                {
                    return true;
                }
            }
            return false;
        }

        public new string ToString()
        {
            if (partsCount == 2)
            {
                return string.Format("{0}.{1}", Major, Minor);
            }
            if (partsCount == 4)
            {
                return string.Format("{0}.{1}.{2}.{3}", Major, SubMajor, Minor, SubMinor);
            }
            return string.Empty;
        }
    }
}

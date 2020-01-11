using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.EtaModem
{
    public class DataFormatDictionary
    {
        public static List<DataFormat> Formats = new List<DataFormat>
        {
            // 8-n-1
            new DataFormat { DataBit = "8", Parity = "None", StopBit = "One", FormatValue = 6 },
            new DataFormat { DataBit = "8", Parity = "Empty", StopBit = "One", FormatValue = 6 },
            // 8-n-2
            new DataFormat { DataBit = "8", Parity = "None", StopBit = "Two", FormatValue = 14 },
            new DataFormat { DataBit = "8", Parity = "Empty", StopBit = "Two", FormatValue = 14 },
            // 8-e-1
            new DataFormat { DataBit = "8", Parity = "Even", StopBit = "One", FormatValue = 38 },
            // 8-e-2
            new DataFormat { DataBit = "8", Parity = "Even", StopBit = "Two", FormatValue = 46 },
            // 8-o-1
            new DataFormat { DataBit = "8", Parity = "Odd", StopBit = "One", FormatValue = 54 },
            // 8-o-2
            new DataFormat { DataBit = "8", Parity = "Odd", StopBit = "Two", FormatValue = 62 },
            // 7-n-1
            new DataFormat { DataBit = "7", Parity = "None", StopBit = "One", FormatValue = 4 },
            // 7-e-1
            new DataFormat { DataBit = "7", Parity = "Even", StopBit = "One", FormatValue = 36 }
        };
    }
}

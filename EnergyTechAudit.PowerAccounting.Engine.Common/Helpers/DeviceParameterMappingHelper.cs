using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Integrating;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System.Collections.Generic;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public class DeviceParameterMappingHelper
    {
        /// <summary>
        /// Таблица сопоставлений параметров для ТСРВ ВЗЛЕТ-24M
        /// </summary>
        private static List<DeviceParameterMapping> _deviceParameterMappingVzljot24M = new List<DeviceParameterMapping>
        {
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_TimeNormal_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_TimeNormal_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_TimeNormal_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_TimeNormal_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_TimeNormal_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_TimeNormal_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_TimeNormal_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_TimeNormal_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_TimeNormal_HS3Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe1_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe1_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe1_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe2_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe2_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe2_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe3_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe3_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe3_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe4_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe4_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe4_HS1Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe1_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe1_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe1_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe2_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe2_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe2_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe3_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe3_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe3_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe4_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe4_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe4_HS2Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe1_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe1_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe1_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe2_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe2_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe2_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe3_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe3_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe3_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe4_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe4_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_MassPipe4_HS3Sum_Archive },


            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe1_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe1_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe1_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe2_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe2_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe2_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe3_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe3_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe3_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe4_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe4_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe4_HS1Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe1_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe1_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe1_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe2_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe2_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe2_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe3_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe3_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe3_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe4_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe4_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe4_HS2Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe1_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe1_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe1_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe2_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe2_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe2_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe3_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe3_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe3_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe4_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe4_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024M_VolumePipe4_HS3Sum_Archive }
        };

        /// <summary>
        /// Таблица сопоставлений параметров для ТСРВ ВЗЛЕТ-24
        /// </summary>
        private static List<DeviceParameterMapping> _deviceParameterMappingVzljot24 = new List<DeviceParameterMapping>
        {
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_TimeNormal_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_TimeNormal_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_TimeNormal_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_TimeNormal_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_TimeNormal_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_TimeNormal_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_TimeNormal_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_TimeNormal_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_TimeNormal_HS3Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_HeatTotal_HeatSystem1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_HeatTotal_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_HeatTotal_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_HeatTotal_HeatSystem2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_HeatTotal_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_HeatTotal_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_HeatTotal_HeatSystem3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_HeatTotal_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_HeatTotal_HS3Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_HeatWater_HeatSystem1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_HeatWater_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_HeatWater_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_HeatWater_HeatSystem2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_HeatWater_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_HeatWater_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_HeatWater_HeatSystem3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_HeatWater_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_HeatWater_HS3Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe1_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe1_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe1_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe2_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe2_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe2_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe3_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe3_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe3_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe4_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe4_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe4_HS1Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe1_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe1_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe1_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe2_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe2_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe2_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe3_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe3_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe3_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe4_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe4_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe4_HS2Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe1_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe1_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe1_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe2_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe2_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe2_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe3_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe3_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe3_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe4_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe4_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_MassPipe4_HS3Sum_Archive },


            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe1_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe1_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe1_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe2_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe2_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe2_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe3_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe3_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe3_HS1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe4_HS1_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe4_HS1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe4_HS1Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe1_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe1_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe1_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe2_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe2_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe2_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe3_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe3_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe3_HS2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe4_HS2_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe4_HS2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe4_HS2Sum_Archive },

            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe1_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe1_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe1_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe2_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe2_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe2_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe3_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe3_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe3_HS3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe4_HS3_FinInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe4_HS3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_024_VolumePipe4_HS3Sum_Archive }
        };

        /// <summary>
        /// Таблица сопоставлений параметров для ТСРВ ВЗЛЕТ-26
        /// </summary>
        private static List<DeviceParameterMapping> _deviceParameterMappingVzljot26 = new List<DeviceParameterMapping>
        {
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026_TimeNormal_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026_TimeNormal_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026_TimeNormalSum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026_Mass1_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026_MassPipe1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026_MassPipe1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026_Mass2_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026_MassPipe2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026_MassPipe2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026_Mass3_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026_MassPipe3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026_MassPipe3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026_Mass4_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026_MassPipe4_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026_MassPipe4Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026_Volume1_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026_VolumePipe1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026_VolumePipe1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026_Volume2_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026_VolumePipe2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026_VolumePipe2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026_Volume3_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026_VolumePipe3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026_VolumePipe3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026_Volume4_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026_VolumePipe4_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026_VolumePipe4Sum_Archive }
        };

        /// <summary>
        /// Таблица сопоставлений параметров для ТСРВ ВЗЛЕТ-26M
        /// </summary>
        private static List<DeviceParameterMapping> _deviceParameterMappingVzljot26M = new List<DeviceParameterMapping>
        {
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026M_TimeNormal_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026M_TimeNormal_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026M_TimeNormalSum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026M_Mass1_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026M_MassPipe1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026M_MassPipe1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026M_Mass2_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026M_MassPipe2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026M_MassPipe2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026M_Mass3_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026M_MassPipe3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026M_MassPipe3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026M_Mass4_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026M_MassPipe4_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026M_MassPipe4Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026M_Volume1_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026M_VolumePipe1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026M_VolumePipe1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026M_Volume2_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026M_VolumePipe2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026M_VolumePipe2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026M_Volume3_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026M_VolumePipe3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026M_VolumePipe3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_026M_Volume4_FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_026M_VolumePipe4_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_026M_VolumePipe4Sum_Archive }
        };


        /// <summary>
        /// Таблица сопоставлений параметров для ТСРВ ВЗЛЕТ-22(23)
        /// </summary>
        private static List<DeviceParameterMapping> _deviceParameterMappingVzljot22 = new List<DeviceParameterMapping>
        {
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_022023_TimeNormal1FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_022023_TrHs1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_022023_TrHs1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_022023_TimeNormal2FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_022023_TrHs2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_022023_TrHs2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_022023_TimeNormal3FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_022023_TrHs3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_022023_TrHs3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_022023_TimeDenial1FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_022023_TdenHs1_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_022023_TdenHs1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_022023_TimeDenial2FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_022023_TdenHs2_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_022023_TdenHs2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.VZLJOT_022023_TimeDenial3FinalInstant, DiffDeviceParameter = DeviceParameter.VZLJOT_022023_TdenHs3_Archive, SumDeviceParameter = DeviceParameter.VZLJOT_022023_TdenHs3Sum_Archive }
        };

        /// <summary>
        /// Таблица сопоставлений параметров для СПТ 941.10(11)
        /// </summary>
        private static List<DeviceParameterMapping> _deviceParameterMappingSpt941 = new List<DeviceParameterMapping>
        {
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_10_11_V1, DiffDeviceParameter = DeviceParameter.Spt941_10_11_V1_Archive, SumDeviceParameter = DeviceParameter.Spt941_10_11_V1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_10_11_V2, DiffDeviceParameter = DeviceParameter.Spt941_10_11_V2_Archive, SumDeviceParameter = DeviceParameter.Spt941_10_11_V2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_10_11_V3, DiffDeviceParameter = DeviceParameter.Spt941_10_11_V3_Archive, SumDeviceParameter = DeviceParameter.Spt941_10_11_V3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_10_11_M1, DiffDeviceParameter = DeviceParameter.Spt941_10_11_M1_Archive, SumDeviceParameter = DeviceParameter.Spt941_10_11_M1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_10_11_M2, DiffDeviceParameter = DeviceParameter.Spt941_10_11_M2_Archive, SumDeviceParameter = DeviceParameter.Spt941_10_11_M2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_10_11_M3, DiffDeviceParameter = DeviceParameter.Spt941_10_11_M3_Archive, SumDeviceParameter = DeviceParameter.Spt941_10_11_M3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_10_11_Q, DiffDeviceParameter = DeviceParameter.Spt941_10_11_Q_Archive, SumDeviceParameter = DeviceParameter.Spt941_10_11_QSum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_10_11_Ti, DiffDeviceParameter = DeviceParameter.Spt941_10_11_Ti_Archive, SumDeviceParameter = DeviceParameter.Spt941_10_11_TiSum_Archive }
        };

        /// <summary>
        /// Таблица сопоставления параметров для СПТ 943
        /// </summary>
        private static List<DeviceParameterMapping> _deviceParameterMapping = new List<DeviceParameterMapping>
        {
            // ТВ1
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_V1_1, DiffDeviceParameter = DeviceParameter.Spt943_V1_1_Archive, SumDeviceParameter = DeviceParameter.Spt943_V1Sum_1_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_V2_1, DiffDeviceParameter = DeviceParameter.Spt943_V2_1_Archive, SumDeviceParameter = DeviceParameter.Spt943_V2Sum_1_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_V3_1, DiffDeviceParameter = DeviceParameter.Spt943_V3_1_Archive, SumDeviceParameter = DeviceParameter.Spt943_V3Sum_1_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_M1_1, DiffDeviceParameter = DeviceParameter.Spt943_M1_1_Archive, SumDeviceParameter = DeviceParameter.Spt943_M1Sum_1_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_M2_1, DiffDeviceParameter = DeviceParameter.Spt943_M2_1_Archive, SumDeviceParameter = DeviceParameter.Spt943_M2Sum_1_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_M3_1, DiffDeviceParameter = DeviceParameter.Spt943_M3_1_Archive, SumDeviceParameter = DeviceParameter.Spt943_M3Sum_1_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_Q_1, DiffDeviceParameter = DeviceParameter.Spt943_Q_1_Archive, SumDeviceParameter = DeviceParameter.Spt943_QSum_1_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_Ti_1, DiffDeviceParameter = DeviceParameter.Spt943_Ti_1_Archive, SumDeviceParameter = DeviceParameter.Spt943_TiSum_1_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_Qg_1, DiffDeviceParameter = DeviceParameter.Spt943_Qg_1_Archive, SumDeviceParameter = DeviceParameter.Spt943_QgSum_1_Archive },

            // ТВ2
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_V1_2, DiffDeviceParameter = DeviceParameter.Spt943_V1_2_Archive, SumDeviceParameter = DeviceParameter.Spt943_V1Sum_2_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_V2_2, DiffDeviceParameter = DeviceParameter.Spt943_V2_2_Archive, SumDeviceParameter = DeviceParameter.Spt943_V2Sum_2_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_V3_2, DiffDeviceParameter = DeviceParameter.Spt943_V3_2_Archive, SumDeviceParameter = DeviceParameter.Spt943_V3Sum_2_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_M1_2, DiffDeviceParameter = DeviceParameter.Spt943_M1_2_Archive, SumDeviceParameter = DeviceParameter.Spt943_M1Sum_2_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_M2_2, DiffDeviceParameter = DeviceParameter.Spt943_M2_2_Archive, SumDeviceParameter = DeviceParameter.Spt943_M2Sum_2_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_M3_2, DiffDeviceParameter = DeviceParameter.Spt943_M3_2_Archive, SumDeviceParameter = DeviceParameter.Spt943_M3Sum_2_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_Q_2, DiffDeviceParameter = DeviceParameter.Spt943_Q_2_Archive, SumDeviceParameter = DeviceParameter.Spt943_QSum_2_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_Ti_2, DiffDeviceParameter = DeviceParameter.Spt943_Ti_2_Archive, SumDeviceParameter = DeviceParameter.Spt943_TiSum_2_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt943_Qg_2, DiffDeviceParameter = DeviceParameter.Spt943_Qg_2_Archive, SumDeviceParameter = DeviceParameter.Spt943_QgSum_2_Archive }
        };

        /// <summary>
        /// Таблица сопоставлений параметров для СПТ 941.20
        /// </summary>
        private static List<DeviceParameterMapping> _deviceParameterMappingSpt941_20 = new List<DeviceParameterMapping>
        {
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_20_M1, DiffDeviceParameter = DeviceParameter.Spt941_20_M1_Archive, SumDeviceParameter = DeviceParameter.Spt941_20_M1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_20_M2, DiffDeviceParameter = DeviceParameter.Spt941_20_M2_Archive, SumDeviceParameter = DeviceParameter.Spt941_20_M2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_20_M3, DiffDeviceParameter = DeviceParameter.Spt941_20_M3_Archive, SumDeviceParameter = DeviceParameter.Spt941_20_M3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_20_V1, DiffDeviceParameter = DeviceParameter.Spt941_20_V1_Archive, SumDeviceParameter = DeviceParameter.Spt941_20_V1Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_20_V2, DiffDeviceParameter = DeviceParameter.Spt941_20_V2_Archive, SumDeviceParameter = DeviceParameter.Spt941_20_V2Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_20_V3, DiffDeviceParameter = DeviceParameter.Spt941_20_V3_Archive, SumDeviceParameter = DeviceParameter.Spt941_20_V3Sum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_20_Q, DiffDeviceParameter = DeviceParameter.Spt941_20_Q_Archive, SumDeviceParameter = DeviceParameter.Spt941_20_QSum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_20_Qg, DiffDeviceParameter = DeviceParameter.Spt941_20_Qg_Archive, SumDeviceParameter = DeviceParameter.Spt941_20_QgSum_Archive },
            new DeviceParameterMapping { TotalDeviceParameter = DeviceParameter.Spt941_20_Ti, DiffDeviceParameter = DeviceParameter.Spt941_20_Ti_Archive, SumDeviceParameter = DeviceParameter.Spt941_20_TiSum_Archive }
        };

        private readonly DeviceModel _deviceModel;
        public DeviceParameterMappingHelper(DeviceModel deviceModel)
        {
            _deviceModel = deviceModel;
        }

        /// <summary>
        /// Возвращает идентификатор дифференциального параметра по тотальному параметру
        /// </summary>
        /// <param name="deviceParameter"></param>
        /// <returns></returns>
        public int GetDiffDeviceParameterIdByDeviceParameterId(DeviceParameter deviceParameter)
        {
            int id = -1;

            switch (_deviceModel)
            {
                case DeviceModel.Spt943:
                    id = (int)_deviceParameterMapping.First(p => p.TotalDeviceParameter == deviceParameter).DiffDeviceParameter;
                    break;
                case DeviceModel.Spt941_10_11:
                    id = (int)_deviceParameterMappingSpt941.First(p => p.TotalDeviceParameter == deviceParameter).DiffDeviceParameter;
                    break;
                case DeviceModel.Spt941_20:
                    id = (int)_deviceParameterMappingSpt941_20.First(p => p.TotalDeviceParameter == deviceParameter).DiffDeviceParameter;
                    break;
                case DeviceModel.Vzljot22:
                    id = (int)_deviceParameterMappingVzljot22.First(p => p.TotalDeviceParameter == deviceParameter).DiffDeviceParameter;
                    break;
                case DeviceModel.Vzljot26:
                    id = (int)_deviceParameterMappingVzljot26.First(p => p.TotalDeviceParameter == deviceParameter).DiffDeviceParameter;
                    break;
                case DeviceModel.Vzljot26M:
                    id = (int)_deviceParameterMappingVzljot26M.First(p => p.TotalDeviceParameter == deviceParameter).DiffDeviceParameter;
                    break;
                case DeviceModel.Vzljot24:
                    id = (int)_deviceParameterMappingVzljot24.First(p => p.TotalDeviceParameter == deviceParameter).DiffDeviceParameter;
                    break;
                case DeviceModel.Vzljot24M:
                    id = (int)_deviceParameterMappingVzljot24M.First(p => p.TotalDeviceParameter == deviceParameter).DiffDeviceParameter;
                    break;
            }

            return id;
        }

        /// <summary>
        /// Возвращает идентификатор интеграционного параметра по тотальному параметру
        /// </summary>
        /// <param name="deviceParameter"></param>
        /// <returns></returns>
        public int GetSumDeviceParameterIdByDeviceParameterId(DeviceParameter deviceParameter)
        {
            int id = -1;
            switch (_deviceModel)
            {
                case DeviceModel.Spt943:
                    id = (int)_deviceParameterMapping.First(p => p.TotalDeviceParameter == deviceParameter).SumDeviceParameter;
                    break;
                case DeviceModel.Spt941_10_11:
                    id = (int)_deviceParameterMappingSpt941.First(p => p.TotalDeviceParameter == deviceParameter).SumDeviceParameter;
                    break;
                case DeviceModel.Spt941_20:
                    id = (int)_deviceParameterMappingSpt941_20.First(p => p.TotalDeviceParameter == deviceParameter).SumDeviceParameter;
                    break;
                case DeviceModel.Vzljot22:
                    id = (int)_deviceParameterMappingVzljot22.First(p => p.TotalDeviceParameter == deviceParameter).SumDeviceParameter;
                    break;
                case DeviceModel.Vzljot26:
                    id = (int)_deviceParameterMappingVzljot26.First(p => p.TotalDeviceParameter == deviceParameter).SumDeviceParameter;
                    break;
                case DeviceModel.Vzljot26M:
                    id = (int)_deviceParameterMappingVzljot26M.First(p => p.TotalDeviceParameter == deviceParameter).SumDeviceParameter;
                    break;
                case DeviceModel.Vzljot24:
                    id = (int)_deviceParameterMappingVzljot24.First(p => p.TotalDeviceParameter == deviceParameter).SumDeviceParameter;
                    break;
                case DeviceModel.Vzljot24M:
                    id = (int)_deviceParameterMappingVzljot24M.First(p => p.TotalDeviceParameter == deviceParameter).SumDeviceParameter;
                    break;
            }

            return id;
        }

        /// <summary>
        /// Возвращает идентификатор дифференциального параметра по идентификатору интеграционного параметра
        /// </summary>
        /// <param name="sumDeviceParameterId"></param>
        /// <returns></returns>
        public int GetDiffDeviceParameterIdBySumParameterId(int sumDeviceParameterId)
        {
            int id = -1;

            switch (_deviceModel)
            {
                case DeviceModel.Spt943:
                    id = (int)_deviceParameterMapping.First(p => p.SumDeviceParameter == (DeviceParameter)sumDeviceParameterId).DiffDeviceParameter;
                    break;
                case DeviceModel.Spt941_10_11:
                    id = (int)_deviceParameterMappingSpt941.First(p => p.SumDeviceParameter == (DeviceParameter)sumDeviceParameterId).DiffDeviceParameter;
                    break;
                case DeviceModel.Spt941_20:
                    id = (int)_deviceParameterMappingSpt941_20.First(p => p.SumDeviceParameter == (DeviceParameter)sumDeviceParameterId).DiffDeviceParameter;
                    break;
                case DeviceModel.Vzljot22:
                    id = (int)_deviceParameterMappingVzljot22.First(p => p.SumDeviceParameter == (DeviceParameter)sumDeviceParameterId).DiffDeviceParameter;
                    break;
                case DeviceModel.Vzljot26:
                    id = (int)_deviceParameterMappingVzljot26.First(p => p.SumDeviceParameter == (DeviceParameter)sumDeviceParameterId).DiffDeviceParameter;
                    break;
                case DeviceModel.Vzljot26M:
                    id = (int)_deviceParameterMappingVzljot26M.First(p => p.SumDeviceParameter == (DeviceParameter)sumDeviceParameterId).DiffDeviceParameter;
                    break;
                case DeviceModel.Vzljot24:
                    id = (int)_deviceParameterMappingVzljot24.First(p => p.SumDeviceParameter == (DeviceParameter)sumDeviceParameterId).DiffDeviceParameter;
                    break;
                case DeviceModel.Vzljot24M:
                    id = (int)_deviceParameterMappingVzljot24M.First(p => p.SumDeviceParameter == (DeviceParameter)sumDeviceParameterId).DiffDeviceParameter;
                    break;
            }

            return id;
        }

        /// <summary>
        /// Возвращает идентификатор тотального параметра по идентификатору интеграционного параметра
        /// </summary>
        /// <param name="sumDeviceParameterId"></param>
        /// <returns></returns>
        public int GetDeviceParameterIdBySumParameterId(int sumDeviceParameterId)
        {
            int id = -1;

            switch (_deviceModel)
            {
                case DeviceModel.Spt943:
                    id = (int)_deviceParameterMapping.First(p => (int)p.SumDeviceParameter == sumDeviceParameterId).TotalDeviceParameter;
                    break;
                case DeviceModel.Spt941_10_11:
                    id = (int)_deviceParameterMappingSpt941.First(p => (int)p.SumDeviceParameter == sumDeviceParameterId).TotalDeviceParameter;
                    break;
                case DeviceModel.Spt941_20:
                    id = (int)_deviceParameterMappingSpt941_20.First(p => (int)p.SumDeviceParameter == sumDeviceParameterId).TotalDeviceParameter;
                    break;
                case DeviceModel.Vzljot22:
                    id = (int)_deviceParameterMappingVzljot22.First(p => (int)p.SumDeviceParameter == sumDeviceParameterId).TotalDeviceParameter;
                    break;
                case DeviceModel.Vzljot26:
                    id = (int)_deviceParameterMappingVzljot26.First(p => (int)p.SumDeviceParameter == sumDeviceParameterId).TotalDeviceParameter;
                    break;
                case DeviceModel.Vzljot26M:
                    id = (int)_deviceParameterMappingVzljot26M.First(p => (int)p.SumDeviceParameter == sumDeviceParameterId).TotalDeviceParameter;
                    break;
                case DeviceModel.Vzljot24:
                    id = (int)_deviceParameterMappingVzljot24.First(p => (int)p.SumDeviceParameter == sumDeviceParameterId).TotalDeviceParameter;
                    break;
                case DeviceModel.Vzljot24M:
                    id = (int)_deviceParameterMappingVzljot24M.First(p => (int)p.SumDeviceParameter == sumDeviceParameterId).TotalDeviceParameter;
                    break;
            }

            return id;
        }

        /// <summary>
        /// Возвращает коллекцию идентификаторов интеграционных параметров по соответствующим тотальным параметрам
        /// </summary>
        /// <param name="deviceParameters"></param>
        /// <returns></returns>
        public List<int> GetSumDeviceParametersIdsByDeviceParameters(List<DeviceParameter> deviceParameters)
        {
            List<int> result = null;

            switch (_deviceModel)
            {
                case DeviceModel.Spt943:
                    result = _deviceParameterMapping.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.SumDeviceParameter).ToList();
                    break;
                case DeviceModel.Spt941_10_11:
                    result = _deviceParameterMappingSpt941.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.SumDeviceParameter).ToList();
                    break;
                case DeviceModel.Spt941_20:
                    result = _deviceParameterMappingSpt941_20.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.SumDeviceParameter).ToList();
                    break;
                case DeviceModel.Vzljot22:
                    result = _deviceParameterMappingVzljot22.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.SumDeviceParameter).ToList();
                    break;
                case DeviceModel.Vzljot26:
                    result = _deviceParameterMappingVzljot26.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.SumDeviceParameter).ToList();
                    break;
                case DeviceModel.Vzljot26M:
                    result = _deviceParameterMappingVzljot26M.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.SumDeviceParameter).ToList();
                    break;
                case DeviceModel.Vzljot24:
                    result = _deviceParameterMappingVzljot24.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.SumDeviceParameter).ToList();
                    break;
                case DeviceModel.Vzljot24M:
                    result = _deviceParameterMappingVzljot24M.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.SumDeviceParameter).ToList();
                    break;
            }

            return result;
        }

        /// <summary>
        /// Возвращает коллекцию идентификаторов дифференциальных параметров по соответствующим тотальным параметрам
        /// </summary>
        /// <param name="deviceParameters"></param>
        /// <returns></returns>
        public List<int> GetDiffDeviceParametersIdsByDeviceParameters(List<DeviceParameter> deviceParameters)
        {
            List<int> result = null;

            switch (_deviceModel)
            {
                case DeviceModel.Spt943:
                    result = _deviceParameterMapping.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.DiffDeviceParameter).ToList();
                    break;
                case DeviceModel.Spt941_10_11:
                    result = _deviceParameterMappingSpt941.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.DiffDeviceParameter).ToList();
                    break;
                case DeviceModel.Spt941_20:
                    result = _deviceParameterMappingSpt941_20.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.DiffDeviceParameter).ToList();
                    break;
                case DeviceModel.Vzljot22:
                    result = _deviceParameterMappingVzljot22.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.DiffDeviceParameter).ToList();
                    break;
                case DeviceModel.Vzljot26:
                    result = _deviceParameterMappingVzljot26.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.DiffDeviceParameter).ToList();
                    break;
                case DeviceModel.Vzljot26M:
                    result = _deviceParameterMappingVzljot26M.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.DiffDeviceParameter).ToList();
                    break;
                case DeviceModel.Vzljot24:
                    result = _deviceParameterMappingVzljot24.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.DiffDeviceParameter).ToList();
                    break;
                case DeviceModel.Vzljot24M:
                    result = _deviceParameterMappingVzljot24M.Where(p => deviceParameters.Contains(p.TotalDeviceParameter))
                                                                      .Select(p => (int)p.DiffDeviceParameter).ToList();
                    break;
            }

            return result;
        }
    }
}

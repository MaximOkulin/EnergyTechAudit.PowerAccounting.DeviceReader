using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Определяет измеряется хотя бы одна текущая температура
        /// </summary>
        /// <param name="instantParamsSet"></param>
        /// <returns></returns>
        public static bool HasInstantTemperatures(InstantParamsSet instantParamsSet)
        {
            return ((instantParamsSet & InstantParamsSet.Temperature1) == InstantParamsSet.Temperature1) ||
                    ((instantParamsSet & InstantParamsSet.Temperature2) == InstantParamsSet.Temperature2) ||
                    ((instantParamsSet & InstantParamsSet.Temperature3) == InstantParamsSet.Temperature3) ||
                    ((instantParamsSet & InstantParamsSet.Temperature4) == InstantParamsSet.Temperature4);
        }

        /// <summary>
        /// Определяет измеряется хотя бы один текущий объемный расход
        /// </summary>
        /// <param name="instantParamsSet"></param>
        /// <returns></returns>
        public static bool HasInstantVolumeFlows(InstantParamsSet instantParamsSet)
        {
            return ((instantParamsSet & InstantParamsSet.VolumeFlow1) == InstantParamsSet.VolumeFlow1) ||
                   ((instantParamsSet & InstantParamsSet.VolumeFlow2) == InstantParamsSet.VolumeFlow2) ||
                   ((instantParamsSet & InstantParamsSet.VolumeFlow3) == InstantParamsSet.VolumeFlow3);
        }

        /// <summary>
        /// Определяет измеряется хотя бы один текущий массовый расход
        /// </summary>
        /// <param name="instantParamsSet"></param>
        /// <returns></returns>
        public static bool HasInstantMassFlows(InstantParamsSet instantParamsSet)
        {
            return ((instantParamsSet & InstantParamsSet.MassFlow1) == InstantParamsSet.MassFlow1) ||
                    ((instantParamsSet & InstantParamsSet.MassFlow2) == InstantParamsSet.MassFlow2) ||
                    ((instantParamsSet & InstantParamsSet.MassFlow3) == InstantParamsSet.MassFlow3);
        }

        /// <summary>
        /// Определяет измеряется хотя бы одно текущее давление
        /// </summary>
        /// <param name="instantParamsSet"></param>
        /// <returns></returns>
        public static bool HasInstantPressures(InstantParamsSet instantParamsSet)
        {
            return ((instantParamsSet & InstantParamsSet.Pressure1) == InstantParamsSet.Pressure1) ||
                   ((instantParamsSet & InstantParamsSet.Pressure2) == InstantParamsSet.Pressure2) ||
                   ((instantParamsSet & InstantParamsSet.Pressure3) == InstantParamsSet.Pressure3);
        }

        /// <summary>
        /// Определяет измеряется ли текущая тепловая мощность
        /// </summary>
        /// <param name="instantParamsSet"></param>
        /// <returns></returns>
        public static bool HasInstantThermalPower(InstantParamsSet instantParamsSet)
        {
            return ((instantParamsSet & InstantParamsSet.ThermalPower) == InstantParamsSet.ThermalPower);
        }

        /// <summary>
        /// Определяет измеряется хотя бы один объем
        /// </summary>
        /// <param name="finalInstantParamsSet"></param>
        /// <returns></returns>
        public static bool HasFinalInstantVolumes(FinalInstantParamsSet finalInstantParamsSet)
        {
            return ((finalInstantParamsSet & FinalInstantParamsSet.Volume1) == FinalInstantParamsSet.Volume1) ||
                   ((finalInstantParamsSet & FinalInstantParamsSet.Volume2) == FinalInstantParamsSet.Volume2) ||
                   ((finalInstantParamsSet & FinalInstantParamsSet.Volume3) == FinalInstantParamsSet.Volume3);
        }

        /// <summary>
        /// Определяет измеряется хотя бы одна масса
        /// </summary>
        /// <param name="finalInstantParamsSet"></param>
        /// <returns></returns>
        public static bool HasFinalInstantMasses(FinalInstantParamsSet finalInstantParamsSet)
        {
            return ((finalInstantParamsSet & FinalInstantParamsSet.Mass1) == FinalInstantParamsSet.Mass1) ||
                   ((finalInstantParamsSet & FinalInstantParamsSet.Mass2) == FinalInstantParamsSet.Mass2) ||
                   ((finalInstantParamsSet & FinalInstantParamsSet.Mass3) == FinalInstantParamsSet.Mass3);
        }

        /// <summary>
        /// Определяет измеряется ли тепловая энергия
        /// </summary>
        /// <param name="finalInstantParamsSet"></param>
        /// <returns></returns>
        public static bool HasFinalInstantHeat(FinalInstantParamsSet finalInstantParamsSet)
        {
            return ((finalInstantParamsSet & FinalInstantParamsSet.Heat) == FinalInstantParamsSet.Heat);                   
        }

        /// <summary>
        /// Определяет измеряется ли время наработки
        /// </summary>
        /// <param name="finalInstantParamsSet"></param>
        /// <returns></returns>
        public static bool HasFinalInstantTimeNormal(FinalInstantParamsSet finalInstantParamsSet)
        {
            return ((finalInstantParamsSet & FinalInstantParamsSet.TimeNormal) == FinalInstantParamsSet.TimeNormal);
        }
    }
}

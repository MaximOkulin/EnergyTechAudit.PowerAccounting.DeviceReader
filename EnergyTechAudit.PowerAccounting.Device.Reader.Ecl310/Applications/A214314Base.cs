using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications
{
    /// <summary>
    /// Класс, реализующий базовую бизнес-логику приложений A214/314
    /// </summary>
    internal class A214314Base : ApplicationBase
    {
        public A214314Base() : base()
        {
            
        }

        protected override bool ReadParamsFromEcl()
        {
            var rnd = new Random();

            return ExecuteReadRegulatorParameters(new[] { "AdjustedBalanceTemperature", "HeatSystemParameters2Registers", "InfluenceRoomParams",
                "OptimizationTime", "HeatSystemLimitReverseTemperature", "HeatSystemReverseParameters3Registers", "CompensationParameters",
                "MotorProtection", "HeatSystemKoefficients", "HeatSystemDriveActivationTime", "FanParameters", "FrostProtectionTemperature",
                "Blackout", "SelectionCompensationTemperature", "SendPredeterminedTemperature", "AccidentS6FreezingTemperature", "FireSafetyThermostatParameters"
            }.OrderBy(x => rnd.Next()).ToArray());
        }
    }
}

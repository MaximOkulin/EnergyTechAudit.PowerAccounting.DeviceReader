using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types;
using System.Collections.Generic;
using ComResources = EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Common;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Helpers
{
    public static class ArchiveParametersHelper
    {
        public static List<ArchiveParameterDescription> ParameterDescriptions = new List<ArchiveParameterDescription>
        {
            new ArchiveParameterDescription
            {
                Name = ComResources.TimeNormal,
                ParseType = ComResources.Byte,
                Precision = 2,
                IsExternalPrecision = false,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Worktime,
                IsIncrease = true,
                Order = 0,
                Size = 1
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Volume1,
                ParseType = ComResources.ToInt32,
                IsExternalPrecision = true,
                PrecisionName = ComResources.Channel1,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Vol1,
                IsIncrease = true,
                Order = 1,
                Size = 4
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Volume2,
                ParseType = ComResources.ToInt32,
                IsExternalPrecision = true,
                PrecisionName = ComResources.Channel2,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Vol2,
                IsIncrease = true,
                Order = 2,
                Size = 4
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Volume3,
                ParseType = ComResources.ToInt32,
                IsExternalPrecision = true,
                PrecisionName = ComResources.Channel3,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Vol3,
                IsIncrease = true,
                Order = 3,
                Size = 4
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Mass1,
                ParseType = ComResources.ToInt32,
                IsExternalPrecision = true,
                PrecisionName = ComResources.Channel1,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Mass1,
                IsIncrease = true,
                Order = 4,
                Size = 4
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Mass2,
                ParseType = ComResources.ToInt32,
                IsExternalPrecision = true,
                PrecisionName = ComResources.Channel2,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Mass2,
                IsIncrease = true,
                Order = 5,
                Size = 4
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Mass3,
                ParseType = ComResources.ToInt32,
                IsExternalPrecision = true,
                PrecisionName = ComResources.Channel3,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Mass3,
                IsIncrease = true,
                Order = 6,
                Size = 4
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Temperature1,
                ParseType = ComResources.ToInt16,
                IsExternalPrecision = false,
                Precision = 1,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Temp1,
                IsIncrease = false,
                Order = 7,
                Size = 2
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Temperature2,
                ParseType = ComResources.ToInt16,
                IsExternalPrecision = false,
                Precision = 1,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Temp2,
                IsIncrease = false,
                Order = 8,
                Size = 2
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Temperature3,
                ParseType = ComResources.ToInt16,
                IsExternalPrecision = false,
                Precision = 1,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Temp3,
                IsIncrease = false,
                Order = 9,
                Size = 2
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Temperature4,
                ParseType = ComResources.ToInt16,
                IsExternalPrecision = false,
                Precision = 1,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.TempOutdoor,
                IsIncrease = false,
                Order = 10,
                Size = 2
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Pressure1,
                ParseType = ComResources.Byte,
                IsExternalPrecision = false,
                Precision = 1,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Press1,
                IsIncrease = false,
                Order = 11,
                Size = 1
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Pressure2,
                ParseType = ComResources.Byte,
                IsExternalPrecision = false,
                Precision = 1,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Press2,
                IsIncrease = false,
                Order = 12,
                Size = 1
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Pressure3,
                ParseType = ComResources.Byte,
                IsExternalPrecision = false,
                Precision = 1,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Press3,
                IsIncrease = false,
                Order = 13,
                Size = 1
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.HeatPhysicalParameter,
                ParseType = ComResources.ToInt32,
                IsExternalPrecision = true,
                PrecisionName = ComResources.HeatPhysicalParameter,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Heat,
                IsIncrease = true,
                Order = 14,
                Size = 4
            },
            new ArchiveParameterDescription
            {
                Name = ComResources.Errors,
                ParseType = ComResources.ToInt32,
                IsExternalPrecision = false,
                Precision = 0,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.Errors,
                IsIncrease = false,
                Order = 15,
                Size = 4
            },
            new ArchiveParameterDescription
            {
                Name = VistResources.TimeFlowUnderrun,
                ParseType = ComResources.Byte,
                IsExternalPrecision = false,
                Precision = 2,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.TimeFlowUnderrun,
                IsIncrease = false,
                Order = 16,
                Size = 1
            },
            new ArchiveParameterDescription
            {
                Name = VistResources.TimeFlowOverrun,
                ParseType = ComResources.Byte,
                IsExternalPrecision = false,
                Precision = 2,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.TimeFlowOverrun,
                IsIncrease = false,
                Order = 17,
                Size = 1
            },
            new ArchiveParameterDescription
            {
                Name = VistResources.TimeDeltaTLow,
                ParseType = ComResources.Byte,
                IsExternalPrecision = false,
                Precision = 2,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.TimeDeltaTLow,
                IsIncrease = false,
                Order = 18,
                Size = 1
            },
            new ArchiveParameterDescription
            {
                Name = VistResources.TimeNoPower,
                ParseType = ComResources.Byte,
                IsExternalPrecision = false,
                Precision = 2,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.TimeNoPower,
                IsIncrease = false,
                Order = 19,
                Size = 1
            },
            new ArchiveParameterDescription
            {
                Name = VistResources.TotalTime,
                ParseType = ComResources.Byte,
                IsExternalPrecision = false,
                Precision = 2,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.TotalTime,
                IsIncrease = false,
                Order = 21,
                Size = 1
            },
            new ArchiveParameterDescription
            {
                Name = VistResources.IdleTime,
                ParseType = ComResources.Byte,
                IsExternalPrecision = false,
                Precision = 2,
                ArchiveHeatSystemParams = ArchiveHeatSystemParams.IdleTime,
                IsIncrease = false,
                Order = 22,
                Size = 1
            }
        };
    }
}

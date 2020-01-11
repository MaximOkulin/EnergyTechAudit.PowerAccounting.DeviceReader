using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Integrating
{
    internal sealed class IntegratingParameters
    {
        public decimal? V1Sum { get; set; }
        public decimal? V2Sum { get; set; }
        public decimal? V3Sum { get; set; }
        public decimal? V4Sum { get; set; }
        public decimal? V5Sum { get; set; }
        public decimal? V6Sum { get; set; }
        public decimal? M1Sum { get; set; }
        public decimal? M2Sum { get; set; }
        public decimal? M3Sum { get; set; }
        public decimal? M4Sum { get; set; }
        public decimal? M5Sum { get; set; }
        public decimal? M6Sum { get; set; }
        public decimal? dM1Sum { get; set; }
        public decimal? dM2Sum { get; set; }
        public decimal? Qtv1Sum { get; set; }
        public decimal? Qtv2Sum { get; set; }
        public decimal? Q121Sum { get; set; }
        public decimal? Q122Sum { get; set; }
        public decimal? Qg1Sum { get; set; }
        public decimal? Qg2Sum { get; set; }
        public decimal? Tnorm1Sum { get; set; }
        public decimal? Tnorm2Sum { get; set; }
        public decimal? Tden1Sum { get; set; }
        public decimal? Tden2Sum { get; set; }

        public Dictionary<string, int> ParametersId
        {
            get
            {
                return new Dictionary<string, int>
                {
                    {"V1Sum", 4049},
                    {"V2Sum", 4050},
                    {"V3Sum", 4051},
                    {"V4Sum", 4052},
                    {"V5Sum", 4053},
                    {"V6Sum", 4054},
                    {"M1Sum", 4055},
                    {"M2Sum", 4056},
                    {"M3Sum", 4057},
                    {"M4Sum", 4058},
                    {"M5Sum", 4059},
                    {"M6Sum", 4060},
                    {"dM1Sum", 4061},
                    {"dM2Sum", 4062},
                    {"Qtv1Sum", 4063},
                    {"Qtv2Sum", 4064},
                    {"Q121Sum", 4065},
                    {"Q122Sum", 4066},
                    {"Qg1Sum", 4067},
                    {"Qg2Sum", 4068},
                    {"Tnorm1Sum", 4069},
                    {"Tnorm2Sum", 4070},
                    {"Tden1Sum", 4071},
                    {"Tden2Sum", 4072}
                };
            }
        }
    }
}

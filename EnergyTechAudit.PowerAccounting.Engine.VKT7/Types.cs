using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7
{
    /// <summary>
    /// Режим получения данных для функции GetData
    /// </summary>
    internal enum GetDataMode
    {
        ServerType, // тип сервера
        Properties // свойства (единицы измерения и кол-во точек после запятой)
    }

    /// <summary>
    /// Тип данных, возвращаемый в ответ на команду GetData
    /// </summary>
    internal enum DataType
    {
        ServerType,
        Archive
    }

    internal enum ValueTypes
    {
        Hourly = 0,
        Daily = 1,
        Monthly = 2,
        Final = 3,
        Instant = 4,
        FinalInstant = 5,
        Properties = 6
    }

    /// <summary>
    /// Текущие значения накопительных параметров ТВ1
    /// </summary>
    internal sealed class IntegratingParameters
    {
        public decimal? V1_1TypeSum { get; set; }
        public decimal? V2_1TypeSum { get; set; }
        public decimal? V3_1TypeSum { get; set; }
        public decimal? M1_1TypeSum { get; set; }
        public decimal? M2_1TypeSum { get; set; }
        public decimal? M3_1TypeSum { get; set; }
        public decimal? Mg_1TypePSum { get; set; }
        public decimal? Qo_1TypePSum { get; set; }
        public decimal? Qg_1TypePSum { get; set; }
        public decimal? QntType_1HIPSum { get; set; }
        public decimal? QntType_1PSum { get; set; }
        public decimal? V1_2TypeSum { get; set; }
        public decimal? V2_2TypeSum { get; set; }
        public decimal? V3_2TypeSum { get; set; }
        public decimal? M1_2TypeSum { get; set; }
        public decimal? M2_2TypeSum { get; set; }
        public decimal? M3_2TypeSum { get; set; }
        public decimal? Mg_2TypePSum { get; set; }
        public decimal? Qo_2TypePSum { get; set; }
        public decimal? Qg_2TypePSum { get; set; }
        public decimal? QntType_2HIPSum { get; set; }
        public decimal? QntType_2PSum { get; set; }


        public Dictionary<string, int> ParametersId
        {
            get
            {
                return new Dictionary<string, int>
                {
                    {"V1_1TypeSum", 122},
                    {"V2_1TypeSum", 123},
                    {"V3_1TypeSum", 124},
                    {"M1_1TypeSum", 125},
                    {"M2_1TypeSum", 126},
                    {"M3_1TypeSum", 127},
                    {"Mg_1TypePSum", 128},
                    {"Qo_1TypePSum", 129},
                    {"Qg_1TypePSum", 130},
                    {"QntType_1HIPSum", 131},
                    {"QntType_1PSum", 132},
                    {"V1_2TypeSum", 133},
                    {"V2_2TypeSum", 134},
                    {"V3_2TypeSum", 135},
                    {"M1_2TypeSum", 136},
                    {"M2_2TypeSum", 137},
                    {"M3_2TypeSum", 138},
                    {"Mg_2TypePSum", 139},
                    {"Qo_2TypePSum", 140},
                    {"Qg_2TypePSum", 141},
                    {"QntType_2HIPSum", 142},
                    {"QntType_2PSum", 143}
                };
            }
        }

        // массив идентификаторов дифференциальных параметров
        public static int[] DiffParamsIds = new int[]
            { 80, 81, 82, 83, 84, 85, 88, 89, 90, 94, 95, 102, 103, 104, 105, 106, 107, 110, 111, 112, 116, 117 };

        public static List<InterParam> IntegParams
        {
            get
            {
                return new List<InterParam>
                {
                    new InterParam(80, 122, "V1_1TypeSum"),
                    new InterParam(81, 123, "V2_1TypeSum"),
                    new InterParam(82, 124, "V3_1TypeSum"),
                    new InterParam(83, 125, "M1_1TypeSum"),
                    new InterParam(84, 126, "M2_1TypeSum"),
                    new InterParam(85, 127, "M3_1TypeSum"),
                    new InterParam(88, 128, "Mg_1TypePSum"),
                    new InterParam(89, 129, "Qo_1TypePSum"),
                    new InterParam(90, 130, "Qg_1TypePSum"),
                    new InterParam(94, 131, "QntType_1HIPSum"),
                    new InterParam(95, 132, "QntType_1PSum"),
                    new InterParam(102, 133, "V1_2TypeSum"),
                    new InterParam(103, 134, "V2_2TypeSum"),
                    new InterParam(104, 135, "V3_2TypeSum"),
                    new InterParam(105, 136, "M1_2TypeSum"),
                    new InterParam(106, 137, "M2_2TypeSum"),
                    new InterParam(107, 138, "M3_2TypeSum"),
                    new InterParam(110, 139, "Mg_2TypePSum"),
                    new InterParam(111, 140, "Qo_2TypePSum"),
                    new InterParam(112, 141, "Qg_2TypePSum"),
                    new InterParam(116, 142, "QntType_2HIPSum"),
                    new InterParam(117, 143, "QntType_2PSum")
                };
            }
        }
    }

    /// <summary>
    /// Информация о схеме измерения
    /// </summary>
    public class SchemeInfo
    {
        /// <summary>
        /// СИ
        /// </summary>
        public int SchemeNumber;
        /// <summary>
        /// Назначение трубопровода 3
        /// </summary>
        public int T3;
        /// <summary>
        /// Назначение t5
        /// </summary>
        public int t5;
    }

    public class InterParam
    {
        public int SumParamId { get; set; }
        public int DiffParamId { get; set; }
        public string Name { get; set; }

        public InterParam(int diffParamId, int sumParamId, string name)
        {
            SumParamId = sumParamId;
            DiffParamId = diffParamId;
            Name = name;
        }
    }
}

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types
{
    /// <summary>
    /// Прямая, соединяющая две точки температурного графика
    /// </summary>
    public class HeatCurveLine
    {
        private readonly decimal _x1;
        private readonly decimal _y1;
        private readonly decimal _k;
        
        /// <summary>
        /// Создает объект прямой
        /// </summary>
        /// <param name="x1">Нижняя граница температуры наружного воздуха</param>
        /// <param name="y1">Значение температуры в трубопроводе в нижней границе</param>
        /// <param name="x2">Верхняя граница температуры наружного воздуха</param>
        /// <param name="y2">Значение температуры в трубопроводе в верхней границе</param>
        public HeatCurveLine(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            _x1 = x1;
            _y1 = y1;

            _k = (y2 - y1) / (x2 - x1);
        }

        /// <summary>
        /// Рассчитывает значение температуры в трубопроводе
        /// </summary>
        /// <param name="x">Текущая температура наружного воздуха</param>
        public decimal Calculate(decimal x)
        {
            decimal absDelta = System.Math.Abs(_x1 - x);
            return _k * absDelta + _y1;
        }
    }
}

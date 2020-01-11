using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces
{
    /// <summary>
    /// Интерфейс реализуемый всеми классами сущностных моделей
    /// </summary>
    public interface IEntity : IEntity<int>
    {

    }
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}

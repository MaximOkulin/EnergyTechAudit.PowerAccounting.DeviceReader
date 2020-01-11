using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces
{
    public interface IDatabaseContext
    {
        IQueryable<TEntity> Set<TEntity>() where TEntity : class, IEntity;       
    }
}

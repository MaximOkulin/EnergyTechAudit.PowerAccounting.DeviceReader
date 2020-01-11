using System;
using System.Linq;
using System.Reflection;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public class AssemblyHelper
    {
        /// <summary>
        /// Ищет тип среди всех загруженных в домен сборок
        /// </summary>
        /// <param name="typeName">Имя типа</param>
        /// <param name="filter">Фильтр имен сборок</param>
        public static Type SearchType(string typeName, string filter = "")
        {
            Type resultType = null;
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(p => p.FullName.Contains(filter)).ToList();
            foreach (Assembly a in assemblies)
            {
                foreach (Type type in a.GetTypes())
                {
                    if (type.Name.Equals(typeName))
                    {
                        resultType = type;
                    }
                }
            }
            return resultType;
        }
    }
}

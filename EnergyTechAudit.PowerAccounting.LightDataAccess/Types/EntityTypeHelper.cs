using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Types
{
    public class EntityTypeHelper
    {
        private const string DomainAssemblyName = "EnergyTechAudit.PowerAccounting.LightDataAccess";
        private const string DomainEntityNamespaceRoot = "EnergyTechAudit.PowerAccounting.LightDataAccess";

        public static string GetKeyPropertyName(Type entityType)
        {
            var keyAttr = entityType
                .GetProperties()
                .FirstOrDefault(pi => pi.GetCustomAttribute<KeyAttribute>() != null);

            return keyAttr != null ? keyAttr.Name : null;
        }

        public static Type[] GeCustomTypesFromAppDomain
        (
            Func<Assembly, bool> assemblySearchPredicate,
            Func<Type, bool> typesSearchPredicate
        )
        {
            return
                AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .Where(assemblySearchPredicate)

                    .SelectMany(a => a.GetTypes())

                    .Where(typesSearchPredicate)
                    .ToArray();
        }

        public static Type[] GetEntityTypes()
        {
            var domainEntityAssembly =
                 AppDomain
                 .CurrentDomain
                 .GetAssemblies()
                 .FirstOrDefault(assembly => assembly.GetName().Name == DomainAssemblyName);

            return domainEntityAssembly != null
                ? domainEntityAssembly.GetTypes()
                .Where(type => type.IsClass
                        && type.Namespace != null
                        && type.Namespace.StartsWith(DomainEntityNamespaceRoot))
                .ToArray()
                : null;
        }

        public static Type GetEntityTypeByName(string entityTypeName)
        {
            return GetEntityTypes().FirstOrDefault(type => type.Name.Equals(entityTypeName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

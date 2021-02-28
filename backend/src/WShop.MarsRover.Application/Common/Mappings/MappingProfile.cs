using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Ledd.Dms.Application.Common.Mappings
{
    /// <summary>
    /// Instead of wireup mapping profile for each dto manually,
    /// we can automate it. i.e scan all the dtos which implemented IMapFrom
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            // Scan the assemply find all dtos implementing IMapFrom and invoke mapping interface method
            // and then add that map to the profile (we did it in profile.CrateMap() inside interface 
            // as well as inside dto and automapper knows about it. And finally we use that mapping 
            // inside e.g. GetTodosQuery.
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                    ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });

            }
        }
    }
}
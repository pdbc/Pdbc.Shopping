using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace Pdbc.Shopping.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterModules(this IServiceCollection serviceCollection, string[] assemblyNames, IConfiguration configuration)
        {
            foreach (var assemblyName in assemblyNames)
            {
                var allModules = GetAssignableTypeForAssembly<IModule>(assemblyName);
                foreach (var moduleType in allModules)
                {
                    var module = (IModule)Activator.CreateInstance(moduleType);
                    module.Register(serviceCollection, configuration);
                }
            }
        }

        public static void RegisterModule<T>(this IServiceCollection serviceCollection, IConfiguration configuration) where T : IModule, new()
        {
            var module = new T();

            module.Register(serviceCollection, configuration);
        }

        private static IEnumerable<Type> GetAssignableTypeForAssembly<T>(string assemblyName)
        {
            return GetReferencingAssemblies(assemblyName)
                .SelectMany(assembly => assembly.ExportedTypes)
                .Where(p => typeof(T).IsAssignableFrom(p) && !p.GetTypeInfo().IsInterface && !p.GetTypeInfo().IsAbstract);
        }

        private static IEnumerable<Assembly> GetReferencingAssemblies(string assemblyName)
        {
            assemblyName = assemblyName.ToLower();

            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (IsCandidateLibrary(library, assemblyName))
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }
            return assemblies;
        }

        private static bool IsCandidateLibrary(Library library, string assemblyName)
        {
            return library.Name.ToLower() == assemblyName;
        }

    }
}

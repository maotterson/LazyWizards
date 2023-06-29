using System.Reflection;
using System.Runtime.CompilerServices;

namespace LazyWizards.BlazorServer.Utils.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        var a = Assembly.GetCallingAssembly();
        var injectables = GetInjectableTypes(a);
        injectables
            .ToList()
            .ForEach((injectable) => {
                switch(injectable.attr.RegistrationType){
                    case DependencyRegistrationTypes.Singleton:
                        var type = injectable.type.GetType();
                        services.AddSingleton<typeof(type)>();
                        break;
                    case DependencyRegistrationTypes.Transient:
                    
                        break;
                    case DependencyRegistrationTypes.Scoped:
                    
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
    }

    private static IEnumerable<(Type type, Injectable attr)> GetInjectableTypes(Assembly assembly)
    {
        var injectables = assembly.GetTypes()
            .AsEnumerable()
            .Where(type => type.GetCustomAttribute<Injectable>() is not null)
            .Select(type => (type, type.GetCustomAttribute<Injectable>()!));
    
        return injectables;
    }

}

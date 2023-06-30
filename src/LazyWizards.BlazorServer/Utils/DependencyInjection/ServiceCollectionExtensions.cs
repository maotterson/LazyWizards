using System.Reflection;
using System.Runtime.CompilerServices;

namespace LazyWizards.BlazorServer.Utils.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        var a = Assembly.GetCallingAssembly();
        var injectables = GetInjectableTypes(a);
        injectables.ToList()
                .ForEach((injectable) => {
            var implementation = injectable.type;
            var contract = injectable.attr.ContractType;
            switch(injectable.attr.RegistrationType)
            {
                case DependencyRegistrationTypes.Singleton:
                    if(contract is null)
                    {
                        services.AddSingleton(implementation);
                    }
                    else
                    {
                        services.AddSingleton(contract, implementation);
                    }
                    break;
                case DependencyRegistrationTypes.Transient:
                    if(contract is null)
                    {
                        services.AddTransient(implementation);
                    }
                    else
                    {
                        services.AddTransient(contract, implementation);
                    }
                    break;
                case DependencyRegistrationTypes.Scoped:
                    if(contract is null)
                    {
                        services.AddScoped(implementation);
                    }
                    else
                    {
                        services.AddScoped(contract, implementation);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        });
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

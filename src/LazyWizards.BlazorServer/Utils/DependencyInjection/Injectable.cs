namespace LazyWizards.BlazorServer.Utils.DependencyInjection;

[AttributeUsage(AttributeTargets.Class)]
public class Injectable : Attribute
{
    public DependencyRegistrationTypes RegistrationType {get; set;}
    public Type? ContractType {get; set;}
    public Injectable(DependencyRegistrationTypes registrationType, Type? contractType = null)
    {
        RegistrationType = registrationType;
        ContractType = contractType;
    }
}
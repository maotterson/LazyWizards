namespace LazyWizards.BlazorServer;

[AttributeUsage(AttributeTargets.Class)]
public class Injectable : Attribute
{
    public DependencyRegistrationTypes RegistrationType {get; set;}
    public Injectable(DependencyRegistrationTypes registrationType)
    {
        RegistrationType = registrationType;
    }
}
namespace LazyWizards.BlazorServer;

[Injectable(DependencyRegistrationTypes.Singleton)]
public class LoginService : ILoginService
{
    public Task LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
}

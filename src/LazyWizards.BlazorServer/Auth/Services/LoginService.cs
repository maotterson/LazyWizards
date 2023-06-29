using LazyWizards.BlazorServer.Utils.DependencyInjection;

namespace LazyWizards.BlazorServer.Auth.Services;

[Injectable(DependencyRegistrationTypes.Singleton, typeof(ILoginService))]
public class LoginService : ILoginService
{
    public Task LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
}

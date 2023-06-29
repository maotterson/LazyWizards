namespace LazyWizards.BlazorServer.Auth.Services;

public interface ILoginService
{
    Task LoginAsync(string username, string password);
}

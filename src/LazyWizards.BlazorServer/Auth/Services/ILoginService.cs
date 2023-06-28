namespace LazyWizards.BlazorServer;

public interface ILoginService
{
    Task LoginAsync(string username, string password);
}

namespace LazyWizards.BlazorServer;

public interface ISignalRConnectionService
{
    void HandleUserConnected(string user);
    void HandleUserDisconnected(string user);
    Task StartHubAsync();
}

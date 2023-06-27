namespace LazyWizards.BlazorServer;

public class StatusHub : Hub
{
    public async Task UserConnected(string user)
    {
        // todo dispatch event based on a user connecting
    }
}
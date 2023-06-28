using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace LazyWizards.BlazorServer;

public class SignalRConnectionService
{
    private readonly HubConnection _hubConnection;
    private readonly IList<string> _activeConnections = new List<string>();
    public SignalRConnectionService(NavigationManager navigationManager)
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(navigationManager.ToAbsoluteUri("/statushub"))
            .Build();

        _hubConnection.On<string>("UserConnected", HandleUserConnected);
        _hubConnection.On<string>("UserDisconnected", HandleUserDisconnected);
    }

    public void HandleUserConnected(string user){
            _activeConnections.Add(user);
    }

    public void HandleUserDisconnected(string user){
            _activeConnections.Remove(user);
    }

    public async Task StartHubAsync(){
        await _hubConnection.StartAsync();
    }
    
}

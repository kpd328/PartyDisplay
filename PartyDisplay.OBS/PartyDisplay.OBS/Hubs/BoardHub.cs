using Microsoft.AspNetCore.SignalR;

namespace PartyDisplay.OBS.Hubs;

public class BoardHub : Hub {
    public async Task SetName(string name) {
        await Clients.All.SendAsync("SetName", name);
    }

    public async Task UpdateTurn(short turn) {
        await Clients.Others.SendAsync("ReceiveTurn", turn);
    }

    public async Task UpdateTurnLimit(short limit) {
        await Clients.Others.SendAsync("ReceiveTurnLimit", limit);
    }
}
using Microsoft.AspNetCore.SignalR;
using PartyDisplay.OBS.Lib.Xfer;

namespace PartyDisplay.OBS.Hubs;

public class BoardHub : Hub {
    public async Task SetGame(string game) {
        await Clients.Others.SendAsync("GetGame", game);
    }
    
    public async Task SetName(string name) {
        await Clients.Others.SendAsync("GetName", name);
    }

    public async Task SetTurnCurrent(short turn) {
        await Clients.Others.SendAsync("GetTurnCurrent", turn);
    }

    public async Task SetTurnLimit(short limit) {
        await Clients.Others.SendAsync("GetTurnLimit", limit);
    }
}
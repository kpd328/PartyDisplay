using Microsoft.AspNetCore.SignalR;
using PartyDisplay.OBS.Lib.Xfer;

namespace PartyDisplay.OBS.Hubs;

public class BoardHub : Hub {
    public async Task SetGame(string game) {
        await Clients.Others.SendAsync("SetGame", game);
    }
    
    public async Task SetName(string name) {
        await Clients.Others.SendAsync("SetName", name);
    }

    public async Task SetTurnCurrent(short turn) {
        await Clients.Others.SendAsync("SetTurnCurrent", turn);
    }

    public async Task SetTurnLimit(short limit) {
        await Clients.Others.SendAsync("SetTurnLimit", limit);
    }
}
using Microsoft.AspNetCore.SignalR;
using PartyDisplay.Lib.Data;

namespace PartyDisplay.OBS.Hubs;

public class BoardHub : Hub {
    public async Task SetGame(Game game) {
        await Clients.Others.SendAsync("GetGame", game);
    }
    
    public async Task SetBoard(Board board) {
        await Clients.Others.SendAsync("GetBoard", board);
    }

    public async Task SetTurnCurrent(short turn) {
        await Clients.Others.SendAsync("GetTurnCurrent", turn);
    }

    public async Task SetTurnLimit(short limit) {
        await Clients.Others.SendAsync("GetTurnLimit", limit);
    }

    public async Task SetBoardImageClass(BoardImageClass img) {
        await Clients.Others.SendAsync("GetBoardImageClass", img);
    }
}
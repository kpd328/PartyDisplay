using Microsoft.AspNetCore.SignalR;
using PartyDisplay.OBS.Lib.Data;

namespace PartyDisplay.OBS.Hubs;
public class PlayerHub : Hub {
    public async Task SetName(byte player, string name) {
        await Clients.Others.SendAsync("SetName", player, name);
    }

    public async Task UpdateStarCount(byte player, short count) {
        await Clients.Others.SendAsync("ReceiveStarCount", player, count);
    }

    public async Task UpdateCoinCount(byte player, short count) {
        await Clients.Others.SendAsync("ReceiveCoinCount", player, count);
    }
    
    public async Task UpdateRank(byte player, Ranking ranking) {
        await Clients.Others.SendAsync("ReceiveRank", player, ranking);
    }

    public async Task UpdateSpace(byte player, SpaceColor? color = null) {
        await Clients.Others.SendAsync("ReceiveSpace", player, color);
    }

    public async Task UpdateCharacter(byte player, ICharacter character) {
        await Clients.Others.SendAsync("ReceiveCharacter", player, character);
    }

    public async Task UpdateStatus(byte player, IStatus? status = null) {
        await Clients.Others.SendAsync("ReceiveStatus", player, status);
    }

    public async Task InitItems(byte size) {
        await Clients.Others.SendAsync("InitItems", size);
    }

    public async Task UpdateItems(byte player, IItem? item1, IItem? item2 = null, IItem? item3 = null) {
        await Clients.Others.SendAsync("ReceiveItems", player, item1, item2, item3);
    }

    public async Task SetupBonusStars(params BonusStar[] stars) {
        await Clients.Others.SendAsync("SetupBonusStars", stars);
    }

    public async Task UpdateBonusStar(byte player, BonusStar star) {
        await Clients.Others.SendAsync("UpdateBonusStar", player, star);
    }
}

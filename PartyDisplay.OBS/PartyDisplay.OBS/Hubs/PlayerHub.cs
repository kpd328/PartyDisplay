using Microsoft.AspNetCore.SignalR;
using PartyDisplay.OBS.Lib.Data;

namespace PartyDisplay.OBS.Hubs;
public class PlayerHub : Hub {
    public async Task SetName(string name) {
        await Clients.All.SendAsync("SetName", name);
    }

    public async Task UpdateStarCount(short count) {
        await Clients.Others.SendAsync("ReceiveStarCount", count);
    }

    public async Task UpdateCoinCount(short count) {
        await Clients.Others.SendAsync("ReceiveCoinCount", count);
    }
    
    public async Task UpdateRank(Ranking ranking) {
        await Clients.Others.SendAsync("ReceiveRank", ranking);
    }

    public async Task UpdateSpace(SpaceColor? color = null) {
        await Clients.Others.SendAsync("ReceiveSpace", color);
    }

    public async Task UpdateCharacter(ICharacter character) {
        await Clients.Others.SendAsync("ReceiveCharacter", character);
    }

    public async Task UpdateStatus(IStatus? status = null) {
        await Clients.Others.SendAsync("ReceiveStatus", status);
    }

    public async Task InitItems(byte size) {
        await Clients.All.SendAsync("InitItems", size);
    }

    public async Task UpdateItems(IItem? item1, IItem? item2 = null, IItem? item3 = null) {
        await Clients.Others.SendAsync("ReceiveItem1", item1);
        await Clients.Others.SendAsync("ReceiveItem2", item2);
        await Clients.Others.SendAsync("ReceiveItem3", item3);
    }

    public async Task SetupBonusStars(params BonusStar[] stars) {
        await Clients.Others.SendAsync("SetupBonusStars", stars);
    }

    public async Task UpdateBonusStar(BonusStar star) {
        await Clients.Others.SendAsync("UpdateBonusStar", star);
    }
}

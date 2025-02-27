using Microsoft.AspNetCore.SignalR;
using PartyDisplay.OBS.Lib.Data;

namespace PartyDisplay.OBS.Hubs;
public class PlayerHub : Hub {
    public async Task SetName(byte player, string name) {
        await Clients.Others.SendAsync("GetName", player, name);
    }

    public async Task UpdateStarCount(byte player, short count) {
        await Clients.Others.SendAsync("GetStarCount", player, count);
    }

    public async Task UpdateCoinCount(byte player, short count) {
        await Clients.Others.SendAsync("GetCoinCount", player, count);
    }
    
    public async Task UpdateRank(byte player, Ranking ranking) {
        await Clients.Others.SendAsync("GetRank", player, ranking);
    }

    public async Task UpdateSpace(byte player, SpaceColor? color = null) {
        await Clients.Others.SendAsync("GetSpace", player, color);
    }

    public async Task UpdateCharacter(byte player, ICharacter character) {
        await Clients.Others.SendAsync("GetCharacter", player, character);
    }

    public async Task UpdateStatus(byte player, IStatus? status = null) {
        await Clients.Others.SendAsync("GetStatus", player, status);
    }

    public async Task InitItems(byte size) {
        await Clients.Others.SendAsync("GetItemsInit", size);
    }

    public async Task UpdateItems(byte player, IItem? item1, IItem? item2 = null, IItem? item3 = null) {
        await Clients.Others.SendAsync("GetItems", player, item1, item2, item3);
    }

    public async Task SetupBonusStars(params BonusStar[] stars) {
        await Clients.Others.SendAsync("GetBonusStarsInit", stars);
    }

    public async Task UpdateBonusStar(byte player, BonusStar star) {
        await Clients.Others.SendAsync("GetBonusStar", player, star);
    }
}

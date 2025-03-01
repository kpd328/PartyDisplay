using Microsoft.AspNetCore.SignalR;
using PartyDisplay.Lib.Data;

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

    public async Task UpdateCharacter(byte player, Character character) {
        await Clients.Others.SendAsync("GetCharacter", player, character);
    }

    public async Task UpdateStatus(byte player, Status? status = null) {
        await Clients.Others.SendAsync("GetStatus", player, status);
    }

    public async Task InitItems(byte size) {
        await Clients.Others.SendAsync("GetItemsInit", size);
    }

    public async Task UpdateItem(byte player, byte slot, Item item) {
        await Clients.Others.SendAsync("GetItem", player, slot, item);
    }

    public async Task InitBonusStars(params BonusStar[] stars) {
        await Clients.Others.SendAsync("GetBonusStarsInit", stars);
    }

    public async Task UpdateBonusStar(byte player, BonusStar star) {
        await Clients.Others.SendAsync("GetBonusStar", player, star);
    }
}

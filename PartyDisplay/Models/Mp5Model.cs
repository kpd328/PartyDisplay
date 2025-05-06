using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using PartyDisplay.Dolphin.Reader;
using PartyDisplay.Lib.Data.Items;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Models;

public class Mp5Model : DolphinModel<Mp5Reader, Mp5Capsule> {
    public Mp5Model() {
        Reader = Mp5Reader.Connection;
    }
    
    public override async Task UpdateLoop() {
        await base.UpdateLoop();

        if (PlayerConnection is not null) {
            await PlayerConnection.SendAsync("UpdateItem", 1, Reader.GetItem(0, 0));
            await PlayerConnection.SendAsync("UpdateItem", 1, Reader.GetItem(0, 1));
            await PlayerConnection.SendAsync("UpdateItem", 1, Reader.GetItem(0, 2));
            await PlayerConnection.SendAsync("UpdateItem", 2, Reader.GetItem(1, 0));
            await PlayerConnection.SendAsync("UpdateItem", 2, Reader.GetItem(1, 1));
            await PlayerConnection.SendAsync("UpdateItem", 2, Reader.GetItem(1, 2));
            await PlayerConnection.SendAsync("UpdateItem", 3, Reader.GetItem(2, 0));
            await PlayerConnection.SendAsync("UpdateItem", 3, Reader.GetItem(2, 1));
            await PlayerConnection.SendAsync("UpdateItem", 3, Reader.GetItem(2, 2));
            await PlayerConnection.SendAsync("UpdateItem", 4, Reader.GetItem(3, 0));
            await PlayerConnection.SendAsync("UpdateItem", 4, Reader.GetItem(3, 1));
            await PlayerConnection.SendAsync("UpdateItem", 4, Reader.GetItem(3, 2));

            var bs = Mp5.BonusStars.Single(a => a.Name == "Minigame Star");
            bs.Count = Reader.GetMinigameCoins(0);
            await PlayerConnection.SendAsync("UpdateBonusStar", 1, bs);
            bs.Count = Reader.GetMinigameCoins(1);
            await PlayerConnection.SendAsync("UpdateBonusStar", 2, bs);
            bs.Count = Reader.GetMinigameCoins(2);
            await PlayerConnection.SendAsync("UpdateBonusStar", 3, bs);
            bs.Count = Reader.GetMinigameCoins(3);
            await PlayerConnection.SendAsync("UpdateBonusStar", 4, bs);

            bs = Mp5.BonusStars.Single(a => a.Name == "Coin Star");
            bs.Count = Reader.GetMaxCoins(0);
            await PlayerConnection.SendAsync("UpdateBonusStar", 1, bs);
            bs.Count = Reader.GetMaxCoins(1);
            await PlayerConnection.SendAsync("UpdateBonusStar", 2, bs);
            bs.Count = Reader.GetMaxCoins(2);
            await PlayerConnection.SendAsync("UpdateBonusStar", 3, bs);
            bs.Count = Reader.GetMaxCoins(3);
            await PlayerConnection.SendAsync("UpdateBonusStar", 4, bs);

            bs = Mp5.BonusStars.Single(a => a.Name == "Happening Star");
            bs.Count = Reader.GetHappening(0);
            await PlayerConnection.SendAsync("UpdateBonusStar", 1, bs);
            bs.Count = Reader.GetHappening(1);
            await PlayerConnection.SendAsync("UpdateBonusStar", 2, bs);
            bs.Count = Reader.GetHappening(2);
            await PlayerConnection.SendAsync("UpdateBonusStar", 3, bs);
            bs.Count = Reader.GetHappening(3);
            await PlayerConnection.SendAsync("UpdateBonusStar", 4, bs);
        }
    }
}
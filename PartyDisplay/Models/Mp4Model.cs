using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using PartyDisplay.Dolphin.Reader;
using PartyDisplay.Lib.Data;
using PartyDisplay.Lib.Data.Player;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Models;

public class Mp4Model : DolphinModel<Mp4Reader, Item> {
    public Mp4Model() {
        Reader = Mp4Reader.Connection;
    }
    
    public new async Task UpdateLoop() {
        await base.UpdateLoop();
        for (byte i = 1; i <= 4; i++) {
            for (byte j = 0; j < 3; j++) {
                PlayerConnection?.SendAsync("UpdateItem", i, Reader.GetItem((byte)(i - 1), j));
            }
            
            foreach (var bonusStar in Mp4.BonusStars) {
                bonusStar.Count = bonusStar.Name switch {
                    "Minigame Star" => Reader.GetMinigameCoins(i),
                    "Coin Star" => Reader.GetMaxCoins(i),
                    "Happening Star" => Reader.GetHappening(i),
                    _ => bonusStar.Count
                };
                PlayerConnection?.SendAsync("UpdateBonusStar", i, bonusStar);
            }
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using PartyDisplay.Dolphin.Reader;
using PartyDisplay.Lib.Data;
using PartyDisplay.Lib.Data.Player;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Models;

public class Mp2Model : DolphinModel<Mp2Reader, Item> {
    public Mp2Model() {
        Reader = Mp2Reader.Connection;
    }

    public override async Task UpdateLoop() {
        await base.UpdateLoop();
        for (byte i = 1; i <= 4; i++) {
            PlayerConnection?.SendAsync("UpdateItem", i, Reader.GetItem((byte)(i - 1)));
            
            foreach (var bonusStar in Mp2.BonusStars) {
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
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using PartyDisplay.Dolphin.Reader;
using PartyDisplay.Lib.Data.Items;
using PartyDisplay.Lib.Data.Player;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Models;

public class Mp7Model : DolphinModel<Mp7Reader, Mp7Orb> {
    public Mp7Model() {
        Reader = Mp7Reader.Connection;
    }
    
    public override async Task UpdateLoop() {
        await base.UpdateLoop();
        for (byte i = 1; i <= 4; i++) {
            for (byte j = 0; j < 3; j++) {
                PlayerConnection?.SendAsync("UpdateItem", i, Reader.GetItem((byte)(i - 1), j));
            }
            
            foreach (var bonusStar in Mp7.BonusStars) {
                bonusStar.Count = bonusStar.Name switch {
                    "Minigame Star" => Reader.GetMinigameCoins(i),
                    "Orb Star" => Reader.GetOrbsUsed(i),
                    "Action Star" => Reader.GetHappening(i),
                    "Running Star" => Reader.GetSpacesMoved(i),
                    "Shopping Star" => Reader.GetOrbsBought(i),
                    "Red Star" => Reader.GetRed(i),
                    _ => bonusStar.Count
                };
                PlayerConnection?.SendAsync("UpdateBonusStar", i, bonusStar);
            }
        }
    }
}
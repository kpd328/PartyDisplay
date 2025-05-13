using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using PartyDisplay.Dolphin.Reader;
using PartyDisplay.Lib.Data;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Models;

public class Mp4Model : DolphinModel<Mp4Reader, Item> {
    public Mp4Model() {
        Reader = Mp4Reader.Connection;
        bonusStars = [
            [Mp4.BonusStars[0].Clone(), Mp4.BonusStars[1].Clone(), Mp4.BonusStars[2].Clone()],
            [Mp4.BonusStars[0].Clone(), Mp4.BonusStars[1].Clone(), Mp4.BonusStars[2].Clone()],
            [Mp4.BonusStars[0].Clone(), Mp4.BonusStars[1].Clone(), Mp4.BonusStars[2].Clone()],
            [Mp4.BonusStars[0].Clone(), Mp4.BonusStars[1].Clone(), Mp4.BonusStars[2].Clone()]
        ];
    }
    
    public override async Task UpdateLoop() {
        if (PlayerConnection is not null) {
            await PlayerConnection.SendAsync("UpdateItem", 1, 0, Reader.GetItem(0, 0));
            await PlayerConnection.SendAsync("UpdateItem", 1, 1, Reader.GetItem(0, 1));
            await PlayerConnection.SendAsync("UpdateItem", 1, 2, Reader.GetItem(0, 2));
            await PlayerConnection.SendAsync("UpdateItem", 2, 0, Reader.GetItem(1, 0));
            await PlayerConnection.SendAsync("UpdateItem", 2, 1, Reader.GetItem(1, 1));
            await PlayerConnection.SendAsync("UpdateItem", 2, 2, Reader.GetItem(1, 2));
            await PlayerConnection.SendAsync("UpdateItem", 3, 0, Reader.GetItem(2, 0));
            await PlayerConnection.SendAsync("UpdateItem", 3, 1, Reader.GetItem(2, 1));
            await PlayerConnection.SendAsync("UpdateItem", 3, 2, Reader.GetItem(2, 2));
            await PlayerConnection.SendAsync("UpdateItem", 4, 0, Reader.GetItem(3, 0));
            await PlayerConnection.SendAsync("UpdateItem", 4, 1, Reader.GetItem(3, 1));
            await PlayerConnection.SendAsync("UpdateItem", 4, 2, Reader.GetItem(3, 2));

            bonusStars[0][0].Count = Reader.GetMinigameCoins(0);
            bonusStars[1][0].Count = Reader.GetMinigameCoins(1);
            bonusStars[2][0].Count = Reader.GetMinigameCoins(2);
            bonusStars[3][0].Count = Reader.GetMinigameCoins(3);
            ComputeBonusStarLeader(ref bonusStars[0]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 1, bonusStars[0][0]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 2, bonusStars[1][0]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 3, bonusStars[2][0]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 4, bonusStars[3][0]);
            
            bonusStars[0][1].Count = Reader.GetMaxCoins(0);
            bonusStars[1][1].Count = Reader.GetMaxCoins(1);
            bonusStars[2][1].Count = Reader.GetMaxCoins(2);
            bonusStars[3][1].Count = Reader.GetMaxCoins(3);
            ComputeBonusStarLeader(ref bonusStars[1]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 1, bonusStars[0][1]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 2, bonusStars[1][1]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 3, bonusStars[2][1]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 4, bonusStars[3][1]);
            
            bonusStars[0][2].Count = Reader.GetHappening(0);
            bonusStars[1][2].Count = Reader.GetHappening(1);
            bonusStars[2][2].Count = Reader.GetHappening(2);
            bonusStars[3][2].Count = Reader.GetHappening(3);
            ComputeBonusStarLeader(ref bonusStars[2]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 1, bonusStars[0][2]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 2, bonusStars[1][2]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 3, bonusStars[2][2]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 4, bonusStars[3][2]);
        }
        
        await base.UpdateLoop();
    }
}
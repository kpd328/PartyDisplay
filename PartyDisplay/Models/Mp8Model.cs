using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using PartyDisplay.Dolphin.Reader;
using PartyDisplay.Lib.Data.Items;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Models;

public class Mp8Model : DolphinModel<Mp8Reader, Mp8Candy> {
    public Mp8Model() {
        Reader = Mp8Reader.Connection;
        bonusStars = [
            [Mp8.BonusStars[0].Clone(), Mp8.BonusStars[1].Clone(), Mp8.BonusStars[2].Clone(), Mp8.BonusStars[3].Clone(), Mp8.BonusStars[4].Clone(), Mp8.BonusStars[5].Clone()],
            [Mp8.BonusStars[0].Clone(), Mp8.BonusStars[1].Clone(), Mp8.BonusStars[2].Clone(), Mp8.BonusStars[3].Clone(), Mp8.BonusStars[4].Clone(), Mp8.BonusStars[5].Clone()],
            [Mp8.BonusStars[0].Clone(), Mp8.BonusStars[1].Clone(), Mp8.BonusStars[2].Clone(), Mp8.BonusStars[3].Clone(), Mp8.BonusStars[4].Clone(), Mp8.BonusStars[5].Clone()],
            [Mp8.BonusStars[0].Clone(), Mp8.BonusStars[1].Clone(), Mp8.BonusStars[2].Clone(), Mp8.BonusStars[3].Clone(), Mp8.BonusStars[4].Clone(), Mp8.BonusStars[5].Clone()]
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
            
            bonusStars[0][1].Count = Reader.GetCandyUsed(0);
            bonusStars[1][1].Count = Reader.GetCandyUsed(1);
            bonusStars[2][1].Count = Reader.GetCandyUsed(2);
            bonusStars[3][1].Count = Reader.GetCandyUsed(3);
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
            
            bonusStars[0][3].Count = Reader.GetSpacesMoved(0);
            bonusStars[1][3].Count = Reader.GetSpacesMoved(1);
            bonusStars[2][3].Count = Reader.GetSpacesMoved(2);
            bonusStars[3][3].Count = Reader.GetSpacesMoved(3);
            ComputeBonusStarLeader(ref bonusStars[3]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 1, bonusStars[0][3]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 2, bonusStars[1][3]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 3, bonusStars[2][3]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 4, bonusStars[3][3]);
            
            bonusStars[0][4].Count = Reader.GetCandyBought(0);
            bonusStars[1][4].Count = Reader.GetCandyBought(1);
            bonusStars[2][4].Count = Reader.GetCandyBought(2);
            bonusStars[3][4].Count = Reader.GetCandyBought(3);
            ComputeBonusStarLeader(ref bonusStars[4]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 1, bonusStars[0][4]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 2, bonusStars[1][4]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 3, bonusStars[2][4]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 4, bonusStars[3][4]);
            
            bonusStars[0][5].Count = Reader.GetRed(0);
            bonusStars[1][5].Count = Reader.GetRed(1);
            bonusStars[2][5].Count = Reader.GetRed(2);
            bonusStars[3][5].Count = Reader.GetRed(3);
            ComputeBonusStarLeader(ref bonusStars[5]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 1, bonusStars[0][5]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 2, bonusStars[1][5]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 3, bonusStars[2][5]);
            await PlayerConnection.SendAsync("UpdateBonusStar", 4, bonusStars[3][5]);
        }
        
        await base.UpdateLoop();
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using PartyDisplay.Dolphin;
using PartyDisplay.Lib.Data;

namespace PartyDisplay.Models;

public interface IDolphinModel {
    public HubConnection? BoardConnection { set; }
    public HubConnection? PlayerConnection { set; }
    
    public Task UpdateLoop();
}

public abstract class DolphinModel<TReader, TItem> : IDolphinModel
    where TItem : Item
    where TReader : IReader<TItem> {
    
    protected TReader Reader;

    public HubConnection? BoardConnection { protected get; set; }
    public HubConnection? PlayerConnection { protected get; set; }

    public virtual async Task UpdateLoop() {
        if (BoardConnection is not null) {
            await BoardConnection.SendAsync("SetTurnCurrent", Reader.GetCurrentTurn());
            await BoardConnection.SendAsync("SetTurnLimit", Reader.GetTurnLimit());
        }

        if (PlayerConnection is not null) {
            await PlayerConnection.SendAsync("UpdateStarCount", 1, Reader.GetStars(0));
            await PlayerConnection.SendAsync("UpdateStarCount", 2, Reader.GetStars(1));
            await PlayerConnection.SendAsync("UpdateStarCount", 3, Reader.GetStars(2));
            await PlayerConnection.SendAsync("UpdateStarCount", 4, Reader.GetStars(3));

            await PlayerConnection.SendAsync("UpdateCoinCount", 1, Reader.GetCoins(0));
            await PlayerConnection.SendAsync("UpdateCoinCount", 2, Reader.GetCoins(1));
            await PlayerConnection.SendAsync("UpdateCoinCount", 3, Reader.GetCoins(2));
            await PlayerConnection.SendAsync("UpdateCoinCount", 4, Reader.GetCoins(3));

            await PlayerConnection.SendAsync("UpdateRank", 1, Reader.GetRanking(0));
            await PlayerConnection.SendAsync("UpdateRank", 2, Reader.GetRanking(1));
            await PlayerConnection.SendAsync("UpdateRank", 3, Reader.GetRanking(2));
            await PlayerConnection.SendAsync("UpdateRank", 4, Reader.GetRanking(3));

            await PlayerConnection.SendAsync("UpdateSpace", 1, Reader.GetLandedColor(0));
            await PlayerConnection.SendAsync("UpdateSpace", 2, Reader.GetLandedColor(1));
            await PlayerConnection.SendAsync("UpdateSpace", 3, Reader.GetLandedColor(2));
            await PlayerConnection.SendAsync("UpdateSpace", 4, Reader.GetLandedColor(3));

            await PlayerConnection.SendAsync("UpdateCharacter", 1, Reader.GetCharacter(0));
            await PlayerConnection.SendAsync("UpdateCharacter", 2, Reader.GetCharacter(1));
            await PlayerConnection.SendAsync("UpdateCharacter", 3, Reader.GetCharacter(2));
            await PlayerConnection.SendAsync("UpdateCharacter", 4, Reader.GetCharacter(3));

            await PlayerConnection.SendAsync("UpdateStatus", 1, Reader.GetStatus(0));
            await PlayerConnection.SendAsync("UpdateStatus", 2, Reader.GetStatus(1));
            await PlayerConnection.SendAsync("UpdateStatus", 3, Reader.GetStatus(2));
            await PlayerConnection.SendAsync("UpdateStatus", 4, Reader.GetStatus(3));
        }
    }
}
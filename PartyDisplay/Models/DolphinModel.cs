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
        for (byte i = 1; i <= 4; i++) {
            PlayerConnection?.SendAsync("UpdateStarCount", i, Reader.GetStars((byte)(i - 1)));
            PlayerConnection?.SendAsync("UpdateCoinCount", i, Reader.GetCoins((byte)(i - 1)));
            PlayerConnection?.SendAsync("UpdateRank", i, Reader.GetRanking((byte)(i - 1)));
            PlayerConnection?.SendAsync("UpdateSpace", i, Reader.GetLandedColor((byte)(i - 1)));
            PlayerConnection?.SendAsync("UpdateCharacter", i, Reader.GetCharacter((byte)(i - 1)));
            PlayerConnection?.SendAsync("UpdateStatus", i, Reader.GetStatus((byte)(i - 1)));
        }
    }
}
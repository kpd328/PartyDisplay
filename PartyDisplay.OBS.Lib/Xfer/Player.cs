using System.Collections.ObjectModel;
using PartyDisplay.OBS.Lib.Data;

namespace PartyDisplay.OBS.Lib.Xfer;

public class Player : IPlayer<IItem>{
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Character Character { get; set; }
    public Status? Status { get; set; }
    public IItem?[] Items { get; set; } = [];
    public BonusStar[] BonusStars { get; set; }
}
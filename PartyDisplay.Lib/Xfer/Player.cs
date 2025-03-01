using PartyDisplay.Lib.Data;

namespace PartyDisplay.Lib.Xfer;

public class Player : IPlayer<Item>{
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Character Character { get; set; }
    public Status? Status { get; set; }
    public Item?[] Items { get; set; } = [];
    public BonusStar[] BonusStars { get; set; }
}
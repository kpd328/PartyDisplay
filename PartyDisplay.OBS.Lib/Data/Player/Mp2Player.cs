using PartyDisplay.OBS.Lib.Data.Store;

namespace PartyDisplay.OBS.Lib.Data.Player;

public class Mp2Player : IPlayer<Item> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Character Character { get; set; }
    public Status? Status { get; set; }
    public Item?[] Items { get; set; } = new Item[1];
    public BonusStar[] BonusStars { get; set; } = Mp2.BonusStars;
}
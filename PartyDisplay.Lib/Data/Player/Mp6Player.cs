using PartyDisplay.Lib.Data.Items;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Lib.Data.Player;

public class Mp6Player : IPlayer<Mp6Orb> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Character Character { get; set; }
    public Status? Status { get; set; }
    public Mp6Orb?[] Items { get; set; } = new Mp6Orb[3];
    public BonusStar[] BonusStars { get; set; } = Mp6.BonusStars;
}
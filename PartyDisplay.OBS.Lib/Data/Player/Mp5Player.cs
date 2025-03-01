using PartyDisplay.OBS.Lib.Data.Items;
using PartyDisplay.OBS.Lib.Data.Store;

namespace PartyDisplay.OBS.Lib.Data.Player;

public class Mp5Player : IPlayer<Mp5Capsule> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Character Character { get; set; }
    public Status? Status { get; set; }
    public Mp5Capsule?[] Items { get; set; } = new Mp5Capsule[3];
    public BonusStar[] BonusStars { get; set; } = Mp5.BonusStars;
}
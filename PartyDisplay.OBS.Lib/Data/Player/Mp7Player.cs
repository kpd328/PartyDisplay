using PartyDisplay.OBS.Lib.Data.Items;
using PartyDisplay.OBS.Lib.Data.Store;

namespace PartyDisplay.OBS.Lib.Data.Player;

public class Mp7Player : IPlayer<Mp7Orb> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Character Character { get; set; }
    public Status? Status { get; set; }
    public Mp7Orb?[] Items { get; set; } = new Mp7Orb[3];
    public BonusStar[] BonusStars { get; set; } = Mp7.BonusStars;
}
using System.Collections.ObjectModel;
using PartyDisplay.OBS.Lib.Data.Character;
using PartyDisplay.OBS.Lib.Data.Item;
using PartyDisplay.OBS.Lib.Data.Store;

namespace PartyDisplay.OBS.Lib.Data.Player;

public class Mp6Player : IPlayer<Mp6Character, Mp6Orb, IStatus> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Mp6Character Character { get; set; }
    public IStatus? Status { get; set; }
    public Mp6Orb[] Items { get; set; } = new Mp6Orb[3];
    public ObservableCollection<BonusStar> BonusStars { get; set; } = new(Mp6.BonusStars);
}
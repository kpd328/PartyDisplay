using System.Collections.ObjectModel;
using PartyDisplay.OBS.Lib.Data.Character;
using PartyDisplay.OBS.Lib.Data.Item;
using PartyDisplay.OBS.Lib.Data.Store;

namespace PartyDisplay.OBS.Lib.Data.Player;

public class Mp8Player : IPlayer<Mp8Character, Mp8Candy, IStatus> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Mp8Character Character { get; set; }
    public IStatus? Status { get; set; }
    public Mp8Candy[] Items { get; set; } = new Mp8Candy[3];
    public ObservableCollection<BonusStar> BonusStars { get; set; } = new(Mp8.BonusStars);
}
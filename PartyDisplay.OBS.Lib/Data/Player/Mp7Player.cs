using System.Collections.ObjectModel;
using PartyDisplay.OBS.Lib.Data.Character;
using PartyDisplay.OBS.Lib.Data.Item;
using PartyDisplay.OBS.Lib.Data.Store;

namespace PartyDisplay.OBS.Lib.Data.Player;

public class Mp7Player : IPlayer<Mp7Character, Mp7Orb, IStatus> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Mp7Character Character { get; set; }
    public IStatus? Status { get; set; }
    public ObservableCollection<Mp7Orb> Items { get; set; }
    public ObservableCollection<BonusStar> BonusStars { get; set; } = new(Mp7.BonusStars);
}
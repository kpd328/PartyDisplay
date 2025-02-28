using System.Collections.ObjectModel;
using PartyDisplay.OBS.Lib.Data.Character;
using PartyDisplay.OBS.Lib.Data.Item;
using PartyDisplay.OBS.Lib.Data.Store;

namespace PartyDisplay.OBS.Lib.Data.Player;

public class Mp4Player : IPlayer<Mp4Character, Mp4Item> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Mp4Character Character { get; set; }
    public Status? Status { get; set; }
    public Mp4Item?[] Items { get; set; } = new Mp4Item[3];
    public ObservableCollection<BonusStar> BonusStars { get; set; } = new(Mp4.BonusStars);
}
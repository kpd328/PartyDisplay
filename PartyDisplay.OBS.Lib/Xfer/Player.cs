using System.Collections.ObjectModel;
using PartyDisplay.OBS.Lib.Data;

namespace PartyDisplay.OBS.Lib.Xfer;

public class Player : IPlayer<ICharacter, IItem, IStatus>{
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public ICharacter Character { get; set; }
    public IStatus? Status { get; set; }
    public IItem[] Items { get; set; } = [];
    public ObservableCollection<BonusStar> BonusStars { get; set; }
}
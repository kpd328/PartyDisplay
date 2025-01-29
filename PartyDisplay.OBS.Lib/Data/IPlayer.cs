using System.Collections.ObjectModel;

namespace PartyDisplay.OBS.Lib.Data;

public interface IPlayer {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public ICharacter Character { get; set; }
    public IStatus? Status { get; set; }
    public ObservableCollection<IItem> Items { get; set; }
    public ObservableCollection<BonusStar> BonusStars { get; set; }
}

public enum Ranking {
    First = 1,
    Second,
    Third,
    Fourth
}

public enum SpaceColor {
    Blue,
    Red,
    Green,
    Pink
}
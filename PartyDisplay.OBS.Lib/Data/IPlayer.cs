using System.Collections.ObjectModel;

namespace PartyDisplay.OBS.Lib.Data;

public interface IPlayer<TCharacter, TItem, TStatus>
    where TCharacter : ICharacter
    where TItem : IItem
    where TStatus : IStatus {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public TCharacter Character { get; set; }
    public TStatus? Status { get; set; }
    public ObservableCollection<TItem> Items { get; set; }
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
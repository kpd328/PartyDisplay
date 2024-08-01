using System.Collections.ObjectModel;

namespace PartyDisplay.Data {
    public interface IPlayer<TCharacter, TItem> 
        where TCharacter : ICharacter 
        where TItem : IItem {
        public string Name { get; set; }
        public short StarCount { get; set; }
        public short CoinCount { get; set; }
        public Ranking Ranking { get; set; }
        public SpaceColor? LandingColor { get; set; }
        public TCharacter Character { get; set; }
        public ObservableCollection<TItem> Items { get; set; }
        public ObservableCollection<BonusStar> BonusStars { get; }
    }

    public enum Ranking {
        First,
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
}

using System.Collections.ObjectModel;

namespace PartyDisplay.Data {
    public interface IPlayer<TCharacter, TItem> 
        where TCharacter : ICharacter 
        where TItem : IItem {
        public string PlayerName { get; set; }
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Ranking Ranking { get; set; }
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
}

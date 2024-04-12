using System.Collections.ObjectModel;

namespace PartyDisplay.Data.mp2 {
    public class Mp2Player:IPlayer<Mp2Character, Mp2Item> {
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Mp2Character Character { get; set; }
        public ObservableCollection<Mp2Item> Items { get; set; } = [];
        public ObservableCollection<BonusStar> BonusStars { get; }
    }
}

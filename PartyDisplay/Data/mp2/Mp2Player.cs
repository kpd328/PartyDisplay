using System.Collections.ObjectModel;

namespace PartyDisplay.Data.mp2 {
    public class Mp2Player:IPlayer<Mp2Character, Mp2Item> {
        public string Name { get; set; }
        public short StarCount { get; set; }
        public short CoinCount { get; set; }
        public Ranking Ranking { get; set; }
        public Mp2Character Character { get; set; }
        public ObservableCollection<Mp2Item> Items { get; set; } = [];
        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp2Loader.Data.BonusStars);
    }
}

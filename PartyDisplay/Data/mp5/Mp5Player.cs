using System.Collections.ObjectModel;

namespace PartyDisplay.Data.mp5 {
    public class Mp5Player:IPlayer<Mp5Character, Mp5Capsule> {
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Mp5Character Character { get; set; }
        public ObservableCollection<Mp5Capsule> Items { get; set; } = [];
        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp5Loader.Data.BonusStars);
    }
}

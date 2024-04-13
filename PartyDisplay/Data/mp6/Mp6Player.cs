using System.Collections.ObjectModel;

namespace PartyDisplay.Data.mp6 {
    public class Mp6Player:IPlayer<Mp6Character, Mp6Orb> {
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Mp6Character Character { get; set; }
        public ObservableCollection<Mp6Orb> Items { get; set; } = [];
        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp6Loader.Data.BonusStars);
    }
}

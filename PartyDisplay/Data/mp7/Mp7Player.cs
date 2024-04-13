using System.Collections.ObjectModel;

namespace PartyDisplay.Data.mp7 {
    public class Mp7Player:IPlayer<Mp7Character, Mp7Orb> {
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Mp7Character Character { get; set; }
        public ObservableCollection<Mp7Orb> Items { get; set; } = [];
        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp7Loader.Data.BonusStars);
    }
}

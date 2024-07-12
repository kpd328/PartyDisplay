using System.Collections.ObjectModel;

namespace PartyDisplay.Data.mp4 {
    public class Mp4Player:IPlayer<Mp4Character, Mp4Item> {
        public string Name { get; set; }
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Ranking Ranking { get; set; }
        public Mp4Character Character { get; set; }
        public ObservableCollection<Mp4Item> Items { get; set; } = [];
        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp4Loader.Data.BonusStars);
    }
}

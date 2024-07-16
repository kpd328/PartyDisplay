using System.Collections.ObjectModel;

namespace PartyDisplay.Data.mp4 {
    public class Mp4Player:IPlayer<Mp4Character, Mp4Item> {
        public string Name { get; set; }
        public short StarCount { get; set; }
        public short CoinCount { get; set; }
        public Ranking Ranking { get; set; }
        public Mp4Character Character { get; set; }
        public ObservableCollection<Mp4Item> Items { get; set; } = [];
        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp4Loader.Data.BonusStars);
    }
}

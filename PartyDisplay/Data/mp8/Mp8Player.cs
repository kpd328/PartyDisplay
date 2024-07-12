using System.Collections.ObjectModel;

namespace PartyDisplay.Data.mp8 {
    public class Mp8Player:IPlayer<Mp8Character, Mp8Candy> {
        public string PlayerName { get; set; }
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Ranking Ranking { get; set; }
        public Mp8Character Character { get; set; }
        public ObservableCollection<Mp8Candy> Items { get; set; } = [];
        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp8Loader.Data.BonusStars);
    }
}

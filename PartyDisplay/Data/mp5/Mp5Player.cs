using ReactiveUI;
using System.Collections.ObjectModel;

namespace PartyDisplay.Data.mp5 {
    public class Mp5Player:ReactiveObject, IPlayer<Mp5Character, Mp5Capsule> {
        private int starCount;
        private int coinCount;
        private Ranking ranking;
        private Mp5Character _character;

        public string Name { get; set; }
        public int StarCount { get => starCount; set => starCount = value; }
        public int CoinCount { get => coinCount; set => coinCount = value; }
        public Ranking Ranking { get => ranking; set => ranking = value; }
        public Mp5Character Character { 
            get => _character;
            set => this.RaiseAndSetIfChanged(ref _character, value);
        }
        public ObservableCollection<Mp5Capsule> Items { get; set; } = [];
        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp5Loader.Data.BonusStars);
    }
}

using ReactiveUI;
using System.Collections.ObjectModel;

namespace PartyDisplay.Data.mp5 {
    public class Mp5Player:ReactiveObject, IPlayer<Mp5Character, Mp5Capsule> {
        private short _starCount;
        private short _coinCount;
        private Ranking _ranking;
        private Mp5Character _character;

        public string Name { get; set; } = string.Empty;
        public short StarCount { 
            get => _starCount;
            set => this.RaiseAndSetIfChanged(ref _starCount, value);
        }
        public short CoinCount { 
            get => _coinCount;
            set => this.RaiseAndSetIfChanged(ref _coinCount, value); 
        }
        public Ranking Ranking { 
            get => _ranking; 
            set => this.RaiseAndSetIfChanged(ref _ranking, value); 
        }
        public Mp5Character Character { 
            get => _character;
            set => this.RaiseAndSetIfChanged(ref _character, value);
        }
        public ObservableCollection<Mp5Capsule> Items { get; set; } = [];
        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp5Loader.Data.BonusStars);
    }
}

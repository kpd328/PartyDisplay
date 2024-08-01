using PartyDisplay.Data.mp4;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PartyDisplay.Data.mp8 {
    public class Mp8Player:IPlayer<Mp8Character, Mp8Candy>, INotifyPropertyChanged {
        private string _name = string.Empty;
        public string Name {
            get => _name;
            set => SetField(ref _name, value);
        }

        private short _starCount;
        public short StarCount {
            get => _starCount;
            set => SetField(ref _starCount, value);
        }

        private short _coinCoint;
        public short CoinCount {
            get => _coinCoint;
            set => SetField(ref _coinCoint, value);
        }

        private Ranking _ranking;
        public Ranking Ranking {
            get => _ranking;
            set => SetField(ref _ranking, value);
        }

        private SpaceColor? _landingColor;
        public SpaceColor? LandingColor {
            get => _landingColor;
            set => SetField(ref _landingColor, value);
        }

        private Mp8Character _character;
        public Mp8Character Character {
            get => _character;
            set => SetField(ref _character, value);
        }

        private ObservableCollection<Mp8Candy> _items = [];
        public ObservableCollection<Mp8Candy> Items {
            get => _items;
            set => SetField(ref _items, value);
        }

        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp8Loader.Data.GetCopyOfBonusStars());

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "") {
            if(EqualityComparer<T>.Default.Equals(field, value)) {
                return false;
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

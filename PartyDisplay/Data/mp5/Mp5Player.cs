using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PartyDisplay.Data.mp5 {
    public class Mp5Player:IPlayer<Mp5Character, Mp5Capsule>, INotifyPropertyChanged {
        private string _name = string.Empty;
        private short _starCount;
        private short _coinCoint;
        private Ranking _ranking;
        private Mp5Character _character;
        private ObservableCollection<Mp5Capsule> _items = [];

        public string Name {
            get => _name;
            set => SetField(ref _name, value);
        }
        public short StarCount {
            get => _starCount;
            set => SetField(ref _starCount, value);
        }
        public short CoinCount {
            get => _coinCoint;
            set => SetField(ref _coinCoint, value);
        }
        public Ranking Ranking {
            get => _ranking;
            set => SetField(ref _ranking, value);
        }
        public Mp5Character Character {
            get => _character;
            set => SetField(ref _character, value);
        }
        public ObservableCollection<Mp5Capsule> Items {
            get => _items;
            set => SetField(ref _items, value);
        }
        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp5Loader.Data.GetCopyOfBonusStars());

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

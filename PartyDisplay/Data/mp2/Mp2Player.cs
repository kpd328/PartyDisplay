﻿using PartyDisplay.Data.mp4;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PartyDisplay.Data.mp2 {
    public class Mp2Player:IPlayer<Mp2Character, Mp2Item>, INotifyPropertyChanged {
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

        private Mp2Character _character;
        public Mp2Character Character {
            get => _character;
            set => SetField(ref _character, value);
        }

        private ObservableCollection<Mp2Item> _items = [];
        public ObservableCollection<Mp2Item> Items {
            get => _items;
            set => SetField(ref _items, value);
        }

        public ObservableCollection<BonusStar> BonusStars { get; } = new(Mp2Loader.Data.GetCopyOfBonusStars());

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

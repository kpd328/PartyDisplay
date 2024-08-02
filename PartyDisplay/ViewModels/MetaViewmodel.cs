using PartyDisplay.Hook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PartyDisplay.ViewModels {
    public sealed class MetaViewmodel:INotifyPropertyChanged {
        private static readonly Lazy<MetaViewmodel> _instance = new(() => new());
        public static MetaViewmodel Instance => _instance.Value;

        public IGameHarness GameHarness { get; set; }

        private string _p1n = string.Empty;
        public string Port1Name {
            get => _p1n;
            set => SetField(ref _p1n, value);
        }

        private string _p2n = string.Empty;
        public string Port2Name {
            get => _p2n;
            set => SetField(ref _p2n, value);
        }

        private string _p3n = string.Empty;
        public string Port3Name {
            get => _p3n;
            set => SetField(ref _p3n, value);
        }

        private string _p4n = string.Empty;
        public string Port4Name {
            get => _p4n;
            set => SetField(ref _p4n, value);
        }

        public string NameForPort(byte port) {
            return GameHarness.GetPortForPlayer(port) switch {
                0 => Port1Name,
                1 => Port2Name,
                2 => Port3Name,
                3 => Port4Name,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private MetaViewmodel() { }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "") {
            if(EqualityComparer<T>.Default.Equals(field, value)) {
                return false;
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

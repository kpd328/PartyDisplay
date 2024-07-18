using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace PartyDisplay.Data {
    public class BonusStar:INotifyPropertyChanged {
        [JsonIgnore]
        private short _count;

        [JsonInclude]
        public string Name { get; set; }
        [JsonInclude]
        public string ProgressTitle { get; set; }
        [JsonIgnore]
        public short Count {
            get => _count;
            set => SetField(ref _count, value);
        }
        [JsonIgnore]
        private Lazy<Bitmap> _icon;
        [JsonIgnore]
        public Bitmap Icon => _icon.Value;
        [JsonInclude]
        private string IconFile { get; init; }

        [JsonConstructor]
        private BonusStar() {
            _icon = new(() => new(AssetLoader.Open(new Uri($"avares://PartyDisplay{IconFile}"))));
        }

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

        public BonusStar Clone() {
            return new BonusStar() {
                Name = this.Name,
                ProgressTitle = this.ProgressTitle,
                Count = this.Count,
                IconFile = this.IconFile
            };
        }
    }
}

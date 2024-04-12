using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Text.Json.Serialization;

namespace PartyDisplay.Data {
    public class BonusStar {
        [JsonInclude]
        public string Name { get; set; }
        [JsonInclude]
        public string ProgressTitle { get; set; }
        [JsonIgnore]
        public int Count { get; set; }
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
    }
}

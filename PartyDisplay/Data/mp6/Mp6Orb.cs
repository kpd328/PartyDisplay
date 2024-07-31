using Avalonia.Media.Imaging;
using System.Text.Json.Serialization;
using System;
using Avalonia.Platform;

namespace PartyDisplay.Data.mp6 {
    public class Mp6Orb:IItem {
        [JsonInclude]
        public int Index { get; init; }
        [JsonInclude]
        public string Name { get; init; }
        [JsonIgnore]
        private Lazy<Bitmap> _icon;
        [JsonIgnore]
        public Bitmap Icon => _icon.Value;
        [JsonInclude]
        private string IconFile { get; init; }
        [JsonInclude]
        public Mp6OrbType Type { get; init; }

        [JsonConstructor]
        private Mp6Orb() {
            _icon = new(() => new(AssetLoader.Open(new Uri($"avares://PartyDisplay{IconFile}"))));
        }
    }

    public enum Mp6OrbType {
        GREEN,
        YELLOW, 
        RED,
        BLUE
    }
}

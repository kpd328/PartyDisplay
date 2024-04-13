using Avalonia.Media.Imaging;
using System.Text.Json.Serialization;
using System;
using Avalonia.Platform;

namespace PartyDisplay.Data.mp7 {
    public class Mp7Orb:IItem {
        [JsonInclude]
        public string Name { get; init; }
        [JsonIgnore]
        private Lazy<Bitmap> _icon;
        [JsonIgnore]
        public Bitmap Icon => _icon.Value;
        [JsonInclude]
        private string IconFile { get; init; }
        [JsonInclude]
        public Mp7OrbType Type { get; init; }

        [JsonConstructor]
        private Mp7Orb() {
            _icon = new(() => new(AssetLoader.Open(new Uri($"avares://PartyDisplay{IconFile}"))));
        }
    }

    public enum Mp7OrbType {
        SELF,
        THROWN,
        ROADBLOCK,
        CHARACTER,
        OTHER
    }
}

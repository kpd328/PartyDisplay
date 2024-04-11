using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Text.Json.Serialization;

namespace PartyDisplay.Data.mp5 {
    public class Mp5Capsule:IItem {
        [JsonInclude]
        public string Name { get; init; }
        [JsonIgnore]
        private Lazy<Bitmap> _icon;
        [JsonIgnore]
        public Bitmap Icon => _icon.Value;
        [JsonInclude]
        private string IconFile { get; init; }
        [JsonInclude]
        public Mp5CapsuleType Type { get; init; }
        [JsonInclude]
        public int Cost { get; init; }

        [JsonConstructor]
        private Mp5Capsule() {
            _icon = new(() => new(AssetLoader.Open(new Uri($"avaresL//PartyDisplay{IconFile}"))));
        }
    }

    public enum Mp5CapsuleType {
        MOVE,
        COIN,
        CAPSULE,
        SPECIAL
    }
}

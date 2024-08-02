using Avalonia.Media.Imaging;
using System.Text.Json.Serialization;
using System;
using Avalonia.Platform;

namespace PartyDisplay.Data.mp8 {
    public class Mp8Candy:IItem {
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
        public Mp8CandyType Type { get; init; }

        [JsonConstructor]
        private Mp8Candy() {
            _icon = new(() => new(AssetLoader.Open(new Uri($"avares://PartyDisplay{IconFile}"))));
        }
    }

    public enum Mp8CandyType {
        RED,
        GREEN,
        YELLOW,
        BLUE
    }
}

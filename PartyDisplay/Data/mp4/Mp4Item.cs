using Avalonia.Media.Imaging;
using System.Text.Json.Serialization;
using System;
using Avalonia.Platform;

namespace PartyDisplay.Data.mp4 {
    public class Mp4Item:IItem {
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

        [JsonConstructor]
        private Mp4Item() {
            _icon = new(() => new(AssetLoader.Open(new Uri($"avares://PartyDisplay{IconFile}"))));
        }
    }
}

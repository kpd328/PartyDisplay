using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Text.Json.Serialization;

namespace PartyDisplay.Data.mp5 {
    public class Mp5Character:ICharacter {
        [JsonInclude]
        public string Name { get; private init; }
        [JsonIgnore]
        private Lazy<Bitmap> _icon;
        [JsonIgnore]
        public Bitmap Icon => _icon.Value;
        [JsonInclude]
        private string IconFile { get; init; }

        [JsonConstructor]
        private Mp5Character() {
            _icon = new(() => new(AssetLoader.Open(new Uri($"avares://PartyDisplay{IconFile}"))));
        }
    }
}

using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Text.Json.Serialization;
using System;

namespace PartyDisplay.Data.mp7 {
    public class Mp7Character:ICharacter {
        [JsonInclude]
        public string Name { get; private init; }
        [JsonIgnore]
        private Lazy<Bitmap> _icon;
        [JsonIgnore]
        public Bitmap Icon => _icon.Value;
        [JsonInclude]
        private string IconFile { get; init; }

        [JsonConstructor]
        private Mp7Character() {
            _icon = new(() => new(AssetLoader.Open(new Uri($"avares://PartyDisplay{IconFile}"))));
        }
    }
}

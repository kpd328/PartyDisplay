using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Text.Json.Serialization;
using System;

namespace PartyDisplay.Data.mp2 {
    public class Mp2Character:ICharacter {
        [JsonInclude]
        public string Name { get; private init; }
        [JsonIgnore]
        private Lazy<Bitmap> _icon;
        [JsonIgnore]
        public Bitmap Icon => _icon.Value;
        [JsonInclude]
        private string IconFile { get; init; }

        [JsonConstructor]
        private Mp2Character() {
            _icon = new(() => new(AssetLoader.Open(new Uri($"avares://PartyDisplay{IconFile}"))));
        }
    }
}

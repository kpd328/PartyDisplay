using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Text.Json.Serialization;
using System;

namespace PartyDisplay.Data.mp4 {
    public class Mp4Character:ICharacter {
        public string Name { get; private init; }
        public Bitmap Icon { get; private init; }

        [JsonConstructor]
        private Mp4Character(string Name, string IconFile) {
            this.Name = Name;
            Icon = new(AssetLoader.Open(new Uri(IconFile)));
        }
    }
}

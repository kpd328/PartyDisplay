using Avalonia.Media.Imaging;

namespace PartyDisplay.Data.mp4 {
    public class Mp4Character:ICharacter {
        public string Name { get; private init; }
        public Bitmap Icon { get; private init; }
    }
}

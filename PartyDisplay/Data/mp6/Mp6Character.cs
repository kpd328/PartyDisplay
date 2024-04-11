using Avalonia.Media.Imaging;

namespace PartyDisplay.Data.mp6 {
    public class Mp6Character:ICharacter {
        public string Name { get; private init; }
        public Bitmap Icon { get; private init; }
    }
}

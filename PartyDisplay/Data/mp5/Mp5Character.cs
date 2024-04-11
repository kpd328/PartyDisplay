using Avalonia.Media.Imaging;

namespace PartyDisplay.Data.mp5 {
    public class Mp5Character:ICharacter {
        public string Name { get; private init; }
        public Bitmap Icon { get; private init; }
    }
}

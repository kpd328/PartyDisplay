using Avalonia.Media.Imaging;

namespace PartyDisplay.Data.mp7 {
    public class Mp7Character:ICharacter {
        public string Name { get; private init; }
        public Bitmap Icon { get; private init; }
    }
}

using Avalonia.Media.Imaging;

namespace PartyDisplay.Data.mp8 {
    public class Mp8Character:ICharacter {
        public string Name { get; private init; }
        public Bitmap Icon { get; private init; }
    }
}

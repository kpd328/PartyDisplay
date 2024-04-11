using Avalonia.Media.Imaging;

namespace PartyDisplay.Data.mp2 {
    public class Mp2Character:ICharacter {
        public string Name { get; private init; }
        public Bitmap Icon { get; private init; }
    }
}

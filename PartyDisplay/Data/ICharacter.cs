using Avalonia.Media.Imaging;

namespace PartyDisplay.Data {
    public interface ICharacter {
        public string Name { get; }
        public Bitmap Icon { get; }
    }
}

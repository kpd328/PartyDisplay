using Avalonia.Media.Imaging;

namespace PartyDisplay.Data {
    public interface IItem {
        public string Name { get; }
        public Bitmap Icon { get; }
    }
}

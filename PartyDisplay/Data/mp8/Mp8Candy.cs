using Avalonia.Media.Imaging;

namespace PartyDisplay.Data.mp8 {
    public class Mp8Candy:IItem {
        public string Name { get; init; }
        public Bitmap Icon { get; init; }
        public Mp8CandyType Type { get; init; }
    }

    public enum Mp8CandyType {
        RED,
        GREEN,
        YELLOW,
        BLUE
    }
}

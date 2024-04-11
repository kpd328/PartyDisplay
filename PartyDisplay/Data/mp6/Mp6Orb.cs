using Avalonia.Media.Imaging;

namespace PartyDisplay.Data.mp6 {
    public class Mp6Orb:IItem {
        public string Name { get; init; }
        public Bitmap Icon { get; init; }
        public Mp6OrbType Type { get; init; }
    }

    public enum Mp6OrbType {
        GREEN,
        RED,
        YELLOW,
        BLUE
    }
}

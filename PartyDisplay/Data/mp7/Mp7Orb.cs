using Avalonia.Media.Imaging;

namespace PartyDisplay.Data.mp7 {
    public class Mp7Orb:IItem {
        public string Name { get; init; }
        public Bitmap Icon { get; init; }
        public Mp7OrbType Type { get; init; }
    }

    public enum Mp7OrbType {
        SELF,
        THROWN,
        ROADBLOCK,
        CHARACTER,
        OTHER
    }
}

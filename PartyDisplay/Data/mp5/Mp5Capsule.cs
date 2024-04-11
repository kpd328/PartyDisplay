using Avalonia.Media.Imaging;

namespace PartyDisplay.Data.mp5 {
    public class Mp5Capsule:IItem {
        public string Name { get; init; }
        public Bitmap Icon { get; init; }
        public Mp5CapsuleType Type { get; init; }
        public int Cost { get; init; }
    }

    public enum Mp5CapsuleType {
        MOVE,
        COIN,
        CAPSULE,
        SPECIAL
    }
}

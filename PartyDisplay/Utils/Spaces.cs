using Avalonia.Media;
using PartyDisplay.Data;

namespace PartyDisplay.Utils {
    public static class Spaces {
        public static IBrush ToBrush(this SpaceColor? space) => space switch {
            SpaceColor.Blue => new SolidColorBrush(Colors.Blue, 0.25),
            SpaceColor.Red => new SolidColorBrush(Colors.Red, 0.25),
            SpaceColor.Green => new SolidColorBrush(Colors.Green, 0.25),
            _ => new SolidColorBrush(Colors.Transparent)
        };
    }
}

using Avalonia.Media;
using PartyDisplay.Data;

namespace PartyDisplay.Utils {
    public static class Spaces {
        private static IBrush Blue = new SolidColorBrush(Colors.Blue, 0.25);
        private static IBrush Red = new SolidColorBrush(Colors.Red, 0.25);
        private static IBrush Green = new SolidColorBrush(Colors.Green, 0.25);
        private static IBrush Pink = new SolidColorBrush(Colors.Magenta, 0.25);
        private static IBrush Blank = new SolidColorBrush(Colors.Transparent);

        public static IBrush ToBrush(this SpaceColor? space) => space switch {
            SpaceColor.Blue => Blue,
            SpaceColor.Red => Red,
            SpaceColor.Green => Green,
            SpaceColor.Pink => Pink,
            _ => Blank
        };
    }
}

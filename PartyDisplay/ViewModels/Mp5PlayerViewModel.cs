using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PartyDisplay.Data.mp5;
using System;
using System.Linq;

namespace PartyDisplay.ViewModels {
    public class Mp5PlayerViewModel:PlayerViewModelBase<Mp5Player, Mp5Character, Mp5Capsule> {
        public new Mp5Player Player { get; set; } = new() {
            Character = Mp5Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
            Items = [Mp5Loader.Data.Items[0], Mp5Loader.Data.Items[1], Mp5Loader.Data.Items[2]]
        };

        private Bitmap _coinIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp5/HUD/Coin.png")));
        public new Bitmap CoinIcon => _coinIcon;

        private Bitmap _starIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp5/HUD/Star.png")));
        public new Bitmap StarIcon => _starIcon;

        private Bitmap _xIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp5/HUD/HUDFont_x.png")));
        public new Bitmap XIcon => _xIcon;
    }
}

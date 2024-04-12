using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PartyDisplay.Data.mp8;
using System;
using System.Linq;

namespace PartyDisplay.ViewModels {
    public class Mp8PlayerViewModel:PlayerViewModelBase<Mp8Player, Mp8Character, Mp8Candy> {
        public new Mp8Player Player { get; set; } = new() {
            Character = Mp8Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
            Items = [Mp8Loader.Data.Items[0], Mp8Loader.Data.Items[1], Mp8Loader.Data.Items[2]]
        };

        private Bitmap _coinIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp8/HUD/Coin.png")));
        public new Bitmap CoinIcon => _coinIcon;

        private Bitmap _starIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp8/HUD/Star.png")));
        public new Bitmap StarIcon => _starIcon;

        private Bitmap _xIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp8/HUD/HUDFont_x.png")));
        public new Bitmap XIcon => _xIcon;
    }
}

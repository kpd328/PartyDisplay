using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PartyDisplay.Data.mp2;
using System;
using System.Linq;

namespace PartyDisplay.ViewModels {
    public class Mp2PlayerViewModel:PlayerViewModelBase<Mp2Player, Mp2Character, Mp2Item> {
        public new Mp2Player Player { get; set; } = new() {
            Character = Mp2Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
            Items = [Mp2Loader.Data.Items[0]]
        };

        private Bitmap _coinIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp2/HUD/Coin.png")));
        public new Bitmap CoinIcon => _coinIcon;

        private Bitmap _starIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp2/HUD/Star.png")));
        public new Bitmap StarIcon => _starIcon;

        private Bitmap _xIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp2/HUD/HUDFont_x.png")));
        public new Bitmap XIcon => _xIcon;
    }
}

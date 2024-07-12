using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PartyDisplay.Data.mp7;
using System;
using System.Linq;

namespace PartyDisplay.ViewModels {
    public class Mp7PlayerViewModel:PlayerViewModelBase<Mp7Player, Mp7Character, Mp7Orb> {
        public new Mp7Player Player { get; set; } = new() {
            Character = Mp7Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
            Items = [Mp7Loader.Data.Items[0], Mp7Loader.Data.Items[1], Mp7Loader.Data.Items[2]]
        };

        private Bitmap _coinIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp7/HUD/Coin.png")));
        public new Bitmap CoinIcon => _coinIcon;

        private Bitmap _starIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp7/HUD/Star.png")));
        public new Bitmap StarIcon => _starIcon;

        private Bitmap _xIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp7/HUD/HUDFont_x.png")));
        public new Bitmap XIcon => _xIcon;

        public new Bitmap RankIcon => new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp7/HUD/{Player.Ranking}.png")));
    }
}

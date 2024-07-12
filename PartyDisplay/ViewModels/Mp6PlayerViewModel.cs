using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PartyDisplay.Data.mp6;
using System;
using System.Linq;

namespace PartyDisplay.ViewModels {
    public class Mp6PlayerViewModel:PlayerViewModelBase<Mp6Player, Mp6Character, Mp6Orb> {
        public new Mp6Player Player { get; set; } = new() {
            Character = Mp6Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
            Name = "John",
            Items = [Mp6Loader.Data.Items[0], Mp6Loader.Data.Items[1], Mp6Loader.Data.Items[2]]
        };

        private Bitmap _coinIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp6/HUD/Coin.png")));
        public new Bitmap CoinIcon => _coinIcon;

        private Bitmap _starIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp6/HUD/Star.png")));
        public new Bitmap StarIcon => _starIcon;

        private Bitmap _xIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp6/HUD/HUDFont_x.png")));
        public new Bitmap XIcon => _xIcon;

        public new Bitmap RankIcon => new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp6/HUD/{Player.Ranking}.png")));
    }
}

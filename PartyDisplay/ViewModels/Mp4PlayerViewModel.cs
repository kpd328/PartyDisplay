using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PartyDisplay.Data.mp4;
using System;
using System.Linq;

namespace PartyDisplay.ViewModels {
    public class Mp4PlayerViewModel:PlayerViewModelBase<Mp4Player, Mp4Character, Mp4Item> {
        public new Mp4Player Player { get; set; } = new() {
            Character = Mp4Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
            Items = [Mp4Loader.Data.Items[0], Mp4Loader.Data.Items[1], Mp4Loader.Data.Items[2]]
        };

        private Bitmap _coinIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp4/HUD/Coin.png")));
        public new Bitmap CoinIcon => _coinIcon;

        private Bitmap _starIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp4/HUD/Star.png")));
        public new Bitmap StarIcon => _starIcon;

        private Bitmap _xIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp4/HUD/HUDFont_x.png")));
        public new Bitmap XIcon => _xIcon;

        public new Bitmap RankIcon => new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp4/HUD/{Player.Ranking}.png")));
    }
}

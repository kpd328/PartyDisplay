using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PartyDisplay.Data.mp5;
using PartyDisplay.Hook;
using PartyDisplay.Utils;
using ReactiveUI;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace PartyDisplay.ViewModels {
    public class Mp5PlayerViewModel:PlayerViewModelBase<Mp5Player, Mp5Character, Mp5Capsule> {
        public new byte Port { get; init; }
        public new Mp5Player Player { get; set; } = new();

        private Bitmap _coinIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp5/HUD/Coin.png")));
        public new Bitmap CoinIcon => _coinIcon;

        private Bitmap _starIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp5/HUD/Star.png")));
        public new Bitmap StarIcon => _starIcon;

        private Bitmap _xIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp5/HUD/HUDFont_x.png")));
        public new Bitmap XIcon => _xIcon;

        private static Bitmap RankFirst = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp5/HUD/First.png")));
        private static Bitmap RankSecond = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp5/HUD/Second.png")));
        private static Bitmap RankThird = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp5/HUD/Third.png")));
        private static Bitmap RankFourth = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp5/HUD/Fourth.png")));
        public new Bitmap RankIcon => Player.Ranking switch {
            Data.Ranking.First => RankFirst,
            Data.Ranking.Second => RankSecond,
            Data.Ranking.Third => RankThird,
            Data.Ranking.Fourth => RankFourth,
            _ => RankFirst, //Sure, why not
        };

        private ObservableAsPropertyHelper<IBrush> _background;
        public new IBrush Background => _background.Value;

        public Mp5PlayerViewModel(byte port) {
            Port = port;
            _background = this
                .WhenAnyValue(x => x.Player.LandingColor)
                .Select(space => space.ToBrush())
                .DistinctUntilChanged()
                .ObserveOn(RxApp.TaskpoolScheduler)
                .ToProperty(this, x => x.Background);
            Update();
        }

        async void Update() {
            await Observable.Start(() => {
                while(true) {
                    Player.Character = Mp5Harness.Connection.GetCharacterForBoard(Port);
                    Player.Ranking = Mp5Harness.Connection.GetRanking(Port);
                    this.RaisePropertyChanged(nameof(RankIcon));
                    Player.CoinCount = Mp5Harness.Connection.GetCoins(Port);
                    Player.StarCount = Mp5Harness.Connection.GetStars(Port);
                    Player.LandingColor = Mp5Harness.Connection.GetLandedColor(Port);

                    Player.Items = [
                        Mp5Harness.Connection.GetItem(Port, 0),
                        Mp5Harness.Connection.GetItem(Port, 1),
                        Mp5Harness.Connection.GetItem(Port, 2)
                    ];

                    foreach(var bs in Player.BonusStars) {
                        switch(bs.Name) {
                        case "Minigame Star":
                            bs.Count = Mp5Harness.Connection.GetMinigameCoins(Port);
                            break;
                        case "Coin Star":
                            bs.Count = Mp5Harness.Connection.GetMaxCoins(Port);
                            break;
                        case "Happening Star":
                            bs.Count = Mp5Harness.Connection.GetHappening(Port);
                            break;
                        }
                    }
                    Task.Delay(100).Wait();
                }
            }, RxApp.TaskpoolScheduler);
        }
    }
}

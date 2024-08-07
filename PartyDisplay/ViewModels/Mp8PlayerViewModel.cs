using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PartyDisplay.Data.mp8;
using PartyDisplay.Hook;
using PartyDisplay.Utils;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace PartyDisplay.ViewModels {
    public class Mp8PlayerViewModel:PlayerViewModelBase<Mp8Player, Mp8Character, Mp8Candy> {
        public new byte Port { get; init; }
        public new Mp8Player Player { get; set; } = new();

        private Bitmap _coinIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp8/HUD/Coin.png")));
        public new Bitmap CoinIcon => _coinIcon;

        private Bitmap _starIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp8/HUD/Star.png")));
        public new Bitmap StarIcon => _starIcon;

        private Bitmap _xIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp8/HUD/HUDFont_x.png")));
        public new Bitmap XIcon => _xIcon;

        private static Bitmap RankFirst = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp8/HUD/First.png")));
        private static Bitmap RankSecond = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp8/HUD/Second.png")));
        private static Bitmap RankThird = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp8/HUD/Third.png")));
        private static Bitmap RankFourth = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp8/HUD/Fourth.png")));
        public new Bitmap RankIcon => Player.Ranking switch {
            Data.Ranking.First => RankFirst,
            Data.Ranking.Second => RankSecond,
            Data.Ranking.Third => RankThird,
            Data.Ranking.Fourth => RankFourth,
            _ => RankFirst, //Sure, why not
        };

        private ObservableAsPropertyHelper<IBrush> _background;
        public new IBrush Background => _background.Value;

        public new Task<string> Name => Task.Run(() => Meta.NameForPort(Port));

        public Mp8PlayerViewModel(byte port) {
            Port = port;
            _background = this
                .WhenAnyValue(x => x.Player.LandingColor)
                .Select(space => space.ToBrush())
                .DistinctUntilChanged()
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.Background);
            Update();
        }

        async void Update() {
            await Observable.Start(() => {
                while(true) {
                    Player.Character = Mp8Harness.Connection.GetCharacterForBoard(Port);
                    Player.Ranking = Mp8Harness.Connection.GetRanking(Port);
                    this.RaisePropertyChanged(nameof(RankIcon));
                    Player.CoinCount = Mp8Harness.Connection.GetCoins(Port);
                    Player.StarCount = Mp8Harness.Connection.GetStars(Port);
                    Player.LandingColor = Mp8Harness.Connection.GetLandedColor(Port);

                    Player.Items = [
                        Mp8Harness.Connection.GetItem(Port, 0),
                        Mp8Harness.Connection.GetItem(Port, 1),
                        Mp8Harness.Connection.GetItem(Port, 2)
                    ];

                    foreach(var bs in Player.BonusStars) {
                        switch(bs.Name) {
                        case "Minigame Star":
                            bs.Count = Mp8Harness.Connection.GetMinigameCoins(Port);
                            break;
                        case "Candy Star":
                            bs.Count = Mp8Harness.Connection.GetCandyUsed(Port);
                            break;
                        case "Green Star":
                            bs.Count = Mp8Harness.Connection.GetHappening(Port);
                            break;
                        case "Running Star":
                            bs.Count = Mp8Harness.Connection.GetSpacesMoved(Port);
                            break;
                        case "Shopping Star":
                            bs.Count = Mp8Harness.Connection.GetCandyBought(Port);
                            break;
                        case "Red Star":
                            bs.Count = Mp8Harness.Connection.GetRed(Port);
                            break;
                        }
                    }

                    Task.Delay(100).Wait();
                }
            }, RxApp.TaskpoolScheduler);
        }
    }
}

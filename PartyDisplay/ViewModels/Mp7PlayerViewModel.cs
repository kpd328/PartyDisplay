using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PartyDisplay.Data.mp7;
using PartyDisplay.Hook;
using PartyDisplay.Utils;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace PartyDisplay.ViewModels {
    public class Mp7PlayerViewModel:PlayerViewModelBase<Mp7Player, Mp7Character, Mp7Orb> {
        public new byte Port { get; init; }
        public new Mp7Player Player { get; set; } = new();

        private Bitmap _coinIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp7/HUD/Coin.png")));
        public new Bitmap CoinIcon => _coinIcon;

        private Bitmap _starIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp7/HUD/Star.png")));
        public new Bitmap StarIcon => _starIcon;

        private Bitmap _xIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp7/HUD/HUDFont_x.png")));
        public new Bitmap XIcon => _xIcon;

        private static Bitmap RankFirst = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp7/HUD/First.png")));
        private static Bitmap RankSecond = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp7/HUD/Second.png")));
        private static Bitmap RankThird = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp7/HUD/Third.png")));
        private static Bitmap RankFourth = new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp7/HUD/Fourth.png")));
        public new Bitmap RankIcon => Player.Ranking switch {
            Data.Ranking.First => RankFirst,
            Data.Ranking.Second => RankSecond,
            Data.Ranking.Third => RankThird,
            Data.Ranking.Fourth => RankFourth,
            _ => RankFirst, //Sure, why not
        };

        private ObservableAsPropertyHelper<IBrush> _background;
        public new IBrush Background => _background.Value;

        public Mp7PlayerViewModel(byte port) {
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
                    Player.Character = Mp7Harness.Connection.GetCharacterForBoard(Port);
                    Player.Ranking = Mp7Harness.Connection.GetRanking(Port);
                    this.RaisePropertyChanged(nameof(RankIcon));
                    Player.CoinCount = Mp7Harness.Connection.GetCoins(Port);
                    Player.StarCount = Mp7Harness.Connection.GetStars(Port);
                    Player.LandingColor = Mp7Harness.Connection.GetLandedColor(Port);

                    Player.Items = [
                        Mp7Harness.Connection.GetItem(Port, 0),
                        Mp7Harness.Connection.GetItem(Port, 1),
                        Mp7Harness.Connection.GetItem(Port, 2)
                    ];

                    foreach(var bs in Player.BonusStars) {
                        switch(bs.Name) {
                        case "Minigame Star":
                            bs.Count = Mp7Harness.Connection.GetMinigameCoins(Port);
                            break;
                        case "Orb Star":
                            bs.Count = Mp7Harness.Connection.GetOrbsUsed(Port);
                            break;
                        case "Action Star":
                            bs.Count = Mp7Harness.Connection.GetHappening(Port);
                            break;
                        case "Running Star":
                            bs.Count = Mp7Harness.Connection.GetSpacesMoved(Port);
                            break;
                        case "Shopping Star":
                            bs.Count = Mp7Harness.Connection.GetOrbsBought(Port);
                            break;
                        case "Red Star":
                            bs.Count = Mp7Harness.Connection.GetRed(Port);
                            break;
                        }
                    }

                    Task.Delay(100).Wait();
                }
            }, RxApp.TaskpoolScheduler);
        }
    }
}

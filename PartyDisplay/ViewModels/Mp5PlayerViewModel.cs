using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PartyDisplay.Data.mp5;
using PartyDisplay.Hook;
using ReactiveUI;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PartyDisplay.ViewModels {
    public class Mp5PlayerViewModel:PlayerViewModelBase<Mp5Player, Mp5Character, Mp5Capsule> {
        public byte GamePlayer { get; set; }

        public new Mp5Player Player { get; set; } = new() {
            Character = Mp5Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First()
        };

        private Bitmap _coinIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp5/HUD/Coin.png")));
        public new Bitmap CoinIcon => _coinIcon;

        private Bitmap _starIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp5/HUD/Star.png")));
        public new Bitmap StarIcon => _starIcon;

        private Bitmap _xIcon = new(AssetLoader.Open(new Uri("avares://PartyDisplay/Assets/mp5/HUD/HUDFont_x.png")));
        public new Bitmap XIcon => _xIcon;

        public new Bitmap RankIcon => new(AssetLoader.Open(new Uri($"avares://PartyDisplay/Assets/mp5/HUD/{Player.Ranking}.png")));

        public Mp5PlayerViewModel() {
            Update();
        }

        async void Update() {
            await Task.Run(() => {
                while(true) {
                    var delay = 10000;
                    try {
                        Player.Character = Mp5Harness.Connection.GetCharacterForBoard(GamePlayer);
                        this.RaisePropertyChanged(nameof(RankIcon));
                    } catch(Exception) {
                        delay += 5000;
                    }
                    try {
                        Player.Ranking = Mp5Harness.Connection.GetRanking(GamePlayer);
                    } catch(Exception) {}
                    try {
                        Player.CoinCount = Mp5Harness.Connection.GetCoins(GamePlayer);
                    } catch(Exception) {}
                    try {
                        Player.StarCount = Mp5Harness.Connection.GetStars(GamePlayer);
                    } catch(Exception) {}
                    try {
                        var s0 = Mp5Harness.Connection.GetCapsule(GamePlayer, 0);
                        var s1 = Mp5Harness.Connection.GetCapsule(GamePlayer, 1);
                        var s2 = Mp5Harness.Connection.GetCapsule(GamePlayer, 2);
                        if(s2 == null) {
                            Player.Items.RemoveAt(2);
                        }
                        if(s1 == null) {
                            Player.Items.RemoveAt(1);
                        }
                        if(s0 == null) {
                            Player.Items.RemoveAt(0);
                        }
                        if(s0 != null) {
                            Player.Items[0] = s0;
                        }
                        if(s1 != null) {
                            Player.Items[1] = s1;
                        }
                        if(s2 != null) {
                            Player.Items[2] = s2;
                        }
                    } catch(Exception) {}
                    try {
                        foreach(var bs in Player.BonusStars) {
                            switch(bs.Name) {
                            case "Minigame Star":
                                bs.Count = Mp5Harness.Connection.GetMinigameCoins(GamePlayer);
                                break;
                            case "Coin Star":
                                bs.Count = Mp5Harness.Connection.GetMaxCoins(GamePlayer);
                                break;
                            case "Happening Star":
                                bs.Count = Mp5Harness.Connection.GetHappening(GamePlayer);
                                break;
                            }
                        }
                    } catch(Exception) {}
                    Task.Delay(delay);
                }
            });
        }
    }
}

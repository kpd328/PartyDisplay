using PartyDisplay.Data.mp2;
using PartyDisplay.Data.mp4;
using PartyDisplay.Data.mp6;
using PartyDisplay.Data.mp7;
using PartyDisplay.Data.mp8;
using PartyDisplay.Views;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using PartyDisplayProcess;
using PartyDisplay.Hook;
using PartyDisplay.Utils;
using System.Reactive.Linq;

namespace PartyDisplay.ViewModels;

public class MainViewModel:ViewModelBase {
    public string Player1Name { get; set; } = string.Empty;
    public string Player2Name { get; set; } = string.Empty;
    public string Player3Name { get; set; } = string.Empty;
    public string Player4Name { get; set; } = string.Empty;

    private string _pid = string.Empty;
    public string PID {
        get => _pid;
        set => this.RaiseAndSetIfChanged(ref _pid, value);
    }

    private string _dolphinStatus = string.Empty;
    public string DolphinStatus {
        get => _dolphinStatus;
        set => this.RaiseAndSetIfChanged(ref _dolphinStatus, value);
    }

    private string _currentGame = string.Empty;
    public string CurrentGame {
        get => _currentGame;
        set => this.RaiseAndSetIfChanged(ref _currentGame, value);
    }

    private ObservableAsPropertyHelper<bool> _isLaunchEnabled;
    public bool IsLaunchEnabled => _isLaunchEnabled.Value;

    public ReactiveCommand<Unit, Unit> StartGame { get; }

    public MainViewModel() {
        StartGame = ReactiveCommand.Create(CommandStartGame);
        _isLaunchEnabled = this
            .WhenAnyValue(x => x.CurrentGame)
            .Select(game => Games.CheckGame(game) != null)
            .DistinctUntilChanged()
            .ObserveOn(RxApp.TaskpoolScheduler)
            .ToProperty(this, x => x.IsLaunchEnabled);

        Updater();
    }

    void CommandStartGame() {
        //var notImplemented = MessageBoxManager.GetMessageBoxStandard("Game Not Available", "This game is not currently implemented in the app, try another game.", MsBox.Avalonia.Enums.ButtonEnum.Ok);
        PlayerView player1 = new() { Title = "P1 Player Card" };
        PlayerView player2 = new() { Title = "P2 Player Card" };
        PlayerView player3 = new() { Title = "P3 Player Card" };
        PlayerView player4 = new() { Title = "P4 Player Card" };

        switch(Games.CheckGame(CurrentGame)) {
        case Game.MP2:
            player1.DataContext = new Mp2PlayerViewModel() {
                Player = new() {
                    Character = Mp2Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
                    Name = Player1Name ?? "Mario",
                    Ranking = Data.Ranking.First
                }
            };
            player2.DataContext = new Mp2PlayerViewModel() {
                Player = new() {
                    Character = Mp2Loader.Data.Characters.Where(c => c.Name.Equals("Luigi")).First(),
                    Name = Player2Name ?? "Luigi",
                    Ranking = Data.Ranking.Second
                }
            };
            player3.DataContext = new Mp2PlayerViewModel() {
                Player = new() {
                    Character = Mp2Loader.Data.Characters.Where(c => c.Name.Equals("Peach")).First(),
                    Name = Player3Name ?? "Peach",
                    Ranking = Data.Ranking.Third
                }
            };
            player4.DataContext = new Mp2PlayerViewModel() {
                Player = new() {
                    Character = Mp2Loader.Data.Characters.Where(c => c.Name.Equals("Yoshi")).First(),
                    Name = Player4Name ?? "Yoshi",
                    Ranking = Data.Ranking.Fourth
                }
            };
            break;
        case Game.MP4:
            player1.DataContext = new Mp4PlayerViewModel() {
                Player = new() {
                    Character = Mp4Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
                    Name = Player1Name ?? "Mario",
                    Ranking = Data.Ranking.First
                }
            };
            player2.DataContext = new Mp4PlayerViewModel() {
                Player = new() {
                    Character = Mp4Loader.Data.Characters.Where(c => c.Name.Equals("Luigi")).First(),
                    Name = Player2Name ?? "Luigi",
                    Ranking = Data.Ranking.Second
                }
            };
            player3.DataContext = new Mp4PlayerViewModel() {
                Player = new() {
                    Character = Mp4Loader.Data.Characters.Where(c => c.Name.Equals("Peach")).First(),
                    Name = Player3Name ?? "Peach",
                    Ranking = Data.Ranking.Third
                }
            };
            player4.DataContext = new Mp4PlayerViewModel() {
                Player = new() {
                    Character = Mp4Loader.Data.Characters.Where(c => c.Name.Equals("Yoshi")).First(),
                    Name = Player4Name ?? "Yoshi",
                    Ranking = Data.Ranking.Fourth
                }
            };
            break;
        case Game.MP5:
            player1.DataContext = new Mp5PlayerViewModel() {
                PlayerOrder = 0,
                Player = new() {
                    Character = Mp5Harness.Connection.GetCharacterForBoard(0),
                    Name = Player1Name ?? "Mario"
                }
            };
            player2.DataContext = new Mp5PlayerViewModel() {
                PlayerOrder = 1,
                Player = new() {
                    Character = Mp5Harness.Connection.GetCharacterForBoard(1),
                    Name = Player2Name ?? "Luigi"
                }
            };
            player3.DataContext = new Mp5PlayerViewModel() {
                PlayerOrder = 2,
                Player = new() {
                    Character = Mp5Harness.Connection.GetCharacterForBoard(2),
                    Name = Player3Name ?? "Peach"
                }
            };
            player4.DataContext = new Mp5PlayerViewModel() {
                PlayerOrder = 3,
                Player = new() {
                    Character = Mp5Harness.Connection.GetCharacterForBoard(3),
                    Name = Player4Name ?? "Yoshi"
                }
            };
            break;
        case Game.MP6:
            player1.DataContext = new Mp6PlayerViewModel() {
                Player = new() {
                    Character = Mp6Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
                    Name = Player1Name ?? "Mario",
                    Ranking = Data.Ranking.First
                }
            };
            player2.DataContext = new Mp6PlayerViewModel() {
                Player = new() {
                    Character = Mp6Loader.Data.Characters.Where(c => c.Name.Equals("Luigi")).First(),
                    Name = Player2Name ?? "Luigi",
                    Ranking = Data.Ranking.Second
                }
            };
            player3.DataContext = new Mp6PlayerViewModel() {
                Player = new() {
                    Character = Mp6Loader.Data.Characters.Where(c => c.Name.Equals("Peach")).First(),
                    Name = Player3Name ?? "Peach",
                    Ranking = Data.Ranking.Third
                }
            };
            player4.DataContext = new Mp6PlayerViewModel() {
                Player = new() {
                    Character = Mp6Loader.Data.Characters.Where(c => c.Name.Equals("Yoshi")).First(),
                    Name = Player4Name ?? "Yoshi",
                    Ranking = Data.Ranking.Fourth
                }
            };
            break;
        case Game.MP7:
            player1.DataContext = new Mp7PlayerViewModel() {
                Player = new() {
                    Character = Mp7Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
                    Name = Player1Name ?? "Mario",
                    Ranking = Data.Ranking.First
                }
            };
            player2.DataContext = new Mp7PlayerViewModel() {
                Player = new() {
                    Character = Mp7Loader.Data.Characters.Where(c => c.Name.Equals("Luigi")).First(),
                    Name = Player2Name ?? "Luigi",
                    Ranking = Data.Ranking.Second
                }
            };
            player3.DataContext = new Mp7PlayerViewModel() {
                Player = new() {
                    Character = Mp7Loader.Data.Characters.Where(c => c.Name.Equals("Peach")).First(),
                    Name = Player3Name ?? "Peach",
                    Ranking = Data.Ranking.Third
                }
            };
            player4.DataContext = new Mp7PlayerViewModel() {
                Player = new() {
                    Character = Mp7Loader.Data.Characters.Where(c => c.Name.Equals("Yoshi")).First(),
                    Name = Player4Name ?? "Yoshi",
                    Ranking = Data.Ranking.Fourth
                }
            };
            break;
        case Game.MP8:
            player1.DataContext = new Mp8PlayerViewModel() {
                Player = new() {
                    Character = Mp8Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
                    Name = Player1Name ?? "Mario",
                    Ranking = Data.Ranking.First
                }
            };
            player2.DataContext = new Mp8PlayerViewModel() {
                Player = new() {
                    Character = Mp8Loader.Data.Characters.Where(c => c.Name.Equals("Luigi")).First(),
                    Name = Player2Name ?? "Luigi",
                    Ranking = Data.Ranking.Second
                }
            };
            player3.DataContext = new Mp8PlayerViewModel() {
                Player = new() {
                    Character = Mp8Loader.Data.Characters.Where(c => c.Name.Equals("Peach")).First(),
                    Name = Player3Name ?? "Peach",
                    Ranking = Data.Ranking.Third
                }
            };
            player4.DataContext = new Mp8PlayerViewModel() {
                Player = new() {
                    Character = Mp8Loader.Data.Characters.Where(c => c.Name.Equals("Yoshi")).First(),
                    Name = Player4Name ?? "Yoshi",
                    Ranking = Data.Ranking.Fourth
                }
            };
            break;
        default:
            throw new NotImplementedException();
        }

        if(player1.DataContext != null) {
            player1.Show();
        }
        if(player2.DataContext != null) {
            player2.Show();
        }
        if(player3.DataContext != null) {
            player3.Show();
        }
        if(player4.DataContext != null) {
            player4.Show();
        }
    }

    private void UpdateHook() {
        DolphinAccessor.hook();
        DolphinStatus = DolphinAccessor.getStatus() switch {
            DolphinAccessor.DolphinStatus.hooked => "Hooked",
            DolphinAccessor.DolphinStatus.notRunning => "Not Running",
            DolphinAccessor.DolphinStatus.noEmu => "Not Emulating Game",
            DolphinAccessor.DolphinStatus.unHooked => "Unhooked",
            _ => "ERROR: Invalid State",
        };
    }

    private async void Updater() {
        await Observable.Start(() => {
            while(true) {
                UpdateHook();
                CurrentGame = DolphinHook.LoadedGame();
                PID = DolphinAccessor.getPID().ToString();
            }
        }, RxApp.TaskpoolScheduler);
    }
}

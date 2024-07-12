using MsBox.Avalonia;
using PartyDisplay.Data.mp2;
using PartyDisplay.Data.mp4;
using PartyDisplay.Data.mp5;
using PartyDisplay.Data.mp6;
using PartyDisplay.Data.mp7;
using PartyDisplay.Data.mp8;
using PartyDisplay.Views;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;

namespace PartyDisplay.ViewModels;

public class MainViewModel:ViewModelBase {
    private int _gameSelectorIndex = -1;
    public int GameSelectorIndex {
        get => _gameSelectorIndex;
        set {
            _gameSelectorIndex = value;
            this.RaisePropertyChanged(nameof(GameSelectorIsEnabled));
        }
    }
    public bool GameSelectorIsEnabled => GameSelectorIndex > -1;
    public string Player1Name { get; set; }
    public string Player2Name { get; set; }
    public string Player3Name { get; set; }
    public string Player4Name { get; set; }

    public ReactiveCommand<Unit, Unit> StartGame { get; }

    public MainViewModel() {
        StartGame = ReactiveCommand.Create(CommandStartGame);
    }

    void CommandStartGame() {
        //var notImplemented = MessageBoxManager.GetMessageBoxStandard("Game Not Available", "This game is not currently implemented in the app, try another game.", MsBox.Avalonia.Enums.ButtonEnum.Ok);
        PlayerView player1 = new() { Title = "P1 Player Card" };
        PlayerView player2 = new() { Title = "P2 Player Card" };
        PlayerView player3 = new() { Title = "P3 Player Card" };
        PlayerView player4 = new() { Title = "P4 Player Card" };

        switch(GameSelectorIndex) {
        case 0:
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
        case 1:
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
        case 2:
            player1.DataContext = new Mp5PlayerViewModel() {
                Player = new() {
                    Character = Mp5Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First(),
                    Name = Player1Name ?? "Mario",
                    Ranking = Data.Ranking.First
                }
            };
            player2.DataContext = new Mp5PlayerViewModel() { 
                Player = new() {
                    Character = Mp5Loader.Data.Characters.Where(c => c.Name.Equals("Luigi")).First(),
                    Name = Player2Name ?? "Luigi",
                    Ranking = Data.Ranking.Second
                }
            };
            player3.DataContext = new Mp5PlayerViewModel() { 
                Player = new() {
                    Character = Mp5Loader.Data.Characters.Where(c => c.Name.Equals("Peach")).First(),
                    Name = Player3Name ?? "Peach",
                    Ranking = Data.Ranking.Third
                }
            };
            player4.DataContext = new Mp5PlayerViewModel() { 
                Player = new() {
                    Character = Mp5Loader.Data.Characters.Where(c => c.Name.Equals("Yoshi")).First(),
                    Name = Player4Name ?? "Yoshi",
                    Ranking = Data.Ranking.Fourth
                }
            };
            break;
        case 3:
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
        case 4:
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
        case 5:
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
}

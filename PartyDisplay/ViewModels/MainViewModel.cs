using MsBox.Avalonia;
using PartyDisplay.Data.mp5;
using PartyDisplay.Views;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;

namespace PartyDisplay.ViewModels;

public class MainViewModel:ViewModelBase {
    public ReactiveCommand<string, Unit> StartGame { get; }

    public MainViewModel() {
        StartGame = ReactiveCommand.Create<string>(CommandStartGame);
    }

    void CommandStartGame(string game) {
        var notImplemented = MessageBoxManager.GetMessageBoxStandard("Game Not Available", "This game is not currently implemented in the app, try another game.", MsBox.Avalonia.Enums.ButtonEnum.Ok);
        PlayerView player1 = new() { Title = "P1 Player Card" };
        PlayerView player2 = new() { Title = "P2 Player Card" };
        PlayerView player3 = new() { Title = "P3 Player Card" };
        PlayerView player4 = new() { Title = "P4 Player Card" };

        switch(game) {
        case "mp2":
            notImplemented.ShowAsync();
            break;
        case "mp4":
            notImplemented.ShowAsync();
            break;
        case "mp5":
            player1.DataContext = new Mp5PlayerViewModel() {
                Player = new() {
                    Character = Mp5Loader.Data.Characters.Where(c => c.Name.Equals("Mario")).First()
                }
            };
            player2.DataContext = new Mp5PlayerViewModel() { 
                Player = new() {
                    Character = Mp5Loader.Data.Characters.Where(c => c.Name.Equals("Luigi")).First()
                }
            };
            player3.DataContext = new Mp5PlayerViewModel() { 
                Player = new() {
                    Character = Mp5Loader.Data.Characters.Where(c => c.Name.Equals("Peach")).First()
                }
            };
            player4.DataContext = new Mp5PlayerViewModel() { 
                Player = new() {
                    Character = Mp5Loader.Data.Characters.Where(c => c.Name.Equals("Yoshi")).First()
                }
            };
            break;
        case "mp6":
            notImplemented.ShowAsync();
            break;
        case "mp7":
            notImplemented.ShowAsync();
            break;
        case "mp8":
            notImplemented.ShowAsync();
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

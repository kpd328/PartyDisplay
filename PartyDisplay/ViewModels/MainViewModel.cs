using PartyDisplay.Views;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using PartyDisplayProcess;
using PartyDisplay.Hook;
using PartyDisplay.Utils;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace PartyDisplay.ViewModels;

public class MainViewModel:ViewModelBase {
    public MetaViewmodel Meta => MetaViewmodel.Instance;

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

    private string _gameId = string.Empty;
    public string GameId {
        get => _gameId;
        set => this.RaiseAndSetIfChanged(ref _gameId, value);
    }

    private ObservableAsPropertyHelper<string> _currentGame;
    public string CurrentGame => _currentGame.Value;

    private ObservableAsPropertyHelper<string> _region;
    public string Region => _region.Value;

    private ObservableAsPropertyHelper<bool> _isLaunchEnabled;
    public bool IsLaunchEnabled => _isLaunchEnabled.Value;

    public ReactiveCommand<Unit, Unit> StartGame { get; }

    public MainViewModel() {
        StartGame = ReactiveCommand.Create(CommandStartGame);
        _currentGame = this
            .WhenAnyValue(x => x.GameId)
            .Select(id => Games.CheckGame(id).ToDisplayString())
            .DistinctUntilChanged()
            .ObserveOn(RxApp.TaskpoolScheduler)
            .ToProperty(this, x => x.CurrentGame);
        _region = this
            .WhenAnyValue(x => x.GameId)
            .Select(id => Games.CheckRegion(id))
            .DistinctUntilChanged()
            .ObserveOn(RxApp.TaskpoolScheduler)
            .ToProperty(this, x => x.Region);
        _isLaunchEnabled = this
            .WhenAnyValue(x => x.GameId)
            .Select(id => Games.CheckGame(id) != null)
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

        switch(Games.CheckGame(GameId)) {
        case Game.MP2:
            MetaViewmodel.Instance.GameHarness = Mp2Harness.Connection;
            player1.DataContext = new Mp2PlayerViewModel();
            player2.DataContext = new Mp2PlayerViewModel();
            player3.DataContext = new Mp2PlayerViewModel();
            player4.DataContext = new Mp2PlayerViewModel();
            break;
        case Game.MP4:
            MetaViewmodel.Instance.GameHarness = Mp4Harness.Connection;
            player1.DataContext = new Mp4PlayerViewModel(0);
            player2.DataContext = new Mp4PlayerViewModel(1);
            player3.DataContext = new Mp4PlayerViewModel(2);
            player4.DataContext = new Mp4PlayerViewModel(3);
            break;
        case Game.MP5:
            MetaViewmodel.Instance.GameHarness = Mp5Harness.Connection;
            player1.DataContext = new Mp5PlayerViewModel(0);
            player2.DataContext = new Mp5PlayerViewModel(1);
            player3.DataContext = new Mp5PlayerViewModel(2);
            player4.DataContext = new Mp5PlayerViewModel(3);
            break;
        case Game.MP6:
            MetaViewmodel.Instance.GameHarness = Mp6Harness.Connection;
            player1.DataContext = new Mp6PlayerViewModel(0);
            player2.DataContext = new Mp6PlayerViewModel(1);
            player3.DataContext = new Mp6PlayerViewModel(2);
            player4.DataContext = new Mp6PlayerViewModel(3);
            break;
        case Game.MP7:
            MetaViewmodel.Instance.GameHarness = Mp7Harness.Connection;
            player1.DataContext = new Mp7PlayerViewModel(0);
            player2.DataContext = new Mp7PlayerViewModel(1);
            player3.DataContext = new Mp7PlayerViewModel(2);
            player4.DataContext = new Mp7PlayerViewModel(3);
            break;
        case Game.MP8:
            MetaViewmodel.Instance.GameHarness = Mp8Harness.Connection;
            player1.DataContext = new Mp8PlayerViewModel(0);
            player2.DataContext = new Mp8PlayerViewModel(1);
            player3.DataContext = new Mp8PlayerViewModel(2);
            player4.DataContext = new Mp8PlayerViewModel(3);
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
                GameId = DolphinHook.LoadedGame();
                PID = DolphinAccessor.getPID().ToString();
                Task.Delay(100).Wait();
            }
        }, RxApp.TaskpoolScheduler);
    }
}

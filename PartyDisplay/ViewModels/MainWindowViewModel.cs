﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.SignalR.Client;
using PartyDisplay.Lib.Data;
using PartyDisplay.Lib.Data.Store;
using PartyDisplay.Models;
using ReactiveUI;

namespace PartyDisplay.ViewModels;

public class MainWindowViewModel : ViewModelBase {
#region Private Fields
    
    private HubConnection? _boardHubConnection;
    private HubConnection? _playerHubConnection;
    private ITargetBlock<DateTimeOffset>? _streamingDataLoop;
    private CancellationTokenSource? _sdToken;
    
#endregion

#region Properties

    private string _url = "https://localhost:7206";
    public string Url {
        get => _url;
        set => this.RaiseAndSetIfChanged(ref _url, value);
    }

    private IDolphinModel _model;
    public IDolphinModel Model {
        get => _model;
        set {
            this.RaiseAndSetIfChanged(ref _model, value);
            _model.UpdateLoop();
        }
    }

    private Game? _game;
    public Game? Game {
        get => _game;
        private set {
            this.RaiseAndSetIfChanged(ref _game, value);
            _boardHubConnection?.SendAsync("SetGame", _game);
            Model = _game?.Code switch {
                "mp2" => new Mp2Model{BoardConnection = _boardHubConnection, PlayerConnection = _playerHubConnection},
                "mp4" => new Mp4Model{BoardConnection = _boardHubConnection, PlayerConnection = _playerHubConnection},
                "mp5" => new Mp5Model{BoardConnection = _boardHubConnection, PlayerConnection = _playerHubConnection},
                "mp6" => new Mp6Model{BoardConnection = _boardHubConnection, PlayerConnection = _playerHubConnection},
                "mp7" => new Mp7Model{BoardConnection = _boardHubConnection, PlayerConnection = _playerHubConnection},
                "mp8" => new Mp8Model{BoardConnection = _boardHubConnection, PlayerConnection = _playerHubConnection},
                _ => Model
            };
        }
    }
    
    private string? _p1Name;
    public string? P1Name {
        get => _p1Name;
        set {
            this.RaiseAndSetIfChanged(ref _p1Name, value);
            _playerHubConnection?.SendAsync("SetName", 1, _p1Name);
        }
    }
    
    private string? _p2Name;
    public string? P2Name {
        get => _p2Name;
        set {
            this.RaiseAndSetIfChanged(ref _p2Name, value);
            _playerHubConnection?.SendAsync("SetName", 2, _p2Name);
        }
    }
    
    private string? _p3Name;
    public string? P3Name {
        get => _p3Name;
        set {
            this.RaiseAndSetIfChanged(ref _p3Name, value);
            _playerHubConnection?.SendAsync("SetName", 3, _p3Name);
        }
    }
    
    private string? _p4Name;
    public string? P4Name {
        get => _p4Name;
        set {
            this.RaiseAndSetIfChanged(ref _p4Name, value);
            _playerHubConnection?.SendAsync("SetName", 4, _p4Name);
        }
    }

    private bool _signalRConnected;

    public bool SignalRConnected {
        get => _signalRConnected;
        set => this.RaiseAndSetIfChanged(ref _signalRConnected, value);
    }
    
#endregion
    
#region Constructors
    
    public MainWindowViewModel() {
        RefreshDolphin = ReactiveCommand.Create(RunRefreshDolphin);
        RefreshSignalR = ReactiveCommand.Create(RunRefreshSignalR);
        BeginGameDataLoop = ReactiveCommand.Create(RunBeginGameDataLoop);
        EndGameDataLoop = ReactiveCommand.Create(RunEndGameDataLoop);
        
        Task.Run(RunRefreshDolphin);
        Task.Run(RunRefreshSignalR);
    }
    
#endregion

#region Reactive Commands
    public ReactiveCommand<Unit, Task> RefreshDolphin { get; }
    private async Task RunRefreshDolphin() {
        try {
            var id = await Dolphin.Memory.Access.LoadedGameAsync();
            Game = Games.List.SingleOrDefault(i => i.Id == id);
        } catch (FileNotFoundException e) {
            Debug.WriteLine(e);
            Game = null;
        }
    }

    public ReactiveCommand<Unit, Task> RefreshSignalR { get; }
    private async Task RunRefreshSignalR() {
        _boardHubConnection = new HubConnectionBuilder()
            .WithUrl($"{Url}/hub/board")
            .WithAutomaticReconnect()
            .Build();
        
        _boardHubConnection.On<Game>("GetGame", (game) => {
            Game = game;
        });
        
        await _boardHubConnection.StartAsync();
        Model.BoardConnection = _boardHubConnection;
        
        _playerHubConnection = new HubConnectionBuilder()
            .WithUrl($"{Url}/hub/player")
            .WithAutomaticReconnect()
            .Build();
        
        _playerHubConnection.On<byte, string>("GetName", (player, name) => {
            switch (player) {
                case 1:
                    this.RaiseAndSetIfChanged(ref _p1Name, name);
                    break;
                case 2:
                    this.RaiseAndSetIfChanged(ref _p2Name, name);
                    break;
                case 3:
                    this.RaiseAndSetIfChanged(ref _p3Name, name);
                    break;
                case 4:
                    this.RaiseAndSetIfChanged(ref _p4Name, name);
                    break;
            }
        });

        await _playerHubConnection.StartAsync();
        Model.BoardConnection = _playerHubConnection;
        SignalRConnected = _boardHubConnection?.State == HubConnectionState.Connected &&
                           _playerHubConnection?.State == HubConnectionState.Connected;
    }
    
    public ReactiveCommand<Unit, Task> BeginGameDataLoop { get; }
    private async Task RunBeginGameDataLoop() {
        _sdToken = new();
        _streamingDataLoop = CreateNeverEndingTask(now => Model.UpdateLoop(), _sdToken.Token);
        _streamingDataLoop.Post(DateTimeOffset.Now);
    }
    
    public ReactiveCommand<Unit, Task> EndGameDataLoop { get; }
    private async Task RunEndGameDataLoop() {
        using (_sdToken) {
            await _sdToken?.CancelAsync();
        }

        _sdToken = null;
        _streamingDataLoop = null;
    }
    
#endregion

#region Methods

ITargetBlock<DateTimeOffset> CreateNeverEndingTask(Action<DateTimeOffset> action, CancellationToken cancellationToken) {
    ArgumentNullException.ThrowIfNull(action);

    ActionBlock<DateTimeOffset>? block = null;
    block = new(async now => {
        action(now);
        await Task.Delay(TimeSpan.FromSeconds(0.5), cancellationToken).ConfigureAwait(false);
        block.Post(DateTimeOffset.Now);
    }, new ExecutionDataflowBlockOptions {
        CancellationToken = cancellationToken
    });
    return block;
}

#endregion
}
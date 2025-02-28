﻿using System.Collections.ObjectModel;
using PartyDisplay.OBS.Lib.Data.Character;
using PartyDisplay.OBS.Lib.Data.Item;
using PartyDisplay.OBS.Lib.Data.Store;

namespace PartyDisplay.OBS.Lib.Data.Player;

public class Mp5Player : IPlayer<Mp5Character, Mp5Capsule, IStatus> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Mp5Character Character { get; set; }
    public IStatus? Status { get; set; }
    public Mp5Capsule[] Items { get; set; } = new Mp5Capsule[3];
    public ObservableCollection<BonusStar> BonusStars { get; set; } = new(Mp5.BonusStars);
}
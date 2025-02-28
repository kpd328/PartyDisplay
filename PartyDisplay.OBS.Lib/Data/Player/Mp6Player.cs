﻿using System.Collections.ObjectModel;
using PartyDisplay.OBS.Lib.Data.Character;
using PartyDisplay.OBS.Lib.Data.Item;
using PartyDisplay.OBS.Lib.Data.Store;

namespace PartyDisplay.OBS.Lib.Data.Player;

public class Mp6Player : IPlayer<Mp6Character, Mp6Orb> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Mp6Character Character { get; set; }
    public Status? Status { get; set; }
    public Mp6Orb?[] Items { get; set; } = new Mp6Orb[3];
    public BonusStar[] BonusStars { get; set; } = Mp6.BonusStars;
}
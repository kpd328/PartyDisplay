﻿using System.Collections.ObjectModel;
using PartyDisplay.OBS.Lib.Data.Character;
using PartyDisplay.OBS.Lib.Data.Item;
using PartyDisplay.OBS.Lib.Data.Store;

namespace PartyDisplay.OBS.Lib.Data.Player;

public class Mp2Player : IPlayer<Mp2Character, Mp2Item> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Mp2Character Character { get; set; }
    public Status? Status { get; set; }
    public Mp2Item?[] Items { get; set; } = new Mp2Item[1];
    public BonusStar[] BonusStars { get; set; } = Mp2.BonusStars;
}
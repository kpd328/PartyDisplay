﻿using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Lib.Data.Player;

public class Mp4Player : IPlayer<Item> {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Character Character { get; set; }
    public Status? Status { get; set; }
    public Item?[] Items { get; set; } = new Item[3];
    public BonusStar[] BonusStars { get; set; } = Mp4.BonusStars;
}
﻿namespace PartyDisplay.Lib.Data;

public interface IPlayer<TItem>
    where TItem : Item {
    public string Name { get; set; }
    public short StarCount { get; set; }
    public short CoinCount { get; set; }
    public Ranking Ranking { get; set; }
    public SpaceColor? LandingColor { get; set; }
    public Character Character { get; set; }
    public Status? Status { get; set; }
    public TItem?[] Items { get; set; }
    public BonusStar[] BonusStars { get; set; }
}

public enum Ranking {
    First = 1,
    Second,
    Third,
    Fourth
}

public enum SpaceColor {
    Blue,
    Red,
    Green,
    Pink
}
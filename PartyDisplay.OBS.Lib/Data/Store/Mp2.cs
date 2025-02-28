using PartyDisplay.OBS.Lib.Data.Item;

namespace PartyDisplay.OBS.Lib.Data.Store;

public sealed class Mp2 {
    public static Character[] Characters => [
        new(name: "Mario", icon: "/img/character/mp2.mario.png"),
        new(name: "Luigi", icon: "/img/character/mp2.luigi.png"),
        new(name: "Peach", icon: "/img/character/mp2.peach.png"),
        new(name: "Yoshi", icon: "/img/character/mp2.yoshi.png"),
        new(name: "Wario", icon: "/img/character/mp2.wario.png"),
        new(name: "Donkey Kong", icon: "/img/character/mp2.dk.png")
    ];

    public static Board[] Boards => [
        new(name: "Pirate Land", logo: "/img/board/mp2.pirate_land.logo.png",
            small: "/img/board/mp2.pirate_land.small.png"),
        new(name: "Western Land", logo: "/img/board/mp2.western_land.logo.png",
            small: "/img/board/mp2.western_land.small.png"),
        new(name: "Space Land", logo: "/img/board/mp2.space_land.logo.png",
            small: "/img/board/mp2.space_land.small.png"),
        new(name: "Mystery Land", logo: "/img/board/mp2.mystery_land.logo.png",
            small: "/img/board/mp2.mystery_land.small.png"),
        new(name: "Horror Land", logo: "/img/board/mp2.horror_land.logo.png",
            small: "/img/board/mp2.horror_land.small.png"),
        new(name: "Bowser Land", logo: "/img/board/mp2.bowser_land.logo.png",
            small: "/img/board/mp2.bowser_land.small.png"),
    ];

    public static Mp2Item?[] Items => [
        new(name: "Mushroom", icon: "/img/item/mp2.mushroom.png"),
        new(name: "Skeleton Key", icon: "/img/item/mp2.skeletonkey.png"),
        new(name: "Plunder Chest", icon: "/img/item/mp2.plunderchest.png"),
        new(name: "Bowser Bomb", icon: "/img/item/mp2.bowserbomb.png"),
        new(name: "Dueling Glove", icon: "/img/item/mp2.duelingglove.png"),
        new(name: "Warp Block", icon: "/img/item/mp2.warpblock.png"),
        new(name: "Golden Mushroom", icon: "/img/item/mp2.goldenmushroom.png"),
        new(name: "Boo Bell", icon: "/img/item/mp2.boobell.png"),
        new(name: "Bowser Suit", icon: "/img/item/mp2.bowsersuit.png"),
        new(name: "Magic Lamp", icon: "/img/item/mp2.magiclamp.png")
    ];

    public static BonusStar[] BonusStars => [
        new(name: "Minigame Star", progressTitle: "Minigame Coins", icon: "/img/bonusstar/mp2.minigame.png"),
        new(name: "Coin Star", progressTitle: "Coin Total", icon: "/img/bonusstar/mp2.coin.png"),
        new(name: "Happening Star", progressTitle: "Happening Count", icon: "/img/bonusstar/mp2.happening.png")
    ];

    public static Status[] Statuses => [];
}
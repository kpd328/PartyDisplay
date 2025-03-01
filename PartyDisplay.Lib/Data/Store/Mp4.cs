namespace PartyDisplay.Lib.Data.Store;

public static class Mp4 {
    public static Character[] Characters => [
        new(name: "Mario", icon: "/img/character/mp4.mario.png"),
        new(name: "Luigi", icon: "/img/character/mp4.luigi.png"),
        new(name: "Peach", icon: "/img/character/mp4.peach.png"),
        new(name: "Yoshi", icon: "/img/character/mp4.yoshi.png"),
        new(name: "Wario", icon: "/img/character/mp4.wario.png"),
        new(name: "Donkey Kong", icon: "/img/character/mp4.dk.png"),
        new(name: "Daisy", icon: "/img/character/mp4.daisy.png"),
        new(name: "Waluigi", icon: "/img/character/mp4.waluigi.png")
    ];
    
    public static Board[] Boards => [
        new(name: "Toad's Midway Madness", logo: "/img/board/mp4.toads_midway_madness.logo.png",
            small: "/img/board/mp4.toads_midway_madness.small.png"),
        new(name: "Shy Guy's Jungle Jam", logo: "/img/board/mp4.shy_guys_jungle_jam.logo.png",
            small: "/img/board/mp4.shy_guys_jungle_jam.small.png"),
        new(name: "Goomba's Greedy Gala", logo: "/img/board/mp4.goombas_greedy_gala.logo.png",
            small: "/img/board/mp4.goombas_greedy_gala.small.png"),
        new(name: "Boo's Haunted Bash", logo: "/img/board/mp4.boos_haunted_bash.logo.png",
            small: "/img/board/mp4.boos_haunted_bash.small.png"),
        new(name: "Koopa's Seaside Soiree", logo: "/img/board/mp4.koopas_seaside_soiree.logo.png",
            small: "/img/board/mp4.koopas_seaside_soiree.small.png"),
        new(name: "Bowser's Gnarly Party", logo: "/img/board/mp4.bowsers_gnarly_party.logo.png",
            small: "/img/board/mp4.bowsers_gnarly_party.small.png"),
    ];

    public static Item?[] Items => [
        new(name: "Mini Mushroom", icon: "/img/item/mp4.minimushroom.png"),
        new(name: "Mega Mushroom", icon: "/img/item/mp4.megamushroom.png"),
        new(name: "Super Mini Mushroom", icon: "/img/item/mp4.superminimushroom.png"),
        new(name: "Super Mega Mushroom", icon: "/img/item/mp4.supermegamushroom.png"),
        new(name: "MiniMega Hammer", icon: "/img/item/mp4.minimegahammer.png"),
        new(name: "Warp Pipe", icon: "/img/item/mp4.warppipe.png"),
        new(name: "Swap Card", icon: "/img/item/mp4.swapcard.png"),
        new(name: "Sparky Sticker", icon: "/img/item/mp4.sparkysticker.png"),
        new(name: "Gaddlight", icon: "/img/item/mp4.gaddlight.png"),
        new(name: "Chomp Call", icon: "/img/item/mp4.chompcall.png"),
        new(name: "Bowser Suit", icon: "/img/item/mp4.bowsersuit.png"),
        new(name: "Boo's Crystal Ball", icon: "/img/item/mp4.booscrystalball.png"),
        new(name: "Magic Lamp", icon: "/img/item/mp4.magiclamp.png"),
        new(name: "Item Bag", icon: "/img/item/mp4.itembag.png")
    ];

    public static BonusStar[] BonusStars => [
        new(name: "Minigame Star", progressTitle: "Minigame Coins", icon: "/img/bonusstar/mp4.minigame.png"),
        new(name: "Coin Star", progressTitle: "Coin Total", icon: "/img/bonusstar/mp4.coin.png"),
        new(name: "Happening Star", progressTitle: "Happening Count", icon: "/img/bonusstar/mp4.happening.png")
    ];

    public static Status[] Statuses => [
        new(name: "Mini Hammer", icon: "/img/status/mp4.minimegahammer.mini.png"),
        new(name: "Mega Hammer", icon: "/img/status/mp4.minimegahammer.mega.png")
    ];
}
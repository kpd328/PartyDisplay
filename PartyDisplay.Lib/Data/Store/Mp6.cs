using PartyDisplay.Lib.Data.Items;
using static PartyDisplay.Lib.Data.Items.Mp6OrbType;

namespace PartyDisplay.Lib.Data.Store;

public static class Mp6 {
    public static Character[] Characters => [
        new(name: "Mario", icon: "/img/character/mp6.mario.png"),
        new(name: "Luigi", icon: "/img/character/mp6.luigi.png"),
        new(name: "Peach", icon: "/img/character/mp6.peach.png"),
        new(name: "Yoshi", icon: "/img/character/mp6.yoshi.png"),
        new(name: "Wario", icon: "/img/character/mp6.wario.png"),
        new(name: "Daisy", icon: "/img/character/mp6.daisy.png"),
        new(name: "Waluigi", icon: "/img/character/mp6.waluigi.png"),
        new(name: "Toad", icon: "/img/character/mp6.toad.png"),
        new(name: "Boo", icon: "/img/character/mp6.boo.png"),
        new(name: "Koopa Kid", icon: "/img/character/mp6.koopakid.png"),
        new(name: "Toadette", icon: "/img/character/mp6.toadette.png")
    ];
    
    public static Board[] Boards => [
        new(name: "Towering Treetop", logo: "/img/board/mp6.towering_treetop.logo.png",
            small: "/img/board/mp6.towering_treetop.small.png"),
        new(name: "E. Gadd'S Garage", logo: "/img/board/mp6.egadds_garage.logo.png",
            small: "/img/board/mp6.egadds_garage.small.png"),
        new(name: "Faire Square", logo: "/img/board/mp6.faire_square.logo.png",
            small: "/img/board/mp6.faire_square.small.png"),
        new(name: "Snowflake Lake", logo: "/img/board/mp6.snowflake_lake.logo.png",
            small: "/img/board/mp6.snowflake_lake.small.png"),
        new(name: "Castaway Bay", logo: "/img/board/mp6.castaway_bay.logo.png",
            small: "/img/board/mp6.castaway_bay.small.png"),
        new(name: "Clockwork Castle", logo: "/img/board/mp6.clockwork_castle.logo.png",
            small: "/img/board/mp6.clockwork_castle.small.png"),
    ];

    public static Mp6Orb?[] Items => [
        new(name: "Mushroom", icon: "/img/item/mp6.mushroom.png", type: Green),
        new(name: "Super 'Shroom", icon: "/img/item/mp6.supershroom.png", type: Green),
        new(name: "Sluggish 'Shroom", icon: "/img/item/mp6.sluggishshroom.png", type: Green),
        new(name: "Metal Mushroom", icon: "/img/item/mp6.metalmushroom.png", type: Green),
        new(name: "Bullet Bill", icon: "/img/item/mp6.bulletbill.png", type: Green),
        new(name: "Warp Pipe", icon: "/img/item/mp6.warppipe.png", type: Green),
        new(name: "Flutter", icon: "/img/item/mp6.flutter.png", type: Green),
        new(name: "Cursed Mushroom", icon: "/img/item/mp6.cursedmushroom.png", type: Green),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Spiny", icon: "/img/item/mp6.spiny.png", type: Yellow),
        new(name: "Goomba", icon: "/img/item/mp6.goomba.png", type: Yellow),
        new(name: "Piranha Plant", icon: "/img/item/mp6.piranhaplant.png", type: Yellow),
        new(name: "Klepto", icon: "/img/item/mp6.klepto.png", type: Yellow),
        null, //These Gaps are intentional
        new(name: "Toady", icon: "/img/item/mp6.toady.png", type: Yellow),
        new(name: "Kamek", icon: "/img/item/mp6.kamek.png", type: Yellow),
        new(name: "Mr. Blizzard", icon: "/img/item/mp6.mrblizzard.png", type: Yellow),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Podoboo", icon: "/img/item/mp6.podoboo.png", type: Red),
        new(name: "Zap", icon: "/img/item/mp6.zap.png", type: Red),
        new(name: "Tweester", icon: "/img/item/mp6.tweester.png", type: Red),
        new(name: "Thwomp", icon: "/img/item/mp6.thwomp.png", type: Red),
        new(name: "Bob-omb", icon: "/img/item/mp6.bobomb.png", type: Red),
        new(name: "Koopa Troopa", icon: "/img/item/mp6.koopatroopa.png", type: Red),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Snack", icon: "/img/item/mp6.snack.png", type: Blue),
        new(name: "Boo-Away", icon: "/img/item/mp6.booaway.png", type: Blue)
    ];

    public static BonusStar[] BonusStars => [
        new(name: "Minigame Star", progressTitle: "Minigame Coins", icon: "/img/bonusstar/mp6.minigame.png"),
        new(name: "Orb Star", progressTitle: "Orbs Thrown", icon: "/img/bonusstar/mp6.orb.png"),
        new(name: "Action Star", progressTitle: "Action Count", icon: "/img/bonusstar/mp6.action.png")
    ];

    public static Status[] Statuses => [];
}
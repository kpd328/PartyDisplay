using PartyDisplay.OBS.Lib.Data.Character;
using PartyDisplay.OBS.Lib.Data.Item;
using static PartyDisplay.OBS.Lib.Data.Item.Mp6OrbType;

namespace PartyDisplay.OBS.Lib.Data.Store;

public class Mp6 {
    public static Mp6Character[] Characters => [
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

    public static Mp6Orb?[] Items => [
        new(name: "Mushroom", icon: "/img/item/mp6.mushroom.png", type: GREEN),
        new(name: "Super 'Shroom", icon: "/img/item/mp6.supershroom.png", type: GREEN),
        new(name: "Sluggish 'Shroom", icon: "/img/item/mp6.sluggishshroom.png", type: GREEN),
        new(name: "Metal Mushroom", icon: "/img/item/mp6.metalmushroom.png", type: GREEN),
        new(name: "Bullet Bill", icon: "/img/item/mp6.bulletbill.png", type: GREEN),
        new(name: "Warp Pipe", icon: "/img/item/mp6.warppipe.png", type: GREEN),
        new(name: "Flutter", icon: "/img/item/mp6.flutter.png", type: GREEN),
        new(name: "Cursed Mushroom", icon: "/img/item/mp6.cursedmushroom.png", type: GREEN),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Spiny", icon: "/img/item/mp6.spiny.png", type: YELLOW),
        new(name: "Goomba", icon: "/img/item/mp6.goomba.png", type: YELLOW),
        new(name: "Piranha Plant", icon: "/img/item/mp6.piranhaplant.png", type: YELLOW),
        new(name: "Klepto", icon: "/img/item/mp6.klepto.png", type: YELLOW),
        null, //These Gaps are intentional
        new(name: "Toady", icon: "/img/item/mp6.toady.png", type: YELLOW),
        new(name: "Kamek", icon: "/img/item/mp6.kamek.png", type: YELLOW),
        new(name: "Mr. Blizzard", icon: "/img/item/mp6.mrblizzard.png", type: YELLOW),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Podoboo", icon: "/img/item/mp6.podoboo.png", type: RED),
        new(name: "Zap", icon: "/img/item/mp6.zap.png", type: RED),
        new(name: "Tweester", icon: "/img/item/mp6.tweester.png", type: RED),
        new(name: "Thwomp", icon: "/img/item/mp6.thwomp.png", type: RED),
        new(name: "Bob-omb", icon: "/img/item/mp6.bobomb.png", type: RED),
        new(name: "Koopa Troopa", icon: "/img/item/mp6.koopatroopa.png", type: RED),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Snack", icon: "/img/item/mp6.snack.png", type: BLUE),
        new(name: "Boo-Away", icon: "/img/item/mp6.booaway.png", type: BLUE)
    ];

    public static BonusStar[] BonusStars => [
        new(name: "Minigame Star", progressTitle: "Minigame Coins", icon: "/img/bonusstar/mp6.minigame.png"),
        new(name: "Orb Star", progressTitle: "Orbs Thrown", icon: "/img/bonusstar/mp6.orb.png"),
        new(name: "Action Star", progressTitle: "Action Count", icon: "/img/bonusstar/mp6.action.png")
    ];

    public static Status[] Statuses => [];
}
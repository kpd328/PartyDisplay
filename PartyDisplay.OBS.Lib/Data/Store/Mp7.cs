using PartyDisplay.OBS.Lib.Data.Item;
using static PartyDisplay.OBS.Lib.Data.Item.Mp7OrbType;

namespace PartyDisplay.OBS.Lib.Data.Store;

public class Mp7 {
    public static Character[] Characters => [
        new(name: "Mario", icon: "/img/character/mp7.mario.png"),
        new(name: "Luigi", icon: "/img/character/mp7.luigi.png"),
        new(name: "Peach", icon: "/img/character/mp7.peach.png"),
        new(name: "Yoshi", icon: "/img/character/mp7.yoshi.png"),
        new(name: "Wario", icon: "/img/character/mp7.wario.png"),
        new(name: "Daisy", icon: "/img/character/mp7.daisy.png"),
        new(name: "Waluigi", icon: "/img/character/mp7.waluigi.png"),
        new(name: "Toad", icon: "/img/character/mp7.toad.png"),
        new(name: "Boo", icon: "/img/character/mp7.boo.png"),
        new(name: "Koopa Kid", icon: "/img/character/mp7.koopakid.png"),
        new(name: "Toadette", icon: "/img/character/mp7.toadette.png"),
        new(name: "Birdo", icon: "/img/character/mp7.birdo.png"),
        new(name: "Dry Bones", icon: "/img/character/mp7.drybones.png")
    ];
    
    public static Board[] Boards => [
        new(name: "Grand Canal", logo: "/img/board/mp7.grand_canal.logo.png",
            small: "/img/board/mp7.grand_canal.small.png"),
        new(name: "Pagoda Peak", logo: "/img/board/mp7.pagoda_peak.logo.png",
            small: "/img/board/mp7.pagoda_peak.small.png"),
        new(name: "Pyramid Park", logo: "/img/board/mp7.pyramid_park.logo.png",
            small: "/img/board/mp7.pyramid_park.small.png"),
        new(name: "Neon Heights", logo: "/img/board/mp7.neon_heights.logo.png",
            small: "/img/board/mp7.neon_heights.small.png"),
        new(name: "Windmillville", logo: "/img/board/mp7.windmillville.logo.png",
            small: "/img/board/mp7.windmillville.small.png"),
        new(name: "Bowser'S Enchanted Inferno!", logo: "/img/board/mp7.bowsers_enchanted_inferno.logo.png",
            small: "/img/board/mp7.bowsers_enchanted_inferno.small.png"),
    ];

    public static Mp7Orb?[] Items => [
        new(name: "Mushroom", icon: "/img/item/mp7.mushroom.png", type: SELF),
        new(name: "Super 'Shroom", icon: "/img/item/mp7.supershroom.png", type: SELF),
        new(name: "Slow 'Shroom", icon: "/img/item/mp7.slowshroom.png", type: SELF),
        new(name: "Metal Mushroom", icon: "/img/item/mp7.metalmushroom.png", type: SELF),
        new(name: "Flutter", icon: "/img/item/mp7.flutter.png", type: SELF),
        new(name: "Cannon", icon: "/img/item/mp7.cannon.png", type: SELF),
        new(name: "Snack", icon: "/img/item/mp7.snack.png", type: SELF),
        new(name: "Lakitu", icon: "/img/item/mp7.lakitu.png", type: SELF),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Hammer Bro", icon: "/img/item/mp7.hammerbro.png", type: THROWN),
        new(name: "Piranha Plant", icon: "/img/item/mp7.piranhaplant.png", type: THROWN),
        new(name: "Spear Guy", icon: "/img/item/mp7.spearguy.png", type: THROWN),
        new(name: "Kamek", icon: "/img/item/mp7.kamek.png", type: THROWN),
        new(name: "Toady", icon: "/img/item/mp7.toady.png", type: THROWN),
        new(name: "Mr. Blizzard", icon: "/img/item/mp7.mrblizzard.png", type: THROWN),
        new(name: "Bandit", icon: "/img/item/mp7.bandit.png", type: THROWN),
        new(name: "Pink Boo", icon: "/img/item/mp7.pinkboo.png", type: THROWN),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Spiny", icon: "/img/item/mp7.spiny.png", type: ROADBLOCK),
        new(name: "Zap", icon: "/img/item/mp7.zap.png", type: ROADBLOCK),
        new(name: "Tweester", icon: "/img/item/mp7.tweester.png", type: ROADBLOCK),
        new(name: "Thwomp", icon: "/img/item/mp7.thwomp.png", type: ROADBLOCK),
        new(name: "Warp Pipe", icon: "/img/item/mp7.warppipe.png", type: ROADBLOCK),
        new(name: "Bob-omb", icon: "/img/item/mp7.bobomb.png", type: ROADBLOCK),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Fireball", icon: "/img/item/mp7.fireball.png", type: CHARACTER),
        new(name: "Flower", icon: "/img/item/mp7.flower.png", type: CHARACTER),
        new(name: "Egg", icon: "/img/item/mp7.egg.png", type: CHARACTER),
        new(name: "Vacuum", icon: "/img/item/mp7.vacuum.png", type: CHARACTER),
        new(name: "Magic", icon: "/img/item/mp7.magic.png", type: CHARACTER),
        new(name: "Triple 'Shroom", icon: "/img/item/mp7.tripleshroom.png", type: CHARACTER)
    ];

    public static BonusStar[] BonusStars => [
        new(name: "Minigame Star", progressTitle: "Minigame Coins", icon: "/img/bonusstar/mp7.minigame.png"),
        new(name: "Orb Star", progressTitle: "Orbs Used", icon: "/img/bonusstar/mp7.orb.png"),
        new(name: "Action Star", progressTitle: "Action Count", icon: "/img/bonusstar/mp7.action.png"),
        new(name: "Running Star", progressTitle: "Spaces Moved", icon: "/img/bonusstar/mp7.running.png"),
        new(name: "Shopping Star", progressTitle: "Coins Spent", icon: "/img/bonusstar/mp7.shopping.png"),
        new(name: "Red Star", progressTitle: "Red Count", icon: "/img/bonusstar/mp7.red.png")
    ];
    
    public static Status[] Statuses => [
        new(name: "Mushroom", icon: "/img/status/mp7.mushroom.png"),
        new(name: "Super 'Shroom", icon: "/img/status/mp7.supershroom.png"),
        new(name: "Slow 'Shroom", icon: "/img/status/mp7.slowshroom.png"),
        new(name: "Metal Mushroom", icon: "/img/status/mp7.metalmushroom.png"),
        new(name: "Cursed Mushroom", icon: "/img/status/mp7.cursedmushroom.png"),
        new(name: "Snack", icon: "/img/status/mp7.snack.png"),
        new(name: "Fireball", icon: "/img/status/mp7.fireball.png"),
        new(name: "Flower", icon: "/img/status/mp7.flower.png"),
        new(name: "Egg", icon: "/img/status/mp7.egg.png"),
        new(name: "Magic", icon: "/img/status/mp7.magic.png"),
    ];
}
﻿using PartyDisplay.Lib.Data.Items;
using static PartyDisplay.Lib.Data.Items.Mp5CapsuleType;

namespace PartyDisplay.Lib.Data.Store;

public static class Mp5 {
    public static Character[] Characters => [
        new(name: "Mario", icon: "/img/character/mp5.mario.png"),
        new(name: "Luigi", icon: "/img/character/mp5.luigi.png"),
        new(name: "Peach", icon: "/img/character/mp5.peach.png"),
        new(name: "Yoshi", icon: "/img/character/mp5.yoshi.png"),
        new(name: "Wario", icon: "/img/character/mp5.wario.png"),
        new(name: "Daisy", icon: "/img/character/mp5.daisy.png"),
        new(name: "Waluigi", icon: "/img/character/mp5.waluigi.png"),
        new(name: "Toad", icon: "/img/character/mp5.toad.png"),
        new(name: "Boo", icon: "/img/character/mp5.boo.png"),
        new(name: "Koopa Kid", icon: "/img/character/mp5.koopakid.png"),
        new(name: "Red Koopa Kid", icon: "/img/character/mp5.redkkid.png"),
        new(name: "Green Koopa Kid", icon: "/img/character/mp5.greenkkid.png"),
        new(name: "Blue Koopa Kid", icon: "/img/character/mp5.bluekkid.png")
    ];
    
    public static Board[] Boards => [
        new(name: "Toy Dream", logo: "/img/board/mp5.toy_dream.logo.png",
            small: "/img/board/mp5.toy_dream.small.png"),
        new(name: "Rainbow Dream", logo: "/img/board/mp5.rainbow_dream.logo.png",
            small: "/img/board/mp5.rainbow_dream.small.png"),
        new(name: "Pirate Dream", logo: "/img/board/mp5.pirate_dream.logo.png",
            small: "/img/board/mp5.pirate_dream.small.png"),
        new(name: "Undersea Dream", logo: "/img/board/mp5.undersea_dream.logo.png",
            small: "/img/board/mp5.undersea_dream.small.png"),
        new(name: "Future Dream", logo: "/img/board/mp5.future_dream.logo.png",
            small: "/img/board/mp5.future_dream.small.png"),
        new(name: "Sweet Dream", logo: "/img/board/mp5.sweet_dream.logo.png",
            small: "/img/board/mp5.sweet_dream.small.png"),
        new(name: "Bowser Nightmare", logo: "/img/board/mp5.bowser_nightmare.logo.png",
            small: "/img/board/mp5.bowser_nightmare.small.png"),
    ];

    public static Mp5Capsule?[] Items => [
        new(name: "Mushroom", icon: "/img/item/mp5.mushroom.png", type: Move, cost: 5),
        new(name: "Super Mushroom", icon: "/img/item/mp5.supermushroom.png", type: Move, cost: 10),
        new(name: "Cursed Mushroom", icon: "/img/item/mp5.cursedmushroom.png", type: Move, cost: 5),
        new(name: "Warp Pipe", icon: "/img/item/mp5.warppipe.png", type: Move, cost: 10),
        new(name: "Klepto", icon: "/img/item/mp5.klepto.png", type: Move, cost: 10),
        new(name: "Bubble", icon: "/img/item/mp5.bubble.png", type: Move, cost: 10),
        new(name: "Wiggler", icon: "/img/item/mp5.wiggler.png", type: Move, cost: 20),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Hammer Bro", icon: "/img/item/mp5.hammerbro.png", type: Coin, cost: 5),
        new(name: "Coin Block", icon: "/img/item/mp5.coinblock.png", type: Coin, cost: 5),
        new(name: "Spiny", icon: "/img/item/mp5.spiny.png", type: Coin, cost: 5),
        new(name: "Paratroopa", icon: "/img/item/mp5.paratroopa.png", type: Coin, cost: 10),
        new(name: "Bullet Bill", icon: "/img/item/mp5.bulletbill.png", type: Coin, cost: 10),
        new(name: "Goomba", icon: "/img/item/mp5.goomba.png", type: Coin, cost: 5),
        new(name: "Bob-omb", icon: "/img/item/mp5.bobomb.png", type: Coin, cost: 0),
        new(name: "Koopa Bank", icon: "/img/item/mp5.koopabank.png", type: Coin, cost: 10),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Kamek", icon: "/img/item/mp5.kamek.png", type: Capsule, cost: 10),
        new(name: "Mr. Blizzard", icon: "/img/item/mp5.mrblizzard.png", type: Capsule, cost: 5),
        new(name: "Piranha Plant", icon: "/img/item/mp5.piranhaplant.png", type: Coin, cost: 5),
        new(name: "Magikoopa", icon: "/img/item/mp5.magikoopa.png", type: Capsule, cost: 10),
        new(name: "Ukiki", icon: "/img/item/mp5.ukiki.png", type: Capsule, cost: 10),
        new(name: "Lakitu", icon: "/img/item/mp5.lakitu.png", type: Capsule, cost: 10),
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        null, //These Gaps are intentional
        new(name: "Tweester", icon: "/img/item/mp5.tweester.png", type: Special, cost: 15),
        new(name: "Duel", icon: "/img/item/mp5.duel.png", type: Special, cost: 10),
        new(name: "Chain Chomp", icon: "/img/item/mp5.chainchomp.png", type: Special, cost: 0),
        new(name: "Bone", icon: "/img/item/mp5.bone.png", type: Special, cost: 0),
        new(name: "Bowser", icon: "/img/item/mp5.bowser.png", type: Special, cost: 0),
        new(name: "Chance", icon: "/img/item/mp5.chance.png", type: Special, cost: 20),
        new(name: "Miracle", icon: "/img/item/mp5.miracle.png", type: Special, cost: 0)
    ];

    public static BonusStar[] BonusStars => [
        new(name: "Minigame Star", progressTitle: "Minigame Coins", icon: "/img/bonusstar/mp5.minigame.png"),
        new(name: "Coin Star", progressTitle: "Coin Total", icon: "/img/bonusstar/mp5.coin.png"),
        new(name: "Happening Star", progressTitle: "Happening Count", icon: "/img/bonusstar/mp5.happening.png")
    ];

    public static Status[] Statuses => [
        new(name: "Mushroom", icon: "/img/status/mp5.mushroom.png"),
        new(name: "Super Mushroom", icon: "/img/status/mp5.supermushroom.png"),
        new(name: "Cursed Mushroom", icon: "/img/status/mp5.cursedmushroom.png"),
        new(name: "Bullet Bill", icon: "/img/status/mp5.bulletbill.png")
    ];
}
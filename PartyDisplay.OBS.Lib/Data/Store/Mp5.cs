using PartyDisplay.OBS.Lib.Data.Character;
using PartyDisplay.OBS.Lib.Data.Item;
using static PartyDisplay.OBS.Lib.Data.Item.Mp5CapsuleType;

namespace PartyDisplay.OBS.Lib.Data.Store;

public class Mp5 {
    public static Mp5Character[] Characters => [
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

    public static Mp5Capsule[] Items => [
        new(name: "Mushroom", icon: "/img/item/mp5.mushroom.png", type: MOVE, cost: 5),
        new(name: "Super Mushroom", icon: "/img/item/mp5.supermushroom.png", type: MOVE, cost: 10),
        new(name: "Cursed Mushroom", icon: "/img/item/mp5.cursedmushroom.png", type: MOVE, cost: 5),
        new(name: "Warp Pipe", icon: "/img/item/mp5.warppipe.png", type: MOVE, cost: 10),
        new(name: "Klepto", icon: "/img/item/mp5.klepto.png", type: MOVE, cost: 10),
        new(name: "Bubble", icon: "/img/item/mp5.bubble.png", type: MOVE, cost: 10),
        new(name: "Wiggler", icon: "/img/item/mp5.wiggler.png", type: MOVE, cost: 20),
        new(), //These Gaps are intentional
        new(), //These Gaps are intentional
        new(), //These Gaps are intentional
        new(name: "Hammer Bro", icon: "/img/item/mp5.hammerbro.png", type: COIN, cost: 5),
        new(name: "Coin Block", icon: "/img/item/mp5.coinblock.png", type: COIN, cost: 5),
        new(name: "Spiny", icon: "/img/item/mp5.spiny.png", type: COIN, cost: 5),
        new(name: "Paratroopa", icon: "/img/item/mp5.paratroopa.png", type: COIN, cost: 10),
        new(name: "Bullet Bill", icon: "/img/item/mp5.bulletbill.png", type: COIN, cost: 10),
        new(name: "Goomba", icon: "/img/item/mp5.goomba.png", type: COIN, cost: 5),
        new(name: "Bob-omb", icon: "/img/item/mp5.bobomb.png", type: COIN, cost: 0),
        new(name: "Koopa Bank", icon: "/img/item/mp5.koopabank.png", type: COIN, cost: 10),
        new(), //These Gaps are intentional
        new(), //These Gaps are intentional
        new(name: "Kamek", icon: "/img/item/mp5.kamek.png", type: CAPSULE, cost: 10),
        new(name: "Mr. Blizzard", icon: "/img/item/mp5.mrblizzard.png", type: CAPSULE, cost: 5),
        new(name: "Piranha Plant", icon: "/img/item/mp5.piranhaplant.png", type: COIN, cost: 5),
        new(name: "Magikoopa", icon: "/img/item/mp5.magikoopa.png", type: CAPSULE, cost: 10),
        new(name: "Ukiki", icon: "/img/item/mp5.ukiki.png", type: CAPSULE, cost: 10),
        new(name: "Lakitu", icon: "/img/item/mp5.lakitu.png", type: CAPSULE, cost: 10),
        new(), //These Gaps are intentional
        new(), //These Gaps are intentional
        new(), //These Gaps are intentional
        new(), //These Gaps are intentional
        new(name: "Tweester", icon: "/img/item/mp5.tweester.png", type: SPECIAL, cost: 15),
        new(name: "Duel", icon: "/img/item/mp5.duel.png", type: SPECIAL, cost: 10),
        new(name: "Chain Chomp", icon: "/img/item/mp5.chainchomp.png", type: SPECIAL, cost: 0),
        new(name: "Bone", icon: "/img/item/mp5.bone.png", type: SPECIAL, cost: 0),
        new(name: "Bowser", icon: "/img/item/mp5.bowser.png", type: SPECIAL, cost: 0),
        new(name: "Chance", icon: "/img/item/mp5.chance.png", type: SPECIAL, cost: 20),
        new(name: "Miracle", icon: "/img/item/mp5.miracle.png", type: SPECIAL, cost: 0)
    ];

    public static BonusStar[] BonusStars => [
        new(name: "Minigame Star", progressTitle: "Minigame Coins", icon: "/img/bonusstar/mp5.minigame.png"),
        new(name: "Coin Star", progressTitle: "Coin Total", icon: "/img/bonusstar/mp5.coin.png"),
        new(name: "Happening Star", progressTitle: "Happening Count", icon: "/img/bonusstar/mp5.happening.png")
    ];
}
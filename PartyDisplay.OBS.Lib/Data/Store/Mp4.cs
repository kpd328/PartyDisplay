using PartyDisplay.OBS.Lib.Data.Character;
using PartyDisplay.OBS.Lib.Data.Item;

namespace PartyDisplay.OBS.Lib.Data.Store;

public class Mp4 {
    public static Mp4Character[] Characters => [
        new(name: "Mario", icon: "/img/character/mp4.mario.png"),
        new(name: "Luigi", icon: "/img/character/mp4.luigi.png"),
        new(name: "Peach", icon: "/img/character/mp4.peach.png"),
        new(name: "Yoshi", icon: "/img/character/mp4.yoshi.png"),
        new(name: "Wario", icon: "/img/character/mp4.wario.png"),
        new(name: "Donkey Kong", icon: "/img/character/mp4.dk.png"),
        new(name: "Daisy", icon: "/img/character/mp4.daisy.png"),
        new(name: "Waluigi", icon: "/img/character/mp4.waluigi.png")
    ];

    public static Mp4Item?[] Items => [
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
}
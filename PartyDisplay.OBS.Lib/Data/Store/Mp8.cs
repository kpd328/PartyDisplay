using PartyDisplay.OBS.Lib.Data.Item;

namespace PartyDisplay.OBS.Lib.Data.Store;

public class Mp8 {
    public static Character[] Characters => [
        new(name: "Mario", icon: "/img/character/mp8.mario.png"),
        new(name: "Luigi", icon: "/img/character/mp8.luigi.png"),
        new(name: "Peach", icon: "/img/character/mp8.peach.png"),
        new(name: "Yoshi", icon: "/img/character/mp8.yoshi.png"),
        new(name: "Wario", icon: "/img/character/mp8.wario.png"),
        new(name: "Daisy", icon: "/img/character/mp8.daisy.png"),
        new(name: "Waluigi", icon: "/img/character/mp8.waluigi.png"),
        new(name: "Toad", icon: "/img/character/mp8.toad.png"),
        new(name: "Boo", icon: "/img/character/mp8.boo.png"),
        new(name: "Toadette", icon: "/img/character/mp8.toadette.png"),
        new(name: "Birdo", icon: "/img/character/mp8.birdo.png"),
        new(name: "Dry Bones", icon: "/img/character/mp8.drybones.png"),
        new(name: "Blooper", icon: "/img/character/mp8.blooper.png"),
        new(name: "Hammer Bro", icon: "/img/character/mp8.hammerbro.png")
    ];
    
    public static Board[] Boards => [
        new(name: "DK's Treetop Temple", logo: "/img/board/mp8.dks_treetop_temple.logo.png",
            small: "/img/board/mp8.dks_treetop_temple.small.png"),
        new(name: "Goomba's Booty Boardwalk", logo: "/img/board/mp8.goombas_booty_boardwalk.logo.png",
            small: "/img/board/mp8.goombas_booty_boardwalk.small.png"),
        new(name: "King Boo's Haunted Hideaway", logo: "/img/board/mp8.king_boos_haunted_hideaway.logo.png",
            small: "/img/board/mp8.king_boos_haunted_hideaway.small.png"),
        new(name: "Shy Guy's Perplex Express", logo: "/img/board/mp8.shy_guys_perplex_express.logo.png",
            small: "/img/board/mp8.shy_guys_perplex_express.small.png"),
        new(name: "Koopa's Tycoon Town", logo: "/img/board/mp8.koopas_tycoon_town.logo.png",
            small: "/img/board/mp8.koopas_tycoon_town.small.png"),
        new(name: "Bowser's Warped Orbit", logo: "/img/board/mp8.bowsers_warped_orbit.logo.png",
            small: "/img/board/mp8.bowsers_warped_orbit.small.png"),
    ];

    public static Mp8Candy?[] Items => [
        new(name: "Twice Candy", icon: "/img/item/mp8.twice.png", type: Mp8CandyType.RED),
        new(name: "Thrice Candy", icon: "/img/item/mp8.thrice.png", type: Mp8CandyType.RED),
        new(name: "Slowgo Candy", icon: "/img/item/mp8.slowgo.png", type: Mp8CandyType.RED),
        new(name: "Bitsize Candy", icon: "/img/item/mp8.bitsize.png", type: Mp8CandyType.YELLOW),
        new(name: "Bloway Candy", icon: "/img/item/mp8.bloway.png", type: Mp8CandyType.YELLOW),
        new(name: "Bowlo Candy", icon: "/img/item/mp8.bowlo.png", type: Mp8CandyType.YELLOW),
        new(name: "Weeglee Candy", icon: "/img/item/mp8.weeglee.png", type: Mp8CandyType.YELLOW),
        new(name: "Cashzap Candy", icon: "/img/item/mp8.cashzap.png", type: Mp8CandyType.GREEN),
        new(name: "Springo Candy", icon: "/img/item/mp8.springo.png", type: Mp8CandyType.GREEN),
        new(name: "Vampire Candy", icon: "/img/item/mp8.vampire.png", type: Mp8CandyType.GREEN),
        new(name: "Bowser Candy", icon: "/img/item/mp8.bowser.png", type: Mp8CandyType.BLUE),
        new(name: "Bullet Candy", icon: "/img/item/mp8.bullet.png", type: Mp8CandyType.BLUE),
        new(name: "Duelo Candy", icon: "/img/item/mp8.duelo.png", type: Mp8CandyType.BLUE),
        new(name: "Thwomp Candy", icon: "/img/item/mp8.thwomp.png", type: Mp8CandyType.BLUE),
    ];

    public static BonusStar[] BonusStars => [
        new(name: "Minigame Star", progressTitle: "Minigame Coins", icon: "/img/bonusstar/mp8.minigame.png"),
        new(name: "Candy Star", progressTitle: "Candies Used", icon: "/img/bonusstar/mp8.candy.png"),
        new(name: "Green Star", progressTitle: "Green Count", icon: "/img/bonusstar/mp8.green.png"),
        new(name: "Running Star", progressTitle: "Spaces Moved", icon: "/img/bonusstar/mp8.running.png"),
        new(name: "Shopping Star", progressTitle: "Coins Spent", icon: "/img/bonusstar/mp8.shopping.png"),
        new(name: "Red Star", progressTitle: "Red Count", icon: "/img/bonusstar/mp8.red.png")
    ];
    
    public static Status[] Statuses => [];
}
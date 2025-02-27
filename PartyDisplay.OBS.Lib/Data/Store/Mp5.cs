using PartyDisplay.OBS.Lib.Data.Character;

namespace PartyDisplay.OBS.Lib.Data.Store;

public class Mp5 {
    public static Mp5Character[] Characters => [
        new() { Name = "Mario", Icon = "/img/character/mp5.mario.png"},
        new() { Name = "Luigi", Icon = "/img/character/mp5.luigi.png"},
        new() { Name = "Peach", Icon = "/img/character/mp5.peach.png"},
        new() { Name = "Yoshi", Icon = "/img/character/mp5.yoshi.png"},
        new() { Name = "Wario", Icon = "/img/character/mp5.wario.png"},
        new() { Name = "Daisy", Icon = "/img/character/mp5.daisy.png"},
        new() { Name = "Waluigi", Icon = "/img/character/mp5.waluigi.png"},
        new() { Name = "Toad", Icon = "/img/character/mp5.toad.png"},
        new() { Name = "Boo", Icon = "/img/character/mp5.boo.png"},
        new() { Name = "Koopa Kid", Icon = "/img/character/mp5.koopakid.png"},
        new() { Name = "Red Koopa Kid", Icon = "/img/character/mp5.redkkid.png"},
        new() { Name = "Green Koopa Kid", Icon = "/img/character/mp5.greenkkid.png"},
        new() { Name = "Blue Koopa Kid", Icon = "/img/character/mp5.bluekkid.png"}
    ];
}
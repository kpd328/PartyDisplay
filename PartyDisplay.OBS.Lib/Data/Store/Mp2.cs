using PartyDisplay.OBS.Lib.Data.Character;

namespace PartyDisplay.OBS.Lib.Data.Store;

public sealed class Mp2 {
    public static Mp2Character[] Characters => [
        new() { Name = "Mario", Icon = "/img/character/mp2.mario.png"},
        new() { Name = "Luigi", Icon = "/img/character/mp2.luigi.png"},
        new() { Name = "Peach", Icon = "/img/character/mp2.peach.png"},
        new() { Name = "Yoshi", Icon = "/img/character/mp2.yoshi.png"},
        new() { Name = "Wario", Icon = "/img/character/mp2.wario.png"},
        new() { Name = "Donkey Kong", Icon = "/img/character/mp2.dk.png"}
    ];
}
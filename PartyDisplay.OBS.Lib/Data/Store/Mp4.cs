using PartyDisplay.OBS.Lib.Data.Character;

namespace PartyDisplay.OBS.Lib.Data.Store;

public class Mp4 {
    public static Mp4Character[] Characters => [
        new() { Name = "Mario", Icon = "/img/character/mp4.mario.png"},
        new() { Name = "Luigi", Icon = "/img/character/mp4.luigi.png"},
        new() { Name = "Peach", Icon = "/img/character/mp4.peach.png"},
        new() { Name = "Yoshi", Icon = "/img/character/mp4.yoshi.png"},
        new() { Name = "Wario", Icon = "/img/character/mp4.wario.png"},
        new() { Name = "Donkey Kong", Icon = "/img/character/mp4.dk.png"},
        new() { Name = "Daisy", Icon = "/img/character/mp4.daisy.png"},
        new() { Name = "Waluigi", Icon = "/img/character/mp4.waluigi.png"}
    ];
}
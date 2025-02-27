namespace PartyDisplay.OBS.Lib.Data.Character;

public class Mp4Character : ICharacter {
    public Mp4Character() { }

    public Mp4Character(string name, string icon) {
        Name = name;
        Icon = icon;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
}
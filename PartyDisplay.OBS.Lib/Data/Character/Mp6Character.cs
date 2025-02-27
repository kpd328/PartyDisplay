namespace PartyDisplay.OBS.Lib.Data.Character;

public class Mp6Character : ICharacter {
    public Mp6Character() { }

    public Mp6Character(string name, string icon) {
        Name = name;
        Icon = icon;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
}
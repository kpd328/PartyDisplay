namespace PartyDisplay.OBS.Lib.Data.Character;

public class Mp5Character : ICharacter {
    public Mp5Character() { }

    public Mp5Character(string name, string icon) {
        Name = name;
        Icon = icon;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
}
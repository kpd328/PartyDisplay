namespace PartyDisplay.OBS.Lib.Data.Character;

public class Mp2Character : ICharacter {
    public Mp2Character() { }

    public Mp2Character(string name, string icon) {
        Name = name;
        Icon = icon;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
}
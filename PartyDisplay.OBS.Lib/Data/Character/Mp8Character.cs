namespace PartyDisplay.OBS.Lib.Data.Character;

public class Mp8Character : ICharacter {
    public Mp8Character() { }

    public Mp8Character(string name, string icon) {
        Name = name;
        Icon = icon;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
}
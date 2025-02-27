namespace PartyDisplay.OBS.Lib.Data.Character;

public class Mp7Character : ICharacter {
    public Mp7Character() { }

    public Mp7Character(string name, string icon) {
        Name = name;
        Icon = icon;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
}
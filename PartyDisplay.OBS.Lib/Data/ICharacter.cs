namespace PartyDisplay.OBS.Lib.Data;

public class Character {
    public string Name { get; init; }
    public string Icon { get; init; }

    public Character() { }

    public Character (string name, string icon) {
        Name = name;
        Icon = icon;
    }
}
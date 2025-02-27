namespace PartyDisplay.OBS.Lib.Data.Item;

public class Mp6Orb : IItem {
    public Mp6Orb() { }

    public Mp6Orb(string name, string icon, Mp6OrbType type) {
        Name = name;
        Icon = icon;
        Type = type;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
    public Mp6OrbType Type { get; init; }
}

public enum Mp6OrbType {
    GREEN,
    YELLOW, 
    RED,
    BLUE
}
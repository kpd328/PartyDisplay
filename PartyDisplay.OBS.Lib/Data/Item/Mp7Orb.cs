namespace PartyDisplay.OBS.Lib.Data.Item;

public class Mp7Orb : IItem {
    public Mp7Orb() { }

    public Mp7Orb(string name, string icon, Mp7OrbType type) {
        Name = name;
        Icon = icon;
        Type = type;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
    public Mp7OrbType Type { get; init; }
}

public enum Mp7OrbType {
    SELF,
    THROWN,
    ROADBLOCK,
    CHARACTER
}
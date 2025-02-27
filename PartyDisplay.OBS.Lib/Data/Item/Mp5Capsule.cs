namespace PartyDisplay.OBS.Lib.Data.Item;

public class Mp5Capsule : IItem {
    public Mp5Capsule() { }

    public Mp5Capsule(string name, string icon, Mp5CapsuleType type, int cost) {
        Name = name;
        Icon = icon;
        Type = type;
        Cost = cost;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
    public Mp5CapsuleType Type { get; init; }
    public int Cost { get; init; }
}

public enum Mp5CapsuleType {
    MOVE,
    COIN,
    CAPSULE,
    SPECIAL
}
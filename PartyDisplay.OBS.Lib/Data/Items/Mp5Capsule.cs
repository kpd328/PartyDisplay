namespace PartyDisplay.OBS.Lib.Data.Items;

public class Mp5Capsule : Item {
    public Mp5CapsuleType Type { get; init; }
    public int Cost { get; init; }
    
    public Mp5Capsule(string name, string icon, Mp5CapsuleType type, int cost) {
        Name = name;
        Icon = icon;
        Type = type;
        Cost = cost;
    }

    public new Item AsItem() => new(Name, Icon);
}

public enum Mp5CapsuleType {
    Move,
    Coin,
    Capsule,
    Special
}
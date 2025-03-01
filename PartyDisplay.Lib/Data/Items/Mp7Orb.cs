namespace PartyDisplay.Lib.Data.Items;

public class Mp7Orb : Item {
    public Mp7OrbType Type { get; init; }
    
    public Mp7Orb(string name, string icon, Mp7OrbType type) {
        Name = name;
        Icon = icon;
        Type = type;
    }
    
    public new Item AsItem() => new(Name, Icon);
}

public enum Mp7OrbType {
    Self,
    Thrown,
    Roadblock,
    Character
}
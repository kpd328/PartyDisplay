namespace PartyDisplay.Lib.Data.Items;

public class Mp6Orb : Item {
    public Mp6OrbType Type { get; init; }
    
    public Mp6Orb(string name, string icon, Mp6OrbType type) {
        Name = name;
        Icon = icon;
        Type = type;
    }
    
    public new Item AsItem() => new(Name, Icon);
}

public enum Mp6OrbType {
    Green,
    Yellow, 
    Red,
    Blue
}
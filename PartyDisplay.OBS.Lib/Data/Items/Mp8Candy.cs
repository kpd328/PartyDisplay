namespace PartyDisplay.OBS.Lib.Data.Items;

public class Mp8Candy : Item {
    public Mp8CandyType Type { get; init; }
    
    public Mp8Candy(string name, string icon, Mp8CandyType type) {
        Name = name;
        Icon = icon;
        Type = type;
    }
    
    public new Item AsItem() => new(Name, Icon);
}

public enum Mp8CandyType {
    Red,
    Green,
    Yellow,
    Blue
}
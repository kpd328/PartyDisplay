namespace PartyDisplay.OBS.Lib.Data.Item;

public class Mp8Candy : IItem {
    public Mp8Candy() { }

    public Mp8Candy(string name, string icon, Mp8CandyType type) {
        Name = name;
        Icon = icon;
        Type = type;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
    public Mp8CandyType Type { get; init; }
}

public enum Mp8CandyType {
    RED,
    GREEN,
    YELLOW,
    BLUE
}
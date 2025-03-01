namespace PartyDisplay.Lib.Data;

public class Item {
    public string Name { get; init; }
    public string Icon { get; init; }

    public Item() { }

    public Item(string name, string icon) {
        Name = name;
        Icon = icon;
    }
    
    public Item AsItem() => this;
}
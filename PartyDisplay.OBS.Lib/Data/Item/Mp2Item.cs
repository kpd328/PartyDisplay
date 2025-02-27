namespace PartyDisplay.OBS.Lib.Data.Item;

public class Mp2Item : IItem {
    public Mp2Item() { }

    public Mp2Item(string name, string icon) {
        Name = name;
        Icon = icon;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
}
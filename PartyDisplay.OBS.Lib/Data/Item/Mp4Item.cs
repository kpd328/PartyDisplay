namespace PartyDisplay.OBS.Lib.Data.Item;

public class Mp4Item : IItem {
    public Mp4Item() { }

    public Mp4Item(string name, string icon) {
        Name = name;
        Icon = icon;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
}
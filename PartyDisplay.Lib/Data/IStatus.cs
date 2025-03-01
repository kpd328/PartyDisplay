namespace PartyDisplay.Lib.Data;

public class Status {
    public Status() { }

    public Status(string name, string icon) {
        Name = name;
        Icon = icon;
    }

    public string Name { get; init; }
    public string Icon { get; init; }
}
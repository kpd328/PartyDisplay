namespace PartyDisplay.Lib.Data;

public class Game {
    public Game() { }

    public Game(string name, string code, string icon, Region[] availableRegions) {
        Name = name;
        Code = code;
        Icon = icon;
        AvailableRegions = availableRegions;
    }

    public string Name { get; init; }
    public string Code { get; init; }
    public string Icon { get; init; }
    public Region Region { get; set; } = Region.NTSC;
    public Region[] AvailableRegions { get; init; }
}

public enum Region {
    NTSC,
    NTSC_J,
    PAL,
    NTSC_K
}
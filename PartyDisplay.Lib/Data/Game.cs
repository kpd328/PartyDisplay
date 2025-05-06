namespace PartyDisplay.Lib.Data;

public class Game {
    public Game() { }

    public Game(string name, string code, string icon, Region[] availableRegions) {
        Name = name;
        Code = code;
        Icon = icon;
        AvailableRegions = availableRegions;
    }
    
    public Game(string name, string id, string code, string icon, Region region, Region[] availableRegions) {
        Name = name;
        Id = id;
        Code = code;
        Icon = icon;
        Region = region;
        AvailableRegions = availableRegions;
    }

    public string Name { get; init; }
    public string Id { get; init; }
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
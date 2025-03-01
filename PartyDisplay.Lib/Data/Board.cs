namespace PartyDisplay.Lib.Data;

public class Board {
    public Board() { }

    public Board(string name, string logo, string small) {
        Name = name;
        Logo = logo;
        Small = small;
    }

    public string Name { get; init; }
    public string Logo { get; init; }
    public string Small { get; init; }
}

public enum BoardImageClass {
    Logo,
    Small
}
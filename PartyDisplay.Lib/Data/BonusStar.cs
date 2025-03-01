namespace PartyDisplay.Lib.Data;

public class BonusStar {
    public BonusStar() { }

    public BonusStar(string name, string progressTitle, string icon) {
        Name = name;
        ProgressTitle = progressTitle;
        Icon = icon;
    }

    public string Name { get; init; }
    public string ProgressTitle { get; init; }
    public short Count { get; set; }
    public string Icon { get; init; }
    public bool InLead { get; set; }

    public BonusStar Clone() {
        return new BonusStar() {
            Name = this.Name,
            ProgressTitle = this.ProgressTitle,
            Count = this.Count,
            Icon = this.Icon
        };
    }
}
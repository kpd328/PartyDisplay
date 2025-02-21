using System.Text.Json.Serialization;

namespace PartyDisplay.OBS.Lib.Data;

public class BonusStar {
    [JsonInclude]
    public string Name { get; init; }
    [JsonInclude]
    public string ProgressTitle { get; init; }
    [JsonIgnore]
    public short Count { get; set; }
    [JsonInclude]
    public string Icon { get; init; }
    [JsonIgnore]
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
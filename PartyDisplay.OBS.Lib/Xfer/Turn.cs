using System.Text.Json.Serialization;

namespace PartyDisplay.OBS.Lib.Xfer;

public record Turn {
    [JsonInclude]
    public short Count { get; set; }
    [JsonInclude]
    public short Limit { get; set; }
}
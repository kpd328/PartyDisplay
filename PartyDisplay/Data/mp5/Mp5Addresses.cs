using System.Text.Json.Serialization;

namespace PartyDisplay.Data.mp5 {
    public sealed record Mp5Addresses {
        [JsonInclude]
        public Mp5PortPlayers PortPlayers;
        [JsonInclude]
        public Mp5BoardPlayers BoardPlayers;

        public sealed record Mp5PortPlayers {
            [JsonInclude]
            public Address[] Characters;
        }

        public sealed record Mp5BoardPlayers {
            [JsonInclude]
            public string[] PlayerStart;
            [JsonInclude]
            public Mp5Template Template;

            public sealed record Mp5Template {
                [JsonInclude]
                public Address Ranking;
                [JsonInclude]
                public Address PortPlayer;
                [JsonInclude]
                public Mp5Coins Coins;
                [JsonInclude]
                public Mp5Stars Stars;
                [JsonInclude]
                public Mp5Spaces Spaces;
                [JsonInclude]
                public Address DiceRoll;
                [JsonInclude]
                public Address[] Capsules;

                public sealed record Mp5Coins {
                    [JsonInclude]
                    public Address Current;
                    [JsonInclude]
                    public Address Minigame;
                    [JsonInclude]
                    public Address Max;
                    [JsonInclude]
                    public Address EndTurnCount;
                }

                public sealed record Mp5Stars {
                    [JsonInclude]
                    public Address Current;
                    [JsonInclude]
                    public Address Max;
                    [JsonInclude]
                    public Address EndTurnCount;
                }

                public sealed record Mp5Spaces {
                    [JsonInclude]
                    public Address Blue;
                    [JsonInclude]
                    public Address Red;
                    [JsonInclude]
                    public Address Capsule;
                    [JsonInclude]
                    public Address Happening;
                    [JsonInclude]
                    public Address Bowser;
                    [JsonInclude]
                    public Address DK;
                }
            }
        }
    }

    public sealed record Address {
        [JsonInclude]
        public string Type;
        [JsonInclude]
        public string? Index;
        [JsonInclude]
        public string? Subtype;
        [JsonInclude]
        public uint? Size;
        [JsonInclude]
        public uint? Offset;
    }
}

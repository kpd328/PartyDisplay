using System.Text.Json.Serialization;

namespace PartyDisplay.Data.mp8 {
    internal class Mp8Addresses {
        [JsonInclude]
        public string[] Offsets;
        [JsonInclude]
        public Mp6Template Template;

        public sealed record Mp6Template {
            [JsonInclude]
            public Address Character;
            [JsonInclude]
            public Address Ranking;
            [JsonInclude]
            public Address Port;
            [JsonInclude]
            public Mp8Coins Coins;
            [JsonInclude]
            public Mp8Stars Stars;
            [JsonInclude]
            public Mp8Spaces Spaces;
            [JsonInclude]
            public Address CandyUsed;
            [JsonInclude]
            public Address DiceRoll;
            [JsonInclude]
            public Address LandedSpace;
            [JsonInclude]
            public Address SpacesMoved;
            [JsonInclude]
            public Address[] Items;

            public sealed record Mp8Coins {
                [JsonInclude]
                public Address Current;
                [JsonInclude]
                public Address Minigame;
                [JsonInclude]
                public Address Max;
                [JsonInclude]
                public Address Spent;
            }

            public sealed record Mp8Stars {
                [JsonInclude]
                public Address Current;
                [JsonInclude]
                public Address Max;
            }

            public sealed record Mp8Spaces {
                [JsonInclude]
                public Address Blue;
                [JsonInclude]
                public Address Red;
                [JsonInclude]
                public Address Happening;
                [JsonInclude]
                public Address Lucky;
                [JsonInclude]
                public Address DK;
                [JsonInclude]
                public Address Bowser;
            }
        }
        public sealed record Address {
            [JsonInclude]
            public string Type;
            [JsonInclude]
            public uint Offset;
        }
    }
}

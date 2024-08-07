using System.Text.Json.Serialization;

namespace PartyDisplay.Data.mp2 {
    public sealed record Mp2Addresses {
        [JsonInclude]
        public string[] Offsets;
        [JsonInclude]
        public Mp6Template Template;

        public sealed record Mp6Template {
            [JsonInclude]
            public Address Port;
            [JsonInclude]
            public Address Character;
            [JsonInclude]
            public Address Ranking;
            [JsonInclude]
            public Mp2Coins Coins;
            [JsonInclude]
            public Address Stars;
            [JsonInclude]
            public Mp2Spaces Spaces;
            [JsonInclude]
            public Address LandedSpace;
            [JsonInclude]
            public Address Item;

            public sealed record Mp2Coins {
                [JsonInclude]
                public Address Current;
                [JsonInclude]
                public Address Minigame;
                [JsonInclude]
                public Address Max;
                [JsonInclude]
                public Address Spent;
            }

            public sealed record Mp2Spaces {
                [JsonInclude]
                public Address Happening;
                [JsonInclude]
                public Address Red;
                [JsonInclude]
                public Address Blue;
                [JsonInclude]
                public Address Chance;
                [JsonInclude]
                public Address Bowser;
                [JsonInclude]
                public Address Battle;
                [JsonInclude]
                public Address Item;
                [JsonInclude]
                public Address Bank;
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

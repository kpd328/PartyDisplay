using System.Text.Json.Serialization;

namespace PartyDisplay.Data.mp6 {
    public sealed record Mp6Addresses {
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
            public Mp6Coins Coins;
            [JsonInclude]
            public Mp6Stars Stars;
            [JsonInclude]
            public Mp6Spaces Spaces;
            [JsonInclude]
            public Address OrbsUsed;
            [JsonInclude]
            public Address DiceRoll;
            [JsonInclude]
            public Address LandedSpace;
            [JsonInclude]
            public Address[] Items;

            public sealed record Mp6Coins {
                [JsonInclude]
                public Address Current;
                [JsonInclude]
                public Address Minigame;
                [JsonInclude]
                public Address Max;
            }

            public sealed record Mp6Stars {
                [JsonInclude]
                public Address Current;
                [JsonInclude]
                public Address Max;
            }

            public sealed record Mp6Spaces {
                [JsonInclude]
                public Address Blue;
                [JsonInclude]
                public Address Red;
                [JsonInclude]
                public Address Happening;
                [JsonInclude]
                public Address Fortune;
                [JsonInclude]
                public Address Bowser;
                [JsonInclude]
                public Address Battle;
                [JsonInclude]
                public Address Mushroom;
                [JsonInclude]
                public Address Warp;
            }
        }
    }

    public sealed record Address {
        [JsonInclude]
        public string Type;
        [JsonInclude]
        public uint Offset;
    }
}

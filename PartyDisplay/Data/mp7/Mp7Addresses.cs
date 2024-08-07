using System.Text.Json.Serialization;

namespace PartyDisplay.Data.mp7 {
    public sealed record Mp7Addresses {
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
            public Mp7Coins Coins;
            [JsonInclude]
            public Mp7Stars Stars;
            [JsonInclude]
            public Mp7Spaces Spaces;
            [JsonInclude]
            public Address OrbsUsed;
            [JsonInclude]
            public Address DiceRoll;
            [JsonInclude]
            public Address LandedSpace;
            [JsonInclude]
            public Address SpacesMoved;
            [JsonInclude]
            public Address[] Items;

            public sealed record Mp7Coins {
                [JsonInclude]
                public Address Current;
                [JsonInclude]
                public Address Minigame;
                [JsonInclude]
                public Address Max;
                [JsonInclude]
                public Address Spent;
            }

            public sealed record Mp7Stars {
                [JsonInclude]
                public Address Current;
                [JsonInclude]
                public Address Max;
            }

            public sealed record Mp7Spaces {
                [JsonInclude]
                public Address Blue;
                [JsonInclude]
                public Address Red;
                [JsonInclude]
                public Address Character;
                [JsonInclude]
                public Address Happening;
                [JsonInclude]
                public Address Bowser;
                [JsonInclude]
                public Address Mic;
                [JsonInclude]
                public Address Duel;
                [JsonInclude]
                public Address DK;
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

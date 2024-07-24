using System.Text.Json.Serialization;

namespace PartyDisplay.Data.mp4 {
    public sealed record Mp4Addresses {
        [JsonInclude]
        public string[] Offsets;
        [JsonInclude]
        public Mp4Template Template;

        public sealed record Mp4Template {
            [JsonInclude]
            public Address Character;
            [JsonInclude]
            public Address Ranking;
            [JsonInclude]
            public Address Port;
            [JsonInclude]
            public Mp4Coins Coins; 
            [JsonInclude]
            public Mp4Stars Stars;
            [JsonInclude]
            public Mp4Spaces Spaces;
            [JsonInclude]
            public Address DiceRoll;
            [JsonInclude]
            public Address LandedSpace;
            [JsonInclude]
            public Address[] Items;

            public sealed record Mp4Coins {
                [JsonInclude]
                public Address Current;
                [JsonInclude]
                public Address Minigame;
                [JsonInclude]
                public Address Max;
            }

            public sealed record Mp4Stars {
                [JsonInclude]
                public Address Current;
                [JsonInclude]
                public Address Max;
            }

            public sealed record Mp4Spaces {
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

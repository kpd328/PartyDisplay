using Avalonia.Platform;
using PartyDisplay.Data.mp5;
using System.Text.Json;
using System;

namespace PartyDisplay.Data.mp2 {
    public sealed class Mp2Loader:IContentData<Mp2Character, Mp2Item> {
        private static readonly Lazy<Mp2Loader> _instance = new(() => new());
        public static Mp2Loader Data => _instance.Value;

        public Mp2Character[] Characters { get; private set; }
        public Mp2Item[] Items { get; private set; }
        public BonusStar[] BonusStars { get; private set; }

        private Mp2Loader() {
            Characters = JsonSerializer.Deserialize<Mp2Character[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp2/characters.json"))) ?? [];
            Items = JsonSerializer.Deserialize<Mp2Item[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp2/items.json"))) ?? [];
            BonusStars = JsonSerializer.Deserialize<BonusStar[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp2/bonusstars.json"))) ?? [];
        }
    }
}

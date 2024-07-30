using Avalonia.Platform;
using System.Text.Json;
using System;
using System.Linq;

namespace PartyDisplay.Data.mp8 {
    internal class Mp8Loader:IContentData<Mp8Character, Mp8Candy> {
        private static readonly Lazy<Mp8Loader> _instance = new(() => new());
        public static Mp8Loader Data => _instance.Value;

        public Mp8Character[] Characters { get; private set; }
        public Mp8Candy[] Items { get; private set; }
        public BonusStar[] BonusStars { get; private set; }

        public BonusStar[] GetCopyOfBonusStars() => BonusStars.Select(a => a.Clone()).ToArray();

        private Mp8Loader() {
            Characters = JsonSerializer.Deserialize<Mp8Character[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp8/characters.json"))) ?? [];
            Items = JsonSerializer.Deserialize<Mp8Candy[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp8/candies.json"))) ?? [];
            BonusStars = JsonSerializer.Deserialize<BonusStar[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp8/bonusstars.json"))) ?? [];
        }
    }
}

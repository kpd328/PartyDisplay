using Avalonia.Platform;
using System;
using System.Linq;
using System.Text.Json;

namespace PartyDisplay.Data.mp5 {
    public sealed class Mp5Loader:IContentData<Mp5Character, Mp5Capsule> {
        private static readonly Lazy<Mp5Loader> _instance = new(() => new());
        public static Mp5Loader Data => _instance.Value;

        public Mp5Character[] Characters { get; private set; }
        public Mp5Capsule[] Items { get; private set; }
        public BonusStar[] BonusStars { get; private set; }

        public BonusStar[] GetCopyOfBonusStars() => BonusStars.Select(a => a.Clone()).ToArray();

        private Mp5Loader() {
            Characters = JsonSerializer.Deserialize<Mp5Character[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp5/characters.json"))) ?? [];
            Items = JsonSerializer.Deserialize<Mp5Capsule[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp5/capsules.json"))) ?? [];
            BonusStars = JsonSerializer.Deserialize<BonusStar[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp5/bonusstars.json"))) ?? [];
        }
    }
}

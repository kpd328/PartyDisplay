using Avalonia.Platform;
using System;
using System.Linq;
using System.Text.Json;

namespace PartyDisplay.Data.mp6 {
    public sealed class Mp6Loader:IContentData<Mp6Character, Mp6Orb> {
        private static readonly Lazy<Mp6Loader> _instance = new(() => new());
        public static Mp6Loader Data => _instance.Value;

        public Mp6Character[] Characters { get; private set; }
        public Mp6Orb[] Items { get; private set; }
        public BonusStar[] BonusStars { get; private set; }

        public BonusStar[] GetCopyOfBonusStars() => BonusStars.Select(a => a.Clone()).ToArray();

        private Mp6Loader() {
            Characters = JsonSerializer.Deserialize<Mp6Character[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp6/characters.json"))) ?? [];
            Items = JsonSerializer.Deserialize<Mp6Orb[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp6/orbs.json"))) ?? [];
            BonusStars = JsonSerializer.Deserialize<BonusStar[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp6/bonusstars.json"))) ?? [];
        }
    }
}

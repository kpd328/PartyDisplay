using Avalonia.Platform;
using System;
using System.Linq;
using System.Text.Json;

namespace PartyDisplay.Data.mp7 {
    public sealed class Mp7Loader:IContentData<Mp7Character, Mp7Orb> {
        private static readonly Lazy<Mp7Loader> _instance = new(() => new());
        public static Mp7Loader Data => _instance.Value;

        public Mp7Character[] Characters { get; private set; }
        public Mp7Orb[] Items { get; private set; }
        public BonusStar[] BonusStars { get; private set; }

        public BonusStar[] GetCopyOfBonusStars() => BonusStars.Select(a => a.Clone()).ToArray();

        private Mp7Loader() {
            Characters = JsonSerializer.Deserialize<Mp7Character[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp7/characters.json"))) ?? [];
            Items = JsonSerializer.Deserialize<Mp7Orb[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp7/orbs.json"))) ?? [];
            BonusStars = JsonSerializer.Deserialize<BonusStar[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp7/bonusstars.json"))) ?? [];
        }
    }
}

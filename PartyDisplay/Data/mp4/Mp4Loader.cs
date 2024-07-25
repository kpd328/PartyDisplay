using Avalonia.Platform;
using System;
using System.Linq;
using System.Text.Json;

namespace PartyDisplay.Data.mp4 {
    public sealed class Mp4Loader:IContentData<Mp4Character, Mp4Item> {
        private static readonly Lazy<Mp4Loader> _instance = new(() => new());
        public static Mp4Loader Data => _instance.Value;

        public Mp4Character[] Characters { get; }
        public Mp4Item[] Items { get; }
        public BonusStar[] BonusStars { get; }

        public BonusStar[] GetCopyOfBonusStars() => BonusStars.Select(a => a.Clone()).ToArray();

        private Mp4Loader() {
            Characters = JsonSerializer.Deserialize<Mp4Character[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp4/characters.json"))) ?? [];
            Items = JsonSerializer.Deserialize<Mp4Item[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp4/items.json"))) ?? [];
            BonusStars = JsonSerializer.Deserialize<BonusStar[]>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp4/bonusstars.json"))) ?? [];
        }
    }
}

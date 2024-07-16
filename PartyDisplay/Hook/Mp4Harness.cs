using Avalonia.Platform;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp4Harness:IGameHarness {
        private static readonly Lazy<Mp4Harness> _instance = new(() => new());
        public static Mp4Harness Connection => _instance.Value;

        private dynamic? Addresses { get; set; }

        private Mp4Harness() {
            Addresses = JsonSerializer.Deserialize<dynamic>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/Mp4/addresses.json")));
        }
    }
}

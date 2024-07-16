using Avalonia.Platform;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp6Harness:IGameHarness {
        private static readonly Lazy<Mp6Harness> _instance = new(() => new());
        public static Mp6Harness Connection => _instance.Value;

        private dynamic? Addresses { get; set; }

        private Mp6Harness() {
            Addresses = JsonSerializer.Deserialize<dynamic>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/Mp6/addresses.json")));
        }
    }
}

using Avalonia.Platform;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp2Harness:IGameHarness {
        private static readonly Lazy<Mp2Harness> _instance = new(() => new());
        public static Mp2Harness Connection => _instance.Value;

        private dynamic? Addresses { get; set; }

        private Mp2Harness() {
            Addresses = JsonSerializer.Deserialize<dynamic>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/Mp2/addresses.json")));
        }
    }
}

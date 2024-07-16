using Avalonia.Platform;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp8Harness:IGameHarness {
        private static readonly Lazy<Mp8Harness> _instance = new(() => new());
        public static Mp8Harness Connection => _instance.Value;

        private dynamic? Addresses { get; set; }

        private Mp8Harness() {
            Addresses = JsonSerializer.Deserialize<dynamic>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/Mp8/addresses.json")));
        }
    }
}

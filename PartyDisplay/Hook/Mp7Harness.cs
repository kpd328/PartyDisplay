using Avalonia.Platform;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp7Harness:IGameHarness {
        private static readonly Lazy<Mp7Harness> _instance = new(() => new());
        public static Mp7Harness Connection => _instance.Value;

        private dynamic? Addresses { get; set; }

        private Mp7Harness() {
            Addresses = JsonSerializer.Deserialize<dynamic>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/Mp7/addresses.json")));
        }
    }
}

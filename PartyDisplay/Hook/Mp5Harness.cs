using Avalonia.Platform;
using PartyDisplay.Data.mp5;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp5Harness : IGameHarness {
        private static readonly Lazy<Mp5Harness> _instance = new(() => new());
        public static Mp5Harness Connection => _instance.Value;

        private Mp5Addresses? Addresses { get; set; }

        public Mp5Character GetCharacterForPort(byte port) {
            if(port > 3) {
                throw new ArgumentOutOfRangeException(nameof(port), "Bad Port Value. Range [0-3].");
            }
            uint i = uint.Parse(Addresses.PortPlayers.Characters[port].Index, System.Globalization.NumberStyles.HexNumber);
            var index = DolphinHook.ByteLookup(i) - 23;
            return Mp5Loader.Data.Characters[index];
        }

        private Mp5Harness() {
            Addresses = JsonSerializer.Deserialize<Mp5Addresses>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp5/addresses.json")));
        }
    }
}

using Avalonia.Platform;
using PartyDisplay.Data;
using PartyDisplay.Data.mp6;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp6Harness:IGameHarness<Mp6Character, Mp6Orb> {
        private static readonly Lazy<Mp6Harness> _instance = new(() => new());
        public static Mp6Harness Connection => _instance.Value;

        private dynamic? Addresses { get; set; }

        private Mp6Harness() {
            Addresses = JsonSerializer.Deserialize<dynamic>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/Mp6/addresses.json")));
        }

        public Mp6Character GetCharacterForBoard(byte player) {
            throw new NotImplementedException();
        }

        public Mp6Character GetCharacterForPort(byte port) {
            throw new NotImplementedException();
        }

        public short GetCoins(byte player) {
            throw new NotImplementedException();
        }

        public Mp6Orb? GetItem(byte player, byte slot) {
            throw new NotImplementedException();
        }

        public Ranking GetRanking(byte player) {
            throw new NotImplementedException();
        }

        public short GetStars(byte player) {
            throw new NotImplementedException();
        }

        public SpaceColor? GetLandedColor(byte player) {
            throw new NotImplementedException();
        }

        public byte GetPortForPlayer(byte player) {
            throw new NotImplementedException();
        }
    }
}

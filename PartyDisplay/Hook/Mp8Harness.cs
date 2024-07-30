using Avalonia.Platform;
using PartyDisplay.Data;
using PartyDisplay.Data.mp8;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp8Harness:IGameHarness<Mp8Character, Mp8Candy> {
        private static readonly Lazy<Mp8Harness> _instance = new(() => new());
        public static Mp8Harness Connection => _instance.Value;

        private dynamic? Addresses { get; set; }

        private Mp8Harness() {
            Addresses = JsonSerializer.Deserialize<dynamic>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/Mp8/addresses.json")));
        }

        public Mp8Character GetCharacterForBoard(byte player) {
            throw new NotImplementedException();
        }

        public Mp8Character GetCharacterForPort(byte port) {
            throw new NotImplementedException();
        }

        public short GetCoins(byte player) {
            throw new NotImplementedException();
        }

        public Mp8Candy? GetItem(byte player, byte slot) {
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

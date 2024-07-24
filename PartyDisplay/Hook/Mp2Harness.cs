using Avalonia.Platform;
using PartyDisplay.Data;
using PartyDisplay.Data.mp2;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp2Harness:IGameHarness<Mp2Character, Mp2Item> {
        private static readonly Lazy<Mp2Harness> _instance = new(() => new());
        public static Mp2Harness Connection => _instance.Value;

        private dynamic? Addresses { get; set; }

        private Mp2Harness() {
            Addresses = JsonSerializer.Deserialize<dynamic>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/Mp2/addresses.json")));
        }

        public Mp2Character GetCharacterForBoard(byte player) {
            throw new NotImplementedException();
        }

        public Mp2Character GetCharacterForPort(byte port) {
            throw new NotImplementedException();
        }

        public short GetCoins(byte player) {
            throw new NotImplementedException();
        }

        public Mp2Item? GetItem(byte player, byte slot) {
            throw new NotImplementedException();
        }

        public Ranking GetRanking(byte player) {
            throw new NotImplementedException();
        }

        public short GetStars(byte player) {
            throw new NotImplementedException();
        }

        public byte GetPortForPlayer(byte player) {
            throw new NotImplementedException();
        }
    }
}

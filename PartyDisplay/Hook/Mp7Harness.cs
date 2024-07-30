using Avalonia.Platform;
using PartyDisplay.Data;
using PartyDisplay.Data.mp7;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp7Harness:IGameHarness<Mp7Character, Mp7Orb> {
        private static readonly Lazy<Mp7Harness> _instance = new(() => new());
        public static Mp7Harness Connection => _instance.Value;

        private dynamic? Addresses { get; set; }

        private Mp7Harness() {
            Addresses = JsonSerializer.Deserialize<dynamic>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/Mp7/addresses.json")));
        }

        public Mp7Character GetCharacterForBoard(byte player) {
            throw new NotImplementedException();
        }

        public Mp7Character GetCharacterForPort(byte port) {
            throw new NotImplementedException();
        }

        public short GetCoins(byte player) {
            throw new NotImplementedException();
        }

        public Mp7Orb? GetItem(byte player, byte slot) {
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

using Avalonia.Platform;
using PartyDisplay.Data;
using PartyDisplay.Data.mp4;
using System;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp4Harness:IGameHarness<Mp4Character, Mp4Item> {
        private static readonly Lazy<Mp4Harness> _instance = new(() => new());
        public static Mp4Harness Connection => _instance.Value;

        private dynamic? Addresses { get; set; }

        public Mp4Character GetCharacterForPort(byte port) {
            throw new NotImplementedException();
        }

        public Mp4Character GetCharacterForBoard(byte player) {
            throw new NotImplementedException();
        }

        public Ranking GetRanking(byte player) {
            throw new NotImplementedException();
        }

        public short GetCoins(byte player) {
            throw new NotImplementedException();
        }

        public short GetMaxCoins(byte player) {
            throw new NotImplementedException();
        }

        public short GetStars(byte player) {
            throw new NotImplementedException();
        }

        public byte GetHappening(byte player) {
            throw new NotImplementedException();
        }

        public Mp4Item? GetItem(byte player, byte slot) {
            throw new NotImplementedException();
        }

        public byte GetPortForPlayer(byte player) {
            throw new NotImplementedException();
        }

        private Mp4Harness() {
            Addresses = JsonSerializer.Deserialize<dynamic>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/Mp4/addresses.json")));
        }
    }
}

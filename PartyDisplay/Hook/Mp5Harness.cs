using Avalonia.Platform;
using PartyDisplay.Data;
using PartyDisplay.Data.mp5;
using System;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp5Harness : IGameHarness<Mp5Character, Mp5Capsule> {
        private static readonly Lazy<Mp5Harness> _instance = new(() => new());
        public static Mp5Harness Connection => _instance.Value;

        private Mp5Addresses? Addresses { get; set; }

        public Mp5Character GetCharacterForPort(byte port) {
            if(port > 3) {
                throw new ArgumentOutOfRangeException(nameof(port), "Bad Port Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.PortPlayers.Characters[port].Index, NumberStyles.HexNumber);
            var index = DolphinHook.ByteLookup(region) - 23;
            return Mp5Loader.Data.Characters[index];
        }

        public Mp5Character GetCharacterForBoard(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.BoardPlayers.PlayerStart[player], NumberStyles.HexNumber);
            byte index = (byte)DolphinHook.ByteLookup(region);
            int i = (index & 0x1F) >> 1;
            return Mp5Loader.Data.Characters[i];
        }

        public Ranking GetRanking(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.BoardPlayers.PlayerStart[player], NumberStyles.HexNumber);
            uint offset = Addresses.BoardPlayers.Template.Ranking.Offset.Value;
            byte rank = (byte)DolphinHook.ByteLookup(region + offset);
            return ((rank & 0x60) >> 5) switch { 
                //This isolates and bit shifts the relevant bits (6 and 7) at the address
                0 => Ranking.First,
                1 => Ranking.Second,
                2 => Ranking.Third,
                3 => Ranking.Fourth,
                _ => throw new IndexOutOfRangeException("Bad Memory")
            };
        }

        public short GetCoins(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.BoardPlayers.PlayerStart[player], NumberStyles.HexNumber);
            uint offset = Addresses.BoardPlayers.Template.Coins.Current.Offset.Value;
            return DolphinHook.HwordLookup(region + offset);
        }

        public short GetMinigameCoins(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.BoardPlayers.PlayerStart[player], NumberStyles.HexNumber);
            uint offset = Addresses.BoardPlayers.Template.Coins.Minigame.Offset.Value;
            return DolphinHook.HwordLookup(region + offset);
        }

        public short GetMaxCoins(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.BoardPlayers.PlayerStart[player], NumberStyles.HexNumber);
            uint offset = Addresses.BoardPlayers.Template.Coins.Max.Offset.Value;
            return DolphinHook.HwordLookup(region + offset);
        }

        public short GetStars(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.BoardPlayers.PlayerStart[player], NumberStyles.HexNumber);
            uint offset = Addresses.BoardPlayers.Template.Stars.Current.Offset.Value;
            return DolphinHook.HwordLookup(region + offset);
        }

        public byte GetHappening(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.BoardPlayers.PlayerStart[player], NumberStyles.HexNumber);
            uint offset = Addresses.BoardPlayers.Template.Spaces.Happening.Offset.Value;
            return (byte)DolphinHook.ByteLookup(region + offset);
        }

        public Mp5Capsule? GetItem(byte player, byte slot) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.BoardPlayers.PlayerStart[player], NumberStyles.HexNumber);
            uint offset = Addresses.BoardPlayers.Template.Capsules[slot].Offset.Value;
            sbyte capsule = DolphinHook.ByteLookup(region + offset);
            if(capsule == -1) {
                return null;
            } else {
                return Mp5Loader.Data.Items.Where(a => a.Index == capsule).First();
            }
        }

        public SpaceColor? GetLandedColor(byte player) {
            throw new NotImplementedException();
        }

        public byte GetPortForPlayer(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3]");
            }
            uint region = uint.Parse(Addresses.BoardPlayers.PlayerStart[player], NumberStyles.HexNumber);
            uint offset = Addresses.BoardPlayers.Template.PortPlayer.Offset.Value;
            return (byte)DolphinHook.ByteLookup(region + offset);
        }

        private Mp5Harness() {
            Addresses = JsonSerializer.Deserialize<Mp5Addresses>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp5/addresses.json")));
        }
    }
}

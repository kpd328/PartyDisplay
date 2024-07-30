using Avalonia.Platform;
using PartyDisplay.Data;
using PartyDisplay.Data.mp4;
using System;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp4Harness:IGameHarness<Mp4Character, Mp4Item> {
        private static readonly Lazy<Mp4Harness> _instance = new(() => new());
        public static Mp4Harness Connection => _instance.Value;

        private Mp4Addresses? Addresses { get; set; }

        public Mp4Character GetCharacterForPort(byte port) => GetCharacterForBoard(port); //There's no point in this here, might get rid of later.

        public Mp4Character GetCharacterForBoard(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            byte index = (byte)DolphinHook.ByteLookup(region);
            int i = (index & 0xE) >> 1;
            return Mp4Loader.Data.Characters[i];
        }

        public Ranking GetRanking(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Ranking.Offset;
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
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Coins.Current.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public short GetMinigameCoins(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Coins.Minigame.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public short GetMaxCoins(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Coins.Max.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public short GetStars(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Stars.Current.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public byte GetHappening(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Spaces.Happening.Offset;
            return (byte)DolphinHook.ByteLookup(region + offset);
        }

        public Mp4Item? GetItem(byte player, byte slot) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Items[slot].Offset;
            sbyte item = DolphinHook.ByteLookup(region + offset);
            if(item == -1) {
                return null;
            } else {
                return Mp4Loader.Data.Items.Where(a => a.Index == item).First();
            }
        }

        public byte GetPortForPlayer(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Port.Offset;
            return (byte)DolphinHook.ByteLookup(region + offset);
        }

        public SpaceColor? GetLandedColor(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.LandedSpace.Offset;
            return ((DolphinHook.ByteLookup(region + offset) & 0xC0) >> 6) switch {
                1 => SpaceColor.Blue,
                2 => SpaceColor.Red,
                3 => SpaceColor.Green,
                _ => null
            };
        }

        private Mp4Harness() {
            Addresses = JsonSerializer.Deserialize<Mp4Addresses>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp4/addresses.json")));
        }
    }
}

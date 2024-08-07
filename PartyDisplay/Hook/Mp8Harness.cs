using Avalonia.Platform;
using PartyDisplay.Data;
using PartyDisplay.Data.mp7;
using PartyDisplay.Data.mp8;
using System;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp8Harness:IGameHarness<Mp8Character, Mp8Candy> {
        private static readonly Lazy<Mp8Harness> _instance = new(() => new());
        public static Mp8Harness Connection => _instance.Value;

        private Mp8Addresses? Addresses { get; set; }

        private Mp8Harness() {
            Addresses = JsonSerializer.Deserialize<Mp8Addresses>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp8/addresses.json")));
        }

        public Mp8Character GetCharacterForBoard(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Character.Offset;
            byte index = (byte)DolphinHook.ByteLookup(region + offset);
            int i = (index & 0x1E) >> 1;
            return Mp8Loader.Data.Characters[i];
        }

        public Mp8Character GetCharacterForPort(byte port) => GetCharacterForBoard(port); //There's no point in this here, might get rid of later.

        public short GetCoins(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Coins.Current.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public Mp8Candy? GetItem(byte player, byte slot) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            if(slot > 2) {
                throw new ArgumentOutOfRangeException(nameof(slot), "Bad Item Slot. Range [0-2]");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Items[slot].Offset;
            sbyte item = DolphinHook.ByteLookup(region + offset);
            if(item == -1) {
                return null;
            } else {
                return Mp8Loader.Data.Items.Where(a => a.Index == item).First();
            }
        }

        public Ranking GetRanking(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Ranking.Offset;
            byte rank = (byte)DolphinHook.ByteLookup(region + offset);
            return ((rank & 0x0C) >> 2) switch {
                //This isolates and bit shifts the relevant bits (6 and 7) at the address
                0 => Ranking.First,
                1 => Ranking.Second,
                2 => Ranking.Third,
                3 => Ranking.Fourth,
                _ => throw new IndexOutOfRangeException("Bad Memory")
            };
        }

        public short GetStars(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Stars.Current.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public SpaceColor? GetLandedColor(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.LandedSpace.Offset;
            return ((DolphinHook.ByteLookup(region + offset) & 0xE0) >> 5) switch {
                1 => SpaceColor.Blue,
                2 => SpaceColor.Red,
                3 => SpaceColor.Green,
                4 => SpaceColor.Pink,
                _ => null
            };
        }

        public byte GetPortForPlayer(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Port.Offset;
            return (byte)DolphinHook.ByteLookup(region + offset);
        }

        public short GetMinigameCoins(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Coins.Minigame.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public short GetCandyUsed(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.CandyUsed.Offset;
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

        public short GetSpacesMoved(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.SpacesMoved.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public short GetCandyBought(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Coins.Spent.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public byte GetRed(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Spaces.Red.Offset;
            return (byte)DolphinHook.ByteLookup(region + offset);
        }
    }
}

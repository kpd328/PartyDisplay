using Avalonia.Platform;
using PartyDisplay.Data;
using PartyDisplay.Data.mp2;
using PartyDisplay.Data.mp8;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace PartyDisplay.Hook {
    public sealed class Mp2Harness:IGameHarness<Mp2Character, Mp2Item> {
        private static readonly Lazy<Mp2Harness> _instance = new(() => new());
        public static Mp2Harness Connection => _instance.Value;

        private Mp2Addresses? Addresses { get; set; }

        private Mp2Harness() {
            Addresses = JsonSerializer.Deserialize<Mp2Addresses>(AssetLoader.Open(new Uri("avares://PartyDisplay/Load/mp2/addresses.json")));
        }

        public Mp2Character GetCharacterForBoard(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Character.Offset;
            byte index = (byte)DolphinHook.ByteLookup(region + offset);
            return Mp2Loader.Data.Characters[index];
        }

        public Mp2Character GetCharacterForPort(byte port) => GetCharacterForBoard(port); //There's no point in this here, might get rid of later.

        public short GetCoins(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Coins.Current.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public Mp2Item? GetItem(byte player, byte slot = 0) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            Debug.WriteIf(slot != 0, "slot is not used in Mp2, and will be ignored.");
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Item.Offset;
            sbyte item = DolphinHook.ByteLookup(region + offset);
            if(item == -1) {
                return null;
            } else {
                return Mp2Loader.Data.Items[item];
            }
        }

        public Ranking GetRanking(byte player) {
            throw new NotImplementedException(); //TODO: Don't actually have the address and schema for this.
        }

        public short GetStars(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Stars.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }

        public SpaceColor? GetLandedColor(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Position Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.LandedSpace.Offset;
            return DolphinHook.ByteLookup(region + offset) switch {
                1 => SpaceColor.Blue,
                2 => SpaceColor.Red,
                4 => SpaceColor.Green,
                _ => null
                //It might be better to do 0 => null, and _ => SpaceColor.Green, don't know if 4 is the only green, need more RAM snooping.
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

        public byte GetHappening(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Spaces.Happening.Offset;
            return (byte)DolphinHook.ByteLookup(region + offset);
        }

        public short GetMaxCoins(byte player) {
            if(player > 3) {
                throw new ArgumentOutOfRangeException(nameof(player), "Bad Player Value. Range [0-3].");
            }
            uint region = uint.Parse(Addresses.Offsets[player], NumberStyles.HexNumber);
            uint offset = Addresses.Template.Coins.Max.Offset;
            return DolphinHook.HwordLookup(region + offset);
        }
    }
}

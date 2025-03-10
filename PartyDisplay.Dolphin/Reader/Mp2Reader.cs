using PartyDisplay.Lib.Data;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Dolphin.Reader;

public class Mp2Reader : IReader<Item> {
    private static readonly Lazy<Mp2Reader> _lazy = new(() => new Mp2Reader());
    public static Mp2Reader Connection => _lazy.Value;

    private const long P1 = 0x80C2_95A0;
    private const long P2 = 0x80C2_95D4;
    private const long P3 = 0x80C2_9608;
    private const long P4 = 0x80C2_963C;

    private static readonly long[] _playerOffset = [P1, P2, P3, P4];

    private const long BPortOffset = 0;
    private const long BCharacterOffset = 4;
    private const long BRankingOffset = 0; //TODO: Don't actually have the address for this.
    private const long HCoinCountOffset = 5;
    private const long HCoinMinigameOffset = 37;
    private const long HCoinMaxOffset = 39;
    private const long HStarsOffset = 11;
    private const long BSpaceHappeningOffset = 41;
    private const long BSpaceRedOffset = 42;
    private const long BSpaceBlueOffset = 43;
    private const long BSpaceChanceOffset = 44;
    private const long BSpaceBowserOffset = 45;
    private const long BSpaceBattleOffset = 46;
    private const long BSpaceItemOffset = 47;
    private const long BSpaceBankOffset = 48;
    private const long BLandedSpaceOffset = 24;
    private const long BItemOffset = 22;


    private Mp2Reader() { }

    public byte GetPortForPlayer(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BPortOffset);
    }

    public byte GetCurrentTurn() {
        throw new NotImplementedException(); //TODO: Don't actually have the address and schema for this.
    }

    public byte GetTurnLimit() {
        throw new NotImplementedException(); //TODO: Don't actually have the address and schema for this.
    }

    public Character GetCharacter(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        byte index = Memory.Access.SearchByte(_playerOffset[player] + BCharacterOffset);
        return Mp2.Characters[index];
    }

    public short GetCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinCountOffset);
    }

    public Item? GetItem(byte player, byte slot = 0) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        ArgumentOutOfRangeException.ThrowIfNotEqual(slot, 0);
        sbyte index = Memory.Access.SearchSByte(_playerOffset[player] + BItemOffset);
        return index != -1 ? Mp2.Items[index] : null;
    }

    public Ranking GetRanking(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        throw new NotImplementedException(); //TODO: Don't actually have the address and schema for this.
    }

    public short GetStars(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HStarsOffset);
    }

    public SpaceColor? GetLandedColor(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BLandedSpaceOffset) switch {
            1 => SpaceColor.Blue,
            2 => SpaceColor.Red,
            4 => SpaceColor.Green,
            _ => null
        };
    }

    public Status? GetStatus(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        throw new NotImplementedException();
    }

    public short GetMinigameCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinMinigameOffset);
    }

    public byte GetHappening(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceHappeningOffset);
    }

    public short GetMaxCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinMaxOffset);
    }

}
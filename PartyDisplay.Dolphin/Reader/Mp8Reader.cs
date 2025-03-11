using PartyDisplay.Lib.Data;
using PartyDisplay.Lib.Data.Items;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Dolphin.Reader;

public class Mp8Reader : IReader<Mp8Candy> {
    private static readonly Lazy<Mp8Reader> _lazy = new(() => new Mp8Reader());
    public static Mp8Reader Connection => _lazy.Value;

    private const long P1 = 0x8022_82F8;
    private const long P2 = 0x8022_8410;
    private const long P3 = 0x8022_8528;
    private const long P4 = 0x8022_8640;

    private static readonly long[] _playerOffset = [P1, P2, P3, P4];
    
    private const long BCharacterOffset = 0;
    private const long BPortOffset = 5;
    private const long BRankingOffset = 13;
    private const long HCoinCountOffset = 38;
    private const long HCoinMinigameOffset = 40;
    private const long HCoinMaxOffset = 44;
    private const long HCoinSpentOffset = 62;
    private const long HStarCountOffset = 56;
    private const long HStarMaxOffset = 58;
    private const long BSpaceBlueOffset = 28;
    private const long BSpaceRedOffset = 29;
    private const long BSpaceHappeningOffset = 30;
    private const long BSpaceLuckyOffset = 31;
    private const long BSpaceDkOffset = 32;
    private const long BSpaceBowserOffset = 33;
    private const long HCandyUsedOffset = 60;
    private const long BDiceRollOffset = 14;
    private const long BLandedSpaceOffset = 1;
    private const long HSpacesMovedOffset = 24;
    private const long BItem1Offset = 6;
    private const long BItem2Offset = 7;
    private const long BItem3Offset = 8;

    private static readonly long[] _bItemOffset = [BItem1Offset, BItem2Offset, BItem3Offset];

    private const byte CharacterMask = 0x1E;
    private const byte CharacterBShift = 1;

    private const byte RankingMask = 0x0C;
    private const byte RankingBShift = 2;

    private const byte SpaceMask = 0xE0;
    private const byte SpaceBShift = 5;

    private Mp8Reader() { }
    
    public byte GetPortForPlayer(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BPortOffset);
    }
    public byte GetCurrentTurn() {
        throw new NotImplementedException();
    }
    public byte GetTurnLimit() {
        throw new NotImplementedException();
    }
    public Character GetCharacter(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        byte index = Memory.Access.SearchByte(_playerOffset[player] + BCharacterOffset);
        return Mp8.Characters[(index & CharacterMask) >> CharacterBShift];
    }
    public short GetCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinCountOffset);
    }
    public Mp8Candy? GetItem(byte player, byte slot) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(slot, 2);
        sbyte index = Memory.Access.SearchSByte(_playerOffset[player] + _bItemOffset[slot]);
        return index != -1 ? Mp8.Items[index] : null;
    }
    public Ranking GetRanking(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return ((Memory.Access.SearchByte(_playerOffset[player] + BRankingOffset) & RankingMask) >> RankingBShift) switch {
            0 => Ranking.First,
            1 => Ranking.Second,
            2 => Ranking.Third,
            3 => Ranking.Fourth,
            _ => throw new IndexOutOfRangeException("Bad Memory")
        };
    }
    public short GetStars(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HStarCountOffset);
    }
    public SpaceColor? GetLandedColor(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return ((Memory.Access.SearchByte(_playerOffset[player] + BLandedSpaceOffset) & SpaceMask) >> SpaceBShift) switch {
            1 => SpaceColor.Blue,
            2 => SpaceColor.Red,
            3 => SpaceColor.Green,
            _ => null
        };
    }

    public Status? GetStatus(byte player) => null;
    
    public short GetMinigameCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinMinigameOffset);
    }
    
    public short GetCandyUsed(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCandyUsedOffset);
    }
    
    public byte GetHappening(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceHappeningOffset);
    }
    
    public long GetSpacesMoved(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HSpacesMovedOffset);
    }
    
    public long GetCandyBought(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinSpentOffset);
    }
    
    public byte GetRed(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceRedOffset);
    }
}
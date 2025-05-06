using PartyDisplay.Lib.Data;
using PartyDisplay.Lib.Data.Items;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Dolphin.Reader;

public class Mp7Reader : IReader<Mp7Orb> {
    private static readonly Lazy<Mp7Reader> _lazy = new(() => new Mp7Reader());
    public static Mp7Reader Connection => _lazy.Value;

    private const long P1 = 0x8029_0C98;
    private const long P2 = 0x8029_0DA8;
    private const long P3 = 0x8029_0EB8;
    private const long P4 = 0x8029_0FC8;

    private static readonly long[] _playerOffset = [P1, P2, P3, P4];
    
    private const long BoardIndex = 0x0000_0000; //TODO: Need this index.
    private const long BCharacterOffset = 0;
    private const long BPortOffset = 5;
    private const long BRankingOffset = 13;
    private const long HCoinCountOffset = 38;
    private const long HCoinMinigameOffset = 40;
    private const long HCoinMaxOffset = 44;
    private const long HCoinSpentOffset = 46;
    private const long HStarCountOffset = 56;
    private const long HStarMaxOffset = 58;
    private const long BSpaceBlueOffset = 28;
    private const long BSpaceRedOffset = 29;
    private const long BSpaceCharacterOffset = 30;
    private const long BSpaceHappeningOffset = 31;
    private const long BSpaceBowserOffset = 32;
    private const long BSpaceMicOffset = 33;
    private const long BSpaceDuelOffset = 35;
    private const long BSpaceDkOffset = 36;
    private const long HOrbsUsedOffset = 60;
    private const long BDiceRollOffset = 15;
    private const long BLandedSpaceOffset = 12;
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

    private Mp7Reader() { }
    
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
    
    public Board GetBoard() {
        return Mp7.Boards[0]; //TODO: Need real index, and probably a shift/mask
        byte index = Memory.Access.SearchByte(BoardIndex);
        return Mp7.Boards[index];
    }
    
    public Character GetCharacter(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        byte index = Memory.Access.SearchByte(_playerOffset[player] + BCharacterOffset);
        return Mp7.Characters[(index & CharacterMask) >> CharacterBShift];
    }
    public short GetCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinCountOffset);
    }
    public Mp7Orb? GetItem(byte player, byte slot) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(slot, 2);
        sbyte index = Memory.Access.SearchSByte(_playerOffset[player] + _bItemOffset[slot]);
        return index != -1 ? Mp7.Items[index] : null;
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
    public Status? GetStatus(byte player) {
        throw new NotImplementedException();
    }
    
    public short GetMinigameCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinMinigameOffset);
    }
    
    public short GetOrbsUsed(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HOrbsUsedOffset);
    }
    
    public byte GetHappening(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceHappeningOffset);
    }
    
    public short GetSpacesMoved(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HSpacesMovedOffset);
    }
    
    public short GetOrbsBought(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinSpentOffset);
    }
    
    public byte GetRed(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceRedOffset);
    }
}
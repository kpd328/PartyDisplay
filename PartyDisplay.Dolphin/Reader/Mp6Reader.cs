using PartyDisplay.Lib.Data;
using PartyDisplay.Lib.Data.Items;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Dolphin.Reader;

public class Mp6Reader : IReader<Mp6Orb> {
    private static readonly Lazy<Mp6Reader> _lazy = new(() => new Mp6Reader());
    public static Mp6Reader Connection => _lazy.Value;

    private const long P1 = 0x8026_5750;
    private const long P2 = 0x8026_5858;
    private const long P3 = 0x8026_5960;
    private const long P4 = 0x8026_5A68;

    private static readonly long[] _playerOffset = [P1, P2, P3, P4];
    
    private const long BoardIndex = 0x0000_0000; //TODO: Need this index.
    private const long BCharacterOffset = 0;
    private const long BPortOffset = 4;
    private const long BRankingOffset = 9;
    private const long HCoinCountOffset = 28;
    private const long HCoinMinigameOffset = 30;
    private const long HCoinMaxOffset = 34;
    private const long HStarCountOffset = 48;
    private const long HStarMaxOffset = 50;
    private const long BSpaceBlueOffset = 20;
    private const long BSpaceRedOffset = 21;
    private const long BSpaceCharacterOffset = 22;
    private const long BSpaceHappeningOffset = 23;
    private const long BSpaceBowserOffset = 24;
    private const long BSpaceMiracleOffset = 25;
    private const long BSpaceDuelOffset = 26;
    private const long BSpaceDkOffset = 27;
    private const long HOrbsUsedOffset = 52;
    private const long BDiceRollOffset = 10;
    private const long BLandedSpaceOffset = 8;
    private const long BItem1Offset = 5;
    private const long BItem2Offset = 6;
    private const long BItem3Offset = 7;

    private static readonly long[] _bItemOffset = [BItem1Offset, BItem2Offset, BItem3Offset];

    private const byte CharacterMask = 0x1E;
    private const byte CharacterBShift = 1;

    private const byte RankingMask = 0x30;
    private const byte RankingBShift = 4;

    private const byte SpaceMask = 0xE0;
    private const byte SpaceBShift = 5;

    private Mp6Reader() { }

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
        return Mp6.Boards[0]; //TODO: Need real index, and probably a shift/mask
        byte index = Memory.Access.SearchByte(BoardIndex);
        return Mp6.Boards[index];
    }
    
    public Character GetCharacter(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        byte index = Memory.Access.SearchByte(_playerOffset[player] + BCharacterOffset);
        return Mp6.Characters[(index & CharacterMask) >> CharacterBShift];
    }
    public short GetCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinCountOffset);
    }
    public Mp6Orb? GetItem(byte player, byte slot) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(slot, 2);
        sbyte index = Memory.Access.SearchSByte(_playerOffset[player] + _bItemOffset[slot]);
        return index != -1 ? Mp6.Items[index] : null;
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
    
    public byte GetHappening(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceHappeningOffset);
    }

    public short GetOrbsUsed(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HOrbsUsedOffset);
    }
}
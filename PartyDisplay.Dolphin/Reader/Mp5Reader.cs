using PartyDisplay.Lib.Data;
using PartyDisplay.Lib.Data.Items;
using PartyDisplay.Lib.Data.Store;

namespace PartyDisplay.Dolphin.Reader;

public class Mp5Reader : IReader<Mp5Capsule> {
    private static readonly Lazy<Mp5Reader> _lazy = new(() => new());
    public static Mp5Reader Connection => _lazy.Value;

    private const long P1 = 0x8022_A070;
    private const long P2 = 0x8022_A178;
    private const long P3 = 0x8022_A280;
    private const long P4 = 0x8022_A388;

    private static readonly long[] _playerOffset = [P1, P2, P3, P4];

    private const long BTurnCurrentIndex = 0x8023_769E;
    private const long BTurnLimitIndex = 0x8023_769F;
    private const long BCharacterOffset = 0;
    private const long BPortOffset = 4;
    private const long BStatusOffset = 1;
    private const long BRankingOffset = 9;
    private const long HCoinCountOffset = 32;
    private const long HCoinMinigameOffset = 34;
    private const long HCoinMaxOffset = 38;
    private const long HStarCountOffset = 52;
    private const long HStarMaxOffset = 54;
    private const long BSpaceBlueOffset = 20;
    private const long BSpaceRedOffset = 21;
    private const long BSpaceCapsuleOffset = 22;
    private const long BSpaceHappeningOffset = 23;
    private const long BSpaceBowserOffset = 24;
    private const long BSpaceDkOffset = 30;
    private const long BDiceRollOffset = 10;
    private const long BLandedSpaceOffset = 8;
    private const long BItem1Offset = 5;
    private const long BItem2Offset = 6;
    private const long BItem3Offset = 7;

    private static readonly long[] _bItemOffset = [BItem1Offset, BItem2Offset, BItem3Offset];

    private const byte CharacterMask = 0x1F;
    private const byte CharacterBShift = 1;

    private const byte RankingMask = 0x60;
    private const byte RankingBShift = 5;

    private const byte SpaceMask = 0xC0;
    private const byte SpaceBShift = 6;

    private Mp5Reader() { }
    
    public byte GetPortForPlayer(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BPortOffset);
    }
    public byte GetCurrentTurn() => Memory.Access.SearchByte(BTurnCurrentIndex);

    public byte GetTurnLimit() => Memory.Access.SearchByte(BTurnLimitIndex);

    public Character GetCharacter(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        byte index = Memory.Access.SearchByte(_playerOffset[player] + BCharacterOffset);
        return Mp5.Characters[(index & CharacterMask) >> CharacterBShift];
    }
    
    public short GetCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinCountOffset);
    }
    
    public Mp5Capsule? GetItem(byte player, byte slot) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(slot, 2);
        sbyte index = Memory.Access.SearchSByte(_playerOffset[player] + _bItemOffset[slot]);
        return index != -1 ? Mp5.Items[index] : null;
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

    public short GetStarMax(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HStarMaxOffset);
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
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        byte index = Memory.Access.SearchByte(_playerOffset[player] + BStatusOffset);
        return index > 0 ? Mp5.Statuses[index - 1] : null;
    }
    
    public short GetMinigameCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinMinigameOffset);
    }
    
    public short GetMaxCoins(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchHword(_playerOffset[player] + HCoinMaxOffset);
    }

    public byte GetBlue(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceBlueOffset);
    }

    public byte GetRed(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceRedOffset);
    }

    public byte GetCapsuleSpace(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceCapsuleOffset);
    }
    
    public byte GetHappening(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceHappeningOffset);
    }

    public byte GetBowser(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceBowserOffset);
    }

    public byte GetDk(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BSpaceDkOffset);
    }

    public byte GetDiceRoll(byte player) {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(player, 3);
        return Memory.Access.SearchByte(_playerOffset[player] + BDiceRollOffset);
    }
}
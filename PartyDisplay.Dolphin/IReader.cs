using PartyDisplay.Lib.Data;

namespace PartyDisplay.Dolphin;

public interface IReader<TItem>
    where TItem : Item {
    
    byte GetPortForPlayer(byte player);
    byte GetCurrentTurn();
    byte GetTurnLimit();
    Character GetCharacter(byte player);
    short GetCoins(byte player);
    TItem? GetItem(byte player, byte slot);
    Ranking GetRanking(byte player);
    short GetStars(byte player);
    SpaceColor? GetLandedColor(byte player);
    Status? GetStatus(byte player);
}
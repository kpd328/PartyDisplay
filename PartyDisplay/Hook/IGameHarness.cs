using PartyDisplay.Data;
using PartyDisplay.Data.mp4;
using System;

namespace PartyDisplay.Hook {
    public interface IGameHarness {
        byte GetPortForPlayer(byte player);
    }

    public interface IGameHarness<TCharacter, TItem> : IGameHarness
        where TCharacter : ICharacter
        where TItem : IItem {

        TCharacter GetCharacterForBoard(byte player);
        TCharacter GetCharacterForPort(byte port);
        short GetCoins(byte player);
        TItem? GetItem(byte player, byte slot);
        Ranking GetRanking(byte player);
        short GetStars(byte player);
    }
}

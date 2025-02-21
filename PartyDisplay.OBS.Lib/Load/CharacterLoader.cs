using System.Text.Json;
using PartyDisplay.OBS.Lib.Data;
using PartyDisplay.OBS.Lib.Data.mp2;
using PartyDisplay.OBS.Lib.Data.mp4;
using PartyDisplay.OBS.Lib.Data.mp5;
using PartyDisplay.OBS.Lib.Data.mp6;
using PartyDisplay.OBS.Lib.Data.mp7;
using PartyDisplay.OBS.Lib.Data.mp8;

namespace PartyDisplay.OBS.Lib.Load;

public sealed class CharacterLoader<T> where T:ICharacter {
    private static readonly Lazy<CharacterLoader<T>> _instance = new(() => new());
    public static CharacterLoader<T> Data => _instance.Value;
    
    public T[] Characters { get; private set; }
    private T _t;

    private CharacterLoader() {
        string g = _t switch {
            Mp2Character mp2 => "mp2",
            Mp4Character mp4 => "mp4",
            Mp5Character mp5 => "mp5",
            Mp6Character mp6 => "mp6",
            Mp7Character mp7 => "mp7",
            Mp8Character mp8 => "mp8",
            _ => string.Empty
        };

        if (g == string.Empty) {
        } else {
            
        }
    }
}
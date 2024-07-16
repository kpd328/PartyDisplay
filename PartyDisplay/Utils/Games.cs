using System.Collections.Generic;

namespace PartyDisplay.Utils {
    public static class Games {
        private static readonly Dictionary<string, Game> GameIds = new(){
            { "GMPJ01", Game.MP4 },
            { "GMPE01", Game.MP4 },
            { "GMPP01", Game.MP4 },
            { "GP5J01", Game.MP5 },
            { "GP5E01", Game.MP5 },
            { "GP5P01", Game.MP5 },
            { "GP5W01", Game.MP5 },
            { "GP6J01", Game.MP6 },
            { "GP6E01", Game.MP6 },
            { "GP6P01", Game.MP6 },
            { "GP7J01", Game.MP7 },
            { "GP7E01", Game.MP7 },
            { "GP7P01", Game.MP7 },
            { "RM8J01", Game.MP8 },
            { "RM8E01", Game.MP8 },
            { "RM8P01", Game.MP8 },
            { "RM8K01", Game.MP8 }
        };

        public static Game? CheckGame(string g) {
            try {
                return GameIds[g];
            } catch(KeyNotFoundException) {
                return null;
            }
        }
    }

    public enum Game {
        MP2,
        MP4,
        MP5,
        MP6,
        MP7,
        MP8
    }
}

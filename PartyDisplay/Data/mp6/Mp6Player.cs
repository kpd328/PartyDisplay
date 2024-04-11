namespace PartyDisplay.Data.mp6 {
    public class Mp6Player:IPlayer<Mp6Character, Mp6Orb> {
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Mp6Character Character { get; set; }
        public Mp6Orb[] Items { get; set; } = new Mp6Orb[3];
    }
}

namespace PartyDisplay.Data.mp7 {
    public class Mp7Player:IPlayer<Mp7Character, Mp7Orb> {
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Mp7Character Character { get; set; }
        public Mp7Orb[] Items { get; set; } = new Mp7Orb[3];
    }
}

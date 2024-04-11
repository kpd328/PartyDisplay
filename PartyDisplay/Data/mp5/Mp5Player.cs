namespace PartyDisplay.Data.mp5 {
    public class Mp5Player:IPlayer<Mp5Character, Mp5Capsule> {
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Mp5Character Character { get; set; }
        public Mp5Capsule[] Items { get; set; }
    }
}

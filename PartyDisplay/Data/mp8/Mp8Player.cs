namespace PartyDisplay.Data.mp8 {
    public class Mp8Player:IPlayer<Mp8Character, Mp8Candy> {
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Mp8Character Character { get; set; }
        public Mp8Candy[] Items { get; set; } = new Mp8Candy[3];
    }
}

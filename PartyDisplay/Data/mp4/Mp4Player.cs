namespace PartyDisplay.Data.mp4 {
    public class Mp4Player:IPlayer<Mp4Character, Mp4Item> {
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public Mp4Character Character { get; set; }
        public Mp4Item[] Items { get; set; } = new Mp4Item[3];
    }
}

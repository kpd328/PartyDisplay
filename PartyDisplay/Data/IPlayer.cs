namespace PartyDisplay.Data {
    public interface IPlayer<TCharacter, TItem> 
        where TCharacter : ICharacter 
        where TItem : IItem {
        public int StarCount { get; set; }
        public int CoinCount { get; set; }
        public TCharacter Character { get; set; }
        public TItem[] Items { get; set; }
    }
}

namespace PartyDisplay.Data {
    public interface IContentData<TCharacter, TItem>
        where TCharacter : ICharacter
        where TItem : IItem {
        public TCharacter[] Characters { get; }
        public TItem[] Items { get; }
        public BonusStar[] BonusStars { get; }
    }
}

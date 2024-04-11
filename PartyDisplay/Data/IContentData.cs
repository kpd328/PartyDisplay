namespace PartyDisplay.Data {
    public interface IContentData<TCharacter, TItem>
        where TCharacter : ICharacter
        where TItem : IItem {
        public static TCharacter[] Characters { get; }
        public static TItem[] Items { get; }
    }
}

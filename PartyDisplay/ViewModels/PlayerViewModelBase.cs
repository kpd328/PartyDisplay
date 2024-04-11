using Avalonia.Media.Imaging;
using PartyDisplay.Data;
using System.Collections.ObjectModel;

namespace PartyDisplay.ViewModels {
    public abstract class PlayerViewModelBase<TPlayer, TCharacter, TItem>:ViewModelBase
        where TCharacter : ICharacter
        where TItem : IItem
        where TPlayer : IPlayer<TCharacter, TItem> {

        public virtual TPlayer Player { get; set; }
        public virtual Bitmap CoinIcon { get; }
        public virtual Bitmap StarIcon { get; }
        public virtual Bitmap XIcon { get; }
        public virtual ObservableCollection<TItem> CurrentItems { get; }
    }
}

using Avalonia.Media.Imaging;
using PartyDisplay.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PartyDisplay.ViewModels {
    public abstract class PlayerViewModelBase<TPlayer, TCharacter, TItem>:ViewModelBase
        where TCharacter : ICharacter
        where TItem : IItem
        where TPlayer : IPlayer<TCharacter, TItem> {

        public virtual byte Port { get; init; }
        public virtual TPlayer Player { get; set; }
        public virtual Bitmap CoinIcon { get; }
        public virtual Bitmap StarIcon { get; }
        public virtual Bitmap XIcon { get; }
        public virtual Bitmap RankIcon { get; set; }
        public virtual ObservableCollection<TItem> CurrentItems { get; }
        public MetaViewmodel Meta => MetaViewmodel.Instance;
        public Task<string> Name => Task.Run(() => Meta.NameForPort(Port));
    }
}

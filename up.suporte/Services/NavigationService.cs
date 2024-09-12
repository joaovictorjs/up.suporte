using up.suporte.Stores;
using up.suporte.ViewModels;

namespace up.suporte.Services
{
    public interface INavigationService
    {
        public void Navigate();
    }

    public class NavigationService<TViewModel> : INavigationService where TViewModel : BaseViewModel
    {
        private NavigationStore _navStore;
        private Func<TViewModel> _navFactory;

        public NavigationService(NavigationStore store, Func<TViewModel> factory)
        {
            _navStore = store;
            _navFactory = factory;
        }

        public void Navigate()
        {
            _navStore.CurrentViewModel = _navFactory.Invoke();
        }
    }
}

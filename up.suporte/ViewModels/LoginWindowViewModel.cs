using up.suporte.Stores;

namespace up.suporte.ViewModels
{
	public class LoginWindowViewModel : BaseViewModel
	{
		private NavigationStore _navStore;
		private BaseViewModel _currentViewModel => _navStore.CurrentViewModel;

		public BaseViewModel CurrentViewModel
		{
			get
			{
				return _currentViewModel;
			}
		}

		public LoginWindowViewModel(NavigationStore navStore, BaseViewModel initial)
		{
			_navStore = navStore;
			_navStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
			_navStore.CurrentViewModel = initial;
		}

		private void OnCurrentViewModelChanged()
		{
			OnPropertyChanged(nameof(CurrentViewModel));
		}
	}
}

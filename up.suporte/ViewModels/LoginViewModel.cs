using System.Windows.Input;
using up.suporte.Commands;
using up.suporte.Services;

namespace up.suporte.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService _navService;

        public ICommand GoToConfigureConnectionCommand
        {
            get;
        }

        public LoginViewModel(NavigationService<ConfigureConnectionViewModel> navService)
        {
            _navService = navService;

            GoToConfigureConnectionCommand = new RelayCommand(GoToConfigureConnection);
        }

        private void GoToConfigureConnection(object parameter) => _navService.Navigate();
    }
}

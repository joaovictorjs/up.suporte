using System.Windows.Input;
using up.suporte.Commands;
using up.suporte.Services;

namespace up.suporte.ViewModels
{
    public class ConfigureConnectionViewModel : BaseViewModel
    {
        private readonly INavigationService _navService;
        public ICommand NavigateToLoginCommand { get; }

        public ConfigureConnectionViewModel(NavigationService<LoginViewModel> navService)
        {
            _navService = navService;
            NavigateToLoginCommand = new RelayCommand(NavigateToLogin);
        }

        private void NavigateToLogin(object? parameter) => _navService.Navigate();
    }
}

namespace up.suporte.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel { get { return _currentViewModel; } }

        public LoginWindowViewModel()
        {
            _currentViewModel = new LoginViewModel();
        }
    }
}

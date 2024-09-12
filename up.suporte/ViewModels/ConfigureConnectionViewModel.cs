using System.Windows;
using System.Windows.Input;
using up.suporte.Commands;
using up.suporte.Services;
using up.suporte.Stores;

namespace up.suporte.ViewModels
{
    public class ConfigureConnectionViewModel : BaseViewModel
    {
        private readonly INavigationService _navService;
        private readonly IConfigFileService _configFileService;
        private readonly ConfigFileStore _configFileStore;

        public string Address { get => GetConfigValue("address"); set => SetConfigValue("Address", value); }
        public string Port { get => GetConfigValue("port"); set => SetConfigValue("Port", value); }
        public string Database { get => GetConfigValue("database"); set => SetConfigValue("Database", value); }
        public string Username { get => GetConfigValue("username"); set => SetConfigValue("Username", value); }

        public ICommand NavigateToLoginCommand { get; }
        public ICommand WriteCommand { get; }

        public ConfigureConnectionViewModel(NavigationService<LoginViewModel> navService, IConfigFileService configFileService, ConfigFileStore configFileStore)
        {
            _navService = navService;
            _configFileService = configFileService;
            _configFileStore = configFileStore;

            _configFileService.Read();

            NavigateToLoginCommand = new RelayCommand(NavigateToLogin);
            WriteCommand = new RelayCommand(Write, CanWrite);
        }

        private void NavigateToLogin(object? parameter) => _navService.Navigate();

        private void Write(object? parameter)
        {
            _configFileService.Write();
            MessageBox.Show("Arquivo de configuração salvo com sucesso!");
            _navService.Navigate();
        }

        private bool CanWrite(object? parameter) => _configFileService.IsOk();

        private string GetConfigValue(string key) => _configFileStore.CurrentConfig.GetValueOrDefault(key, string.Empty).Trim();

        private void SetConfigValue(string propertyName, string value)
        {
            _configFileStore.CurrentConfig[propertyName.ToLower()] = value;
            OnPropertyChanged(propertyName);
        }
    }
}

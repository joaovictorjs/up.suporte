using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Input;
using up.suporte.Commands;
using up.suporte.Services;
using up.suporte.Stores;

namespace up.suporte.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService _navService;
        private readonly IPgConnectionService _connService;
        private readonly IConfigFileService _configService;
        private readonly PgConnectionStore _connStore;
        private readonly ConfigFileStore _configStore;

        public string Username
        {
            get => _configStore.CurrentConfig.GetValueOrDefault("username", "").Trim();
            set
            {
                _configStore.CurrentConfig["username"] = value;
                OnPropertyChanged("Username");
            }
        }

        public ICommand GoToConfigureConnectionCommand
        {
            get;
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(
            NavigationService<ConfigureConnectionViewModel> navService,
            IPgConnectionService connService,
            IConfigFileService configService,
            PgConnectionStore connStore,
            ConfigFileStore configStore
        )
        {
            _navService = navService;
            _configService = configService;
            _connService = connService;
            _connStore = connStore;
            _configStore = configStore;

            _configService.Read();

            GoToConfigureConnectionCommand = new RelayCommand(GoToConfigureConnection);
            LoginCommand = new RelayCommand(Login);
        }

        private void GoToConfigureConnection(object parameter) => _navService.Navigate();

        private string? ConvertPassword(SecureString secureString)
        {
            IntPtr freeString = IntPtr.Zero;
            try
            {
                freeString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(freeString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(freeString);
            }
        }

        private async void Login(object? parameter)
        {
            if (!_configService.IsOk())
            {
                MessageBox.Show("Faltam informações importantes no arquivo de configuração da conexão. É necessário preenche-las primeiro!", "Erro");
                return;
            }

            if (string.IsNullOrEmpty(Username))
            {
                MessageBox.Show("Informe o usuário antes de prosseguir!", "Erro");
                return;
            }

            string? rawPassword = ConvertPassword((parameter as IPasswordStore).Password);

            if (string.IsNullOrEmpty(rawPassword))
            {
                MessageBox.Show("Informe a senha antes de prosseguir!", "Erro");
                return;
            }




            try
            {
                _connService.BuildConnectionString(
                    _configStore.CurrentConfig["address"],
                    _configStore.CurrentConfig["port"],
                    _configStore.CurrentConfig["database"],
                    Username, rawPassword
                );

                await _connService.CreateConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro");
            }
        }
    }
}

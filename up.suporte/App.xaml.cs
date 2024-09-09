using System.Windows;
using up.suporte.ViewModels;
using up.suporte.Windows;

namespace up.suporte
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow() { DataContext = new LoginWindowViewModel() };
            loginWindow.Show();

            base.OnStartup(e);
        }
    }

}

using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using up.suporte.ViewModels;
using up.suporte.Views;
using up.suporte.Windows;

namespace up.suporte
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            InitializeComponent();

            IHostBuilder builder = new HostBuilder();

            builder.ConfigureServices(services =>
            {
                services.AddTransient<LoginWindowViewModel>();
                services.AddTransient<LoginViewModel>();

                services.AddTransient<LoginWindow>(local => new LoginWindow() { DataContext = local.GetRequiredService<LoginWindowViewModel>() });
                services.AddTransient<LoginView>(local => new LoginView() { DataContext = local.GetRequiredService<LoginViewModel>() });
            });

            _host = builder.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            LoginWindow loginWindow = _host?.Services.GetService<LoginWindow>();
            loginWindow?.Show();

            base.OnStartup(e);
        }
    }

}

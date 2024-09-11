using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using up.suporte.Services;
using up.suporte.Stores;
using up.suporte.ViewModels;
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
				services.AddSingleton<NavigationStore>();
				services.AddSingleton<NavigationService<ConfigureConnectionViewModel>>(
					local => new NavigationService<ConfigureConnectionViewModel>(
						local.GetRequiredService<NavigationStore>(),
						() => local.GetRequiredService<ConfigureConnectionViewModel>()
					)
				);

				services.AddTransient<LoginWindowViewModel>(local => new LoginWindowViewModel(
						local.GetRequiredService<NavigationStore>(),
						local.GetRequiredService<LoginViewModel>()
					)
				);
				services.AddTransient<LoginViewModel>(local => new LoginViewModel(local.GetRequiredService<NavigationService<ConfigureConnectionViewModel>>()));
				services.AddTransient<ConfigureConnectionViewModel>(local => new ConfigureConnectionViewModel());

				services.AddSingleton<LoginWindow>(local => new LoginWindow()
				{
					DataContext = local.GetRequiredService<LoginWindowViewModel>()
				});
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

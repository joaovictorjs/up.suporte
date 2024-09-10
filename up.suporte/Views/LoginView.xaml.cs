using System.Security;
using System.Windows.Controls;
using up.suporte.Stores;

namespace up.suporte.Views
{
	/// <summary>
	/// Interaction logic for LoginView.xaml
	/// </summary>
	public partial class LoginView : UserControl, IPasswordStore
	{
		public LoginView()
		{
			InitializeComponent();
		}

		public SecureString Password => Pass.SecurePassword;

		public void Dispose()
		{
			Password.Dispose();
		}
	}
}

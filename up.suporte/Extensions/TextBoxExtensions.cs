using System.Windows;
using System.Windows.Controls;

namespace up.suporte.Extensions
{
	public partial class TextBoxExtensions
	{
		public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.RegisterAttached(
			"Placeholder",
			typeof(string),
			typeof(TextBoxExtensions));

		public static readonly DependencyProperty LabelProperty = DependencyProperty.RegisterAttached(
			"Label",
			typeof(string),
			typeof(TextBoxExtensions));

		public static string GetPlaceholder(TextBox textBox)
		{
			return (string)textBox.GetValue(PlaceholderProperty);
		}

		public static void SetPlaceholder(TextBox textBox, string value)
		{
			textBox.SetValue(PlaceholderProperty, value);
		}

		public static string GetLabel(TextBox textBox)
		{
			return (string)textBox.GetValue(LabelProperty);
		}

		public static void SetLabel(TextBox textBox, string value)
		{
			textBox.SetValue(LabelProperty, value);
		}
	}
}

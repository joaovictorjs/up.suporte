using System.Windows;
using System.Windows.Controls;

namespace up.suporte.Extensions
{
    public partial class PasswordBoxExtensions
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.RegisterAttached(
            name: "Label",
            propertyType: typeof(string),
            ownerType: typeof(PasswordBoxExtensions),
            defaultMetadata: new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty BorderHeightProperty = DependencyProperty.RegisterAttached(
            name: "BorderHeight",
            propertyType: typeof(double),
            ownerType: typeof(PasswordBoxExtensions),
            defaultMetadata: new FrameworkPropertyMetadata((double)40, FrameworkPropertyMetadataOptions.AffectsRender));

        public static string GetLabel(PasswordBox passwordBox)
        {
            return (string)passwordBox.GetValue(LabelProperty);
        }

        public static void SetLabel(PasswordBox passwordBox, string value)
        {
            passwordBox.SetValue(LabelProperty, value);
        }

        public static double GetBorderHeight(PasswordBox passwordBox)
        {
            return (double)passwordBox.GetValue(BorderHeightProperty);
        }

        public static void SetBorderHeight(PasswordBox passwordBox, double value)
        {
            passwordBox.SetValue(BorderHeightProperty, value);
        }
    }
}

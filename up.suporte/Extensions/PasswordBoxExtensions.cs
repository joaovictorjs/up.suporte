using System.Windows;
using System.Windows.Controls;

namespace up.suporte.Extensions
{
    public partial class PasswordBoxExtensions
    {
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.RegisterAttached(
            name: "Placeholder",
            propertyType: typeof(string),
            ownerType: typeof(PasswordBoxExtensions),
            defaultMetadata: new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender));

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

        public static readonly DependencyProperty IsPasswordEmptyProperty = DependencyProperty.RegisterAttached(
            name: "IsPasswordEmpty",
            propertyType: typeof(bool),
            ownerType: typeof(PasswordBoxExtensions),
            defaultMetadata: new FrameworkPropertyMetadata((bool)true, FrameworkPropertyMetadataOptions.AffectsRender));

        public static string GetPlaceholder(PasswordBox passwordBox)
        {
            return (string)passwordBox.GetValue(PlaceholderProperty);
        }

        public static void SetPlaceholder(PasswordBox passwordBox, string value)
        {
            passwordBox.SetValue(PlaceholderProperty, value);
        }

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

        public static bool GetIsPasswordEmpty(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(IsPasswordEmptyProperty);
        }

        public static void SetIsPasswordEmpty(PasswordBox passwordBox, bool value)
        {
            passwordBox.SetValue(IsPasswordEmptyProperty, value);
        }
    }
}

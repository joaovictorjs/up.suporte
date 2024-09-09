using System.Windows;
using System.Windows.Controls;

namespace up.suporte.Extensions
{
    public partial class TextBoxExtensions
    {
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.RegisterAttached(
            name: "Placeholder",
            propertyType: typeof(string),
            ownerType: typeof(TextBoxExtensions),
            defaultMetadata: new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty LabelProperty = DependencyProperty.RegisterAttached(
            name: "Label",
            propertyType: typeof(string),
            ownerType: typeof(TextBoxExtensions),
            defaultMetadata: new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty BorderHeightProperty = DependencyProperty.RegisterAttached(
            name: "BorderHeight",
            propertyType: typeof(double),
            ownerType: typeof(TextBoxExtensions),
            defaultMetadata: new FrameworkPropertyMetadata((double)40, FrameworkPropertyMetadataOptions.AffectsRender));

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

        public static double GetBorderHeight(TextBox textBox)
        {
            return (double)textBox.GetValue(BorderHeightProperty);
        }

        public static void SetBorderHeight(TextBox textBox, double value)
        {
            textBox.SetValue(BorderHeightProperty, value);
        }
    }
}

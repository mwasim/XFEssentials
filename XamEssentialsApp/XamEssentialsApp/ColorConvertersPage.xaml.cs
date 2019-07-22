using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorConvertersPage : ContentPage
    {
        public ColorConvertersPage()
        {
            InitializeComponent();
        }

        private void OnFromHexValueClicked(object sender, EventArgs e)
        {
            var hexValue = EntryHexValue.Text.Trim();
            if (string.IsNullOrWhiteSpace(hexValue)) return;

            var hexColor = ColorConverters.FromHex(hexValue);

            BoxViewHexColor.Color = hexColor;

            // Multiplies the current alpha by 50%
            BoxViewHexColorMultiAlpha.Color = hexColor.MultiplyAlpha(.5f);

            var uInt = hexColor.ToUInt();
            BoxViewUIntColor.Color = ColorConverters.FromUInt(uInt);

            BoxViewHslColor.Color =
                ColorConverters.FromHsl(hexColor.GetHue(), hexColor.GetSaturation(), hexColor.GetBrightness());
        }

        private void OnFromHslClicked(object sender, EventArgs e)
        {
            var h = EntryHValue.Text.Trim();
            var s = EntrySValue.Text.Trim();
            var l = EntryLValue.Text.Trim();

            float.TryParse(h, out var hue);
            float.TryParse(s, out var saturation);
            float.TryParse(l, out var luminosity);

            BoxViewHslColor.Color = ColorConverters.FromHsl(hue, saturation, luminosity);
        }

        private void OnFromUIntValueClicked(object sender, EventArgs e)
        {
            var text = EntryUIntValue.Text.Trim();

            UInt32.TryParse(text, out var uintValue);

            BoxViewUIntColor.Color = ColorConverters.FromUInt(uintValue);
        }
    }
}
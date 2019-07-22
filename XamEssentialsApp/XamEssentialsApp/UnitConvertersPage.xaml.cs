using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnitConvertersPage : ContentPage
    {
        public UnitConvertersPage()
        {
            InitializeComponent();
        }

        private void FahrenheitToCelsiusClicked(object sender, EventArgs e)
        {
            try
            {
                var fromValue = EntryFromFahrenheit.Text?.Trim();
                
                if (string.IsNullOrWhiteSpace(fromValue) == false)
                {
                    double.TryParse(fromValue, out var input);

                    EntryToCelsius.Text = UnitConverters.FahrenheitToCelsius(input).ToString(CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void CelsiusToFahrenheitClicked(object sender, EventArgs e)
        {
            try
            {
                var fromValue = EntryFromCelsius.Text?.Trim();

                if (string.IsNullOrWhiteSpace(fromValue) == false)
                {
                    double.TryParse(fromValue, out var input);

                    EntryToFahrenheit.Text = UnitConverters.CelsiusToFahrenheit(input).ToString(CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void MilesToKilometersClicked(object sender, EventArgs e)
        {
            try
            {
                var fromValue = EntryFromMiles.Text?.Trim();

                if (string.IsNullOrWhiteSpace(fromValue) == false)
                {
                    double.TryParse(fromValue, out var input);

                    EntryToKilometers.Text = UnitConverters.MilesToKilometers(input).ToString(CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void KilometersToMilesClicked(object sender, EventArgs e)
        {
            try
            {
                var fromValue = EntryFromKilometers.Text?.Trim();

                if (string.IsNullOrWhiteSpace(fromValue) == false)
                {
                    double.TryParse(fromValue, out var input);

                    EntryToMiles.Text = UnitConverters.KilometersToMiles(input).ToString(CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void OnDegreesToRadiansClicked(object sender, EventArgs e)
        {
            try
            {
                var fromValue = EntryFromDegrees.Text?.Trim();

                if (string.IsNullOrWhiteSpace(fromValue) == false)
                {
                    double.TryParse(fromValue, out var input);

                    EntryToRadians.Text = UnitConverters.DegreesToRadians(input).ToString(CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void RadiansToDegreesClicked(object sender, EventArgs e)
        {
            try
            {
                var fromValue = EntryFromRadians.Text?.Trim();

                if (string.IsNullOrWhiteSpace(fromValue) == false)
                {
                    double.TryParse(fromValue, out var input);

                    EntryToDegrees.Text = UnitConverters.RadiansToDegrees(input).ToString(CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
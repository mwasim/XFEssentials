using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarometerPage : ContentPage
    {
        public BarometerPage()
        {
            InitializeComponent();
        }

        private void OnButtonStartClicked(object sender, EventArgs e)
        {
            if (Barometer.IsMonitoring) return;

            try
            {
                LabelPressure.TextColor = Color.Black;

                Barometer.ReadingChanged += OnBarometerReadingChanged;
                Barometer.Start(SensorSpeed.UI);
            }
            catch (FeatureNotSupportedException exception)
            {
                Console.WriteLine(exception);
                LabelPressure.Text = "Feature not supported";
                LabelPressure.TextColor = Color.Red;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                LabelPressure.Text = "An unknown error occurred";
                LabelPressure.TextColor = Color.Red;
            }
        }

        private void OnBarometerReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            LabelPressure.Text = $"Reading: {e.Reading.PressureInHectopascals} hectopascals";
        }

        private void OnButtonStopClicked(object sender, EventArgs e)
        {
            if (Barometer.IsMonitoring == false) return;

            Barometer.ReadingChanged -= OnBarometerReadingChanged;
            Barometer.Stop();
        }
    }
}
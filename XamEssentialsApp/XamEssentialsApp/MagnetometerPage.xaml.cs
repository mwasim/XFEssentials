using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MagnetometerPage : ContentPage
    {
        public MagnetometerPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Magnetometer.ReadingChanged += OnMagnetometerReadingChanged;
        }

        private void OnMagnetometerReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            var reading = e.Reading.MagneticField;

            LabelMagnetometerReading.Text = $"X = {reading.X}\n" +
                                            $"Y = {reading.Y}\n" +
                                            $"Z = {reading.Z}\n";
        }

        private void OnToggleMagnetometerClicked(object sender, EventArgs e)
        {
            try
            {
                if (Magnetometer.IsMonitoring)
                {
                    Magnetometer.Stop();
                }
                else
                {
                    Magnetometer.Start(SensorSpeed.UI);
                }
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
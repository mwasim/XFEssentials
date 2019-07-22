using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrientationSensorPage : ContentPage
    {
        public OrientationSensorPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            OrientationSensor.ReadingChanged +=OnOrientationSensorReadingChanged;
        }

        private void OnOrientationSensorReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            var reading = e.Reading.Orientation;

            LabelOrientationSensor.Text = $"Reading: X = {reading.X}\n" +
                                          $"Y = {reading.Y}\n" +
                                          $"Z = {reading.Z}\n" +
                                          $"W = {reading.W}\n";
        }

        private void OnToggleOrientationSensorClicked(object sender, EventArgs e)
        {
            try
            {
                if (OrientationSensor.IsMonitoring)
                {
                    OrientationSensor.Stop();
                }
                else
                {
                    OrientationSensor.Start(SensorSpeed.UI);
                }
            }
            catch (FeatureNotSupportedException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}
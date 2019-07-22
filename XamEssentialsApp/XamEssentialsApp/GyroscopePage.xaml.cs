using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GyroscopePage : ContentPage
    {
        public GyroscopePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Gyroscope.ReadingChanged += OnGyroscopeReadingChanged;
        }

        private void OnGyroscopeReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            LabelGyroscopeReading.Text =
                "Gyroscope Reading (AngularVelocity):\n" +
                $"X = {e.Reading.AngularVelocity.X}\n" +
                $"Y = {e.Reading.AngularVelocity.Y}\n" +
                $"Z = {e.Reading.AngularVelocity.Z}";
        }

        private void OnToggleGyroscopeClicked(object sender, EventArgs e)
        {
            try
            {
                if (Gyroscope.IsMonitoring == false)
                {
                    Gyroscope.Start(SensorSpeed.UI);
                }
                else
                {
                    Gyroscope.Stop();
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
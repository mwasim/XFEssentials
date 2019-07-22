using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompassPage : ContentPage
    {
        public CompassPage()
        {
            InitializeComponent();
        }

        private void OnToggleCompassClicked(object sender, EventArgs e)
        {
            try
            {
                if (Compass.IsMonitoring)
                {
                    //stop compass reading
                    Compass.Stop();
                    return;
                }

                Compass.ReadingChanged += OnCompassReadingChanged;

                /*
                 * On Android, applyLowPassFilter:true is used, and on iOS it's ignored
                 * https://docs.microsoft.com/en-us/xamarin/essentials/compass?context=xamarin%2Fandroid&tabs=android
                 */
                Compass.Start(SensorSpeed.UI, applyLowPassFilter: true);
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

        private void OnCompassReadingChanged(object sender, CompassChangedEventArgs e)
        {
            LabelCompassReading.Text = $"Reading: {e.Reading.HeadingMagneticNorth} degrees";
        }
    }
}
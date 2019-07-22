using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    /*
     * NOTE: ENSURE THE VIBRATE PERMISSION IS SET IN THE ANDROID MANIFEST (Can be set via Android Project properties)
     */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VibratePage : ContentPage
    {
        public VibratePage()
        {
            InitializeComponent();
        }

        private void OnVibrateClicked(object sender, EventArgs e)
        {
            try
            {
                //Use default vibration length
                Vibration.Vibrate();
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

        private void OnCancelVibration(object sender, EventArgs e)
        {
            try
            {
               Vibration.Cancel();
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

        private void OnCustomVibrationClicked(object sender, EventArgs e)
        {
            try
            {
                //Use custom vibration length
                Vibration.Vibrate(TimeSpan.FromSeconds(1));
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
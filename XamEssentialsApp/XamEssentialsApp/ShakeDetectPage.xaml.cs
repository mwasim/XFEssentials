using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShakeDetectPage : ContentPage
    {
        public ShakeDetectPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Accelerometer.ShakeDetected += OnAccelerometerShakeDetected;

            //when using ShakeDetect, it's better to use Game or Fast sensor speed as it's faster and UI takes much longer and not suitable in this scenario 
            Accelerometer.Start(SensorSpeed.Game); 
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Accelerometer.ShakeDetected -= OnAccelerometerShakeDetected;
            Accelerometer.Stop();
        }

        private void OnAccelerometerShakeDetected(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() => { LabelShakeText.Text = "Device Shaked!"; });
        }
    }
}
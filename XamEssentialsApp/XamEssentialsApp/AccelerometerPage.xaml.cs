using System;
using System.ComponentModel;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AccelerometerPage
    {
        public AccelerometerPage()
        {
            InitializeComponent();
        }

        private void OnButtonStartClicked(object sender, EventArgs e)
        {
            if (Xamarin.Essentials.Accelerometer.IsMonitoring) return; //already monitoring

            Accelerometer.ReadingChanged += OnAccelerometerReadingChanged;
            Accelerometer.Start(SensorSpeed.UI); //since we started on the UI
        }

        private void OnAccelerometerReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            //Since, it was started on the UI, it'll come on the UI
            LabelX.Text = e.Reading.Acceleration.X.ToString();
            LabelY.Text = e.Reading.Acceleration.Y.ToString();
            LabelZ.Text = e.Reading.Acceleration.Z.ToString();
        }

        private void OnButtonStopClicked(object sender, EventArgs e)
        {
            if (Xamarin.Essentials.Accelerometer.IsMonitoring == false) return; //not monitoring

            Accelerometer.ReadingChanged -= OnAccelerometerReadingChanged;
            Accelerometer.Stop();
        }
    }
}

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    /*
     * NOTE: ENSURE THE BATTERY PERMISSION IS SET IN THE ANDROID MANIFEST (Can be set via Android Project properties)
     */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BatteryInfoPage : ContentPage
    {
        public BatteryInfoPage()
        {
            InitializeComponent();

            SetBackground(Battery.ChargeLevel, Battery.State == BatteryState.Charging);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Battery.BatteryInfoChanged+= OnBatteryInfoChanged;
        }

        private void OnBatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            SetBackground(e.ChargeLevel, e.State == BatteryState.Charging);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Battery.BatteryInfoChanged -= OnBatteryInfoChanged;
        }

        private void SetBackground(double level, bool charging)
        {
            Color? color = null;
            var status = charging ? "Charging" : "Not charging";

            if (level > 0.5f)
            {
                color = Color.Green.MultiplyAlpha(level);
            }else if (level > 0.1f)
            {
                color = Color.Yellow.MultiplyAlpha(1d - level);
            }
            else
            {
                color = Color.Red.MultiplyAlpha(1d - level);
            }

            BackgroundColor = color.Value;
            LabelBatteryLevel.Text = level.ToString();
        }
    }
}
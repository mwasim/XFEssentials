using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceInfoPage : ContentPage
    {
        public DeviceInfoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Device Model (SMG-950U, iPhone10,6)
            var model = DeviceInfo.Model;

            // Manufacturer (Samsung)
            var manufacturer = DeviceInfo.Manufacturer;

            // Device Name (Motz's iPhone)
            var name = DeviceInfo.Name;

            // Operating System Version Number (7.0)
            var version = DeviceInfo.Version;

            // Platform (Android)
            var platform = DeviceInfo.Platform;

            // Idiom (Phone)
            var idiom = DeviceInfo.Idiom;

            // Device Type (Physical)
            var deviceType = DeviceInfo.DeviceType;

            LabelModel.Text = $"Model: {model}";
            LabelManufacturer.Text = $"Manufacturer: {manufacturer}";
            LabelName.Text = $"Name: {name}";
            LabelVersion.Text = $"Version: {version}";
            LabelPlatform.Text = $"Platform: {platform}";
            LabelIdiom.Text = $"Idiom: {idiom}";
            LabelDeviceType.Text = $"DeviceType: {deviceType}";
        }

    }
}
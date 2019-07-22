using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceDisplayInfoPage : ContentPage
    {
        public DeviceDisplayInfoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;

            /**
             * On iOS:
             * Accessing DeviceDisplay must be done on the UI thread or else an exception will be thrown.
             * You can use the MainThread.BeginInvokeOnMainThread method to run that code on the UI thread.
             */
            
            //This method is already executing on the main UI thread
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            ShowDeviceDisplayInfo(mainDisplayInfo);
        }

        private void ShowDeviceDisplayInfo(DisplayInfo mainDisplayInfo)
        {
            var orientation = mainDisplayInfo.Orientation;
            var density = mainDisplayInfo.Density;
            var width = mainDisplayInfo.Width;
            var height = mainDisplayInfo.Height;
            var rotation = mainDisplayInfo.Rotation;

            LabelOrientation.Text = $"Orientation = {orientation}";
            LabelDensity.Text = $"Density = {density}";
            LabelWidth.Text = $"Width = {width}";
            LabelHeight.Text = $"Height = {height}";
            LabelRotation.Text = $"Rotation = {rotation}";
        }

        private void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            ShowDeviceDisplayInfo(e.DisplayInfo);
        }
    }
}
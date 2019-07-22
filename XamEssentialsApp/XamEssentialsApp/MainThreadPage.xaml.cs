using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainThreadPage : ContentPage
    {
        public MainThreadPage()
        {
            InitializeComponent();
        }

        private async void OnDoSomeWorkClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.IsEnabled = false;
            ActivityIndicatorProgress.IsRunning = true;

            await Task.Run(async () =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    MainThread.BeginInvokeOnMainThread(() => { LabelOutput.Text = $"Update: #{i}"; });
                    await Task.Delay(1000);
                }
            });

            ActivityIndicatorProgress.IsRunning = false;
            button.IsEnabled = true;
        }
    }
}
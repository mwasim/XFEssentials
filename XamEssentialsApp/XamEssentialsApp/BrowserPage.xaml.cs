using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowserPage : ContentPage
    {
        public BrowserPage()
        {
            InitializeComponent();
        }

        private async void OnOpenUrlClicked(object sender, EventArgs e)
        {
            try
            {
                var url = EntryUrl.Text.Trim();

                await Browser.OpenAsync(url, new BrowserLaunchOptions
                {
                    LaunchMode = BrowserLaunchMode.SystemPreferred,
                    TitleMode = BrowserTitleMode.Show,
                    PreferredControlColor = Color.LightBlue,
                    PreferredToolbarColor = Color.DarkViolet
                });
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
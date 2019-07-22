using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SharePage : ContentPage
    {
        public SharePage()
        {
            InitializeComponent();
        }

        private async void OnShareTextClicked(object sender, EventArgs e)
        {
            try
            {
                var text = EntryShareText.Text?.Trim();
                if (string.IsNullOrWhiteSpace(text))
                {
                    await DisplayAlert("Enter text", "Please enter text to share", "OK");
                    return;
                }

                await Share.RequestAsync(new ShareTextRequest
                {
                    Title = "Shared Text",
                    //Text = "This is the shared text! :)\nLink = http://www.google.com"
                    Text = text
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
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LauncherPage : ContentPage
    {
        public LauncherPage()
        {
            InitializeComponent();
        }

        private async void OnLaunchAppClicked(object sender, EventArgs e)
        {
            try
            {
                var url = "skype://123456789";
                var supportsUri = await Launcher.CanOpenAsync(url);

                var contactsUrl = "contacts://123456789";
                var canOpenContacts = await Launcher.CanOpenAsync(contactsUrl);

                if (supportsUri)
                {
                    await Launcher.OpenAsync(url);
                }
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    //NOTE: Set platform specific settings - https://docs.microsoft.com/en-us/xamarin/essentials/secure-storage?context=xamarin%2Fandroid&tabs=android
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecureStoragePage : ContentPage
    {
        private const string MySecureStorageKey = "MySecureStorageKey";

        public SecureStoragePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            EntryPreference.Text = await SecureStorage.GetAsync(MySecureStorageKey);
        }

        private async void OnSetStorageValueClicked(object sender, EventArgs e)
        {
            try
            {
                var text = EntryPreference.Text?.Trim();

                await SecureStorage.SetAsync(MySecureStorageKey, text);
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
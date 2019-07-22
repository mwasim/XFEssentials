using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhoneDialerPage : ContentPage
    {
        public PhoneDialerPage()
        {
            InitializeComponent();
        }

        private async void OnOpenDialerClicked(object sender, EventArgs e)
        {
            try
            {
                var phoneNumber = EntryPhoneNumber.Text?.Trim();
                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    await DisplayAlert("Enter phone number", "Please enter phone number", "OK");
                    return;
                }

                PhoneDialer.Open(phoneNumber);
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(ex);
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
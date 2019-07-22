using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SMSPage : ContentPage
    {
        public SMSPage()
        {
            InitializeComponent();
        }

        private async void OnSMSTextClicked(object sender, EventArgs e)
        {
            try
            {
                var text = EntrySMSText.Text?.Trim();
                if (string.IsNullOrWhiteSpace(text))
                {
                    await DisplayAlert("Enter text", "Please enter text to SMS", "OK");
                    return;
                }

                var message = new SmsMessage
                {
                    Body = text,
                    Recipients = new List<string>
                    {
                        "03118886512",
                        "03118886515",
                        "03118886516",
                    }
                };

                await Sms.ComposeAsync(message);

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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendEmailPage : ContentPage
    {
        public SendEmailPage()
        {
            InitializeComponent();
        }

        private async void OnSendEmailClicked(object sender, EventArgs e)
        {
            var toList = EntryTo.Text.Trim();
            var subject = EntrySubject.Text.Trim();
            var body = EntryMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(toList) ||
                string.IsNullOrWhiteSpace(subject) ||
                string.IsNullOrWhiteSpace(body)) return;


            var recipients = new List<string>();
            var list = toList.Split(';');

            foreach (var toEmail in list)
            {
                recipients.Add(toEmail);
            }

            await SendEmail(recipients, subject, body);
        }

        private async Task SendEmail(List<string> recipients, string subject, string body)
        {
            try
            {
                var message = new EmailMessage
                {
                    To = recipients,
                    Subject = subject,
                    Body = body,

                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };

                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine(ex);
                await DisplayAlert("Error", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
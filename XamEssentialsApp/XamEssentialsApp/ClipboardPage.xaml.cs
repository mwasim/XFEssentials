using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClipboardPage : ContentPage
    {
        public ClipboardPage()
        {
            InitializeComponent();
        }

        private async void OnCopyEntryTextClicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(EntryText.Text);
        }

        private async void OnPasteEntryTextClicked(object sender, EventArgs e)
        {
            LabelEntryText.Text = string.Empty;
            if (Clipboard.HasText)
            {
                LabelEntryText.Text = await Clipboard.GetTextAsync();
            }
        }
    }
}
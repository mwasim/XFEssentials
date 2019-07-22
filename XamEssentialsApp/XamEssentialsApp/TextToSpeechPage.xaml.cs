using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextToSpeechPage : ContentPage
    {
        private CancellationTokenSource _cts;

        public TextToSpeechPage()
        {
            InitializeComponent();
        }

        private async void OnTextToSpeechClicked(object sender, EventArgs e)
        {
            try
            {
                _cts = new CancellationTokenSource();

                var locales = await TextToSpeech.GetLocalesAsync();

                // Grab the first locale
                var locale = locales.FirstOrDefault(x=>x.Language == "en");

                var settings = new SpeechOptions()
                {
                    Volume = .75f,
                    Pitch = 1.0f,
                    Locale = locale
                };

                var text  = EntryTextToSpeak.Text?.Trim();
                if (string.IsNullOrWhiteSpace(text))
                {
                    text = "Please enter text for speech.";
                }

                await TextToSpeech.SpeakAsync(text, cancelToken: _cts.Token, options: settings);
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void OnCancelSpeechClicked(object sender, EventArgs e)
        {
            if (_cts?.IsCancellationRequested ?? true) return;

            _cts.Cancel();
        }
    }
}
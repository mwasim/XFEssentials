using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreferencesPage : ContentPage
    {
        private const string MyPrefKey = "MyPrefKey";
        public PreferencesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (Preferences.ContainsKey(MyPrefKey))
            //{
            //    LabelPrefValue.Text = Preferences.Get(MyPrefKey, "Preference not set");
            //}

            EntryPreference.Text = Preferences.Get(MyPrefKey, "Preference not set");
        }

        private void OnSetPreferenceClicked(object sender, EventArgs e)
        {
            try
            {
                var preference = EntryPreference.Text?.Trim();

                Preferences.Set(MyPrefKey, preference);
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
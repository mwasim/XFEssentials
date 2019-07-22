using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppInfoPage : ContentPage
    {
        public AppInfoPage()
        {
            InitializeComponent();

            LabelAppInfo.Text = $"{AppInfo.Name}";
            LabelVersionInfo.Text = $"{AppInfo.VersionString}" + $"{AppInfo.BuildString}";
        }

        private void OnShowSettingsClicked(object sender, EventArgs e)
        {
            AppInfo.ShowSettingsUI();
        }
    }
}
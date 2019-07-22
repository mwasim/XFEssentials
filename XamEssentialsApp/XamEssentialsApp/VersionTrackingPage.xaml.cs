using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VersionTrackingPage : ContentPage
    {
        public VersionTrackingPage()
        {
            InitializeComponent();

            LabelVersionTrackingInfo.Text = $"IsFirstLaunchEver: {VersionTracking.IsFirstLaunchEver}\n"
                + $"IsFirstLaunchForCurrentVersion: {VersionTracking.IsFirstLaunchForCurrentVersion}\n"
                + $"IsFirstLaunchForCurrentBuild: {VersionTracking.IsFirstLaunchForCurrentBuild}\n"
                + $"CurrentVersion: {VersionTracking.CurrentVersion}\n"
                + $"CurrentBuild: {VersionTracking.CurrentBuild}\n"
                + $"PreviousVersion: {VersionTracking.PreviousVersion}\n"

                + $"PreviousBuild: {VersionTracking.PreviousBuild}\n"
                + $"FirstInstalledVersion: {VersionTracking.FirstInstalledVersion}\n"
                + $"FirstInstalledBuild: {VersionTracking.FirstInstalledBuild}\n";

            var buildHistory = VersionTracking.BuildHistory;
            var versionHistory = VersionTracking.VersionHistory;
        }
    }
}
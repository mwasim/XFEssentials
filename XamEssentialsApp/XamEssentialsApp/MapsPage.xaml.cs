using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();
        }

        private async void OnOpenMapByLocationClicked(object sender, EventArgs e)
        {
            try
            {
                var location = new Location(47.645160, -122.1306032);
                var options = new MapLaunchOptions
                {
                    Name = "Microsoft Building 25",
                    //NavigationMode = NavigationMode.Driving
                };

                await Map.OpenAsync(location, options);
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

        private async void OnOpenMapByPlacemarkClicked(object sender, EventArgs e)
        {
            try
            {
                /*
                 * When opening with a Placemark, the following information is required:
                    CountryName
                    AdminArea
                    Thoroughfare
                    Locality
                 */
                var placemark = new Placemark
                {
                    CountryName = "United States",
                    AdminArea = "WA",
                    Thoroughfare = "Microsoft Building 25",
                    Locality = "Redmond"
                };

                var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

                await Map.OpenAsync(placemark, options);
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
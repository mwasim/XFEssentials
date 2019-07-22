using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    /*
     * NOTE: ENSURE THE `Coarse` and `Fine Location` PERMISSIONS ARE SET IN THE ANDROID MANIFEST (Can be set via Android Project properties)
     */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeolocationPage : ContentPage
    {
        public GeolocationPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var lastKnownLocation = await Geolocation.GetLastKnownLocationAsync();

                if (lastKnownLocation != null)
                {
                    LabelLastKnownLocation.Text = "Last known location:\n" +
                                                  $"{nameof(lastKnownLocation.Latitude)}: {lastKnownLocation.Latitude}\n" +
                                                  $"{nameof(lastKnownLocation.Longitude)}: {lastKnownLocation.Longitude}\n" +
                                                  $"{nameof(lastKnownLocation.Altitude)}: {lastKnownLocation.Altitude}\n" +
                                                  $"{nameof(lastKnownLocation.Accuracy)}: {lastKnownLocation.Accuracy}\n" +
                                                  $"{nameof(lastKnownLocation.Course)}: {lastKnownLocation.Course}\n" +
                                                  $"{nameof(lastKnownLocation.IsFromMockProvider)}: {lastKnownLocation.IsFromMockProvider}\n" +
                                                  $"{nameof(lastKnownLocation.Speed)}: {lastKnownLocation.Speed}\n" +
                                                  $"{nameof(lastKnownLocation.Timestamp)}: {lastKnownLocation.Timestamp}\n";
                }
                else
                {
                    LabelLastKnownLocation.Text = "Last known location not found.";
                }



                var currentDeviceLocation =
                    await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));

                if (currentDeviceLocation != null)
                {
                    LabelCurrentDeviceLocation.Text = "Device current location:\n" +
                                                      $"{nameof(currentDeviceLocation.Latitude)}: {currentDeviceLocation.Latitude}\n" +
                                                      $"{nameof(currentDeviceLocation.Longitude)}: {currentDeviceLocation.Longitude}\n" +
                                                      $"{nameof(currentDeviceLocation.Altitude)}: {currentDeviceLocation.Altitude}\n" +
                                                      $"{nameof(currentDeviceLocation.Accuracy)}: {currentDeviceLocation.Accuracy}\n" +
                                                      $"{nameof(currentDeviceLocation.Course)}: {currentDeviceLocation.Course}\n" +
                                                      $"{nameof(currentDeviceLocation.IsFromMockProvider)}: {currentDeviceLocation.IsFromMockProvider}\n" +
                                                      $"{nameof(currentDeviceLocation.Speed)}: {currentDeviceLocation.Speed}\n" +
                                                      $"{nameof(currentDeviceLocation.Timestamp)}: {currentDeviceLocation.Timestamp}\n";


                    var placemarks = await Geocoding.GetPlacemarksAsync(currentDeviceLocation.Latitude,
                        currentDeviceLocation.Longitude);

                    var placemark = placemarks?.FirstOrDefault();
                    if (placemark != null)
                    {
                        var placemarkLocation =
                            $"{nameof(placemark.AdminArea)}: {placemark.AdminArea}\n" +
                            $"{nameof(placemark.CountryCode)}: {placemark.CountryCode}\n" +
                            $"{nameof(placemark.CountryName)}: {placemark.CountryName}\n" +
                            $"{nameof(placemark.FeatureName)}: {placemark.FeatureName}\n" +
                            $"{nameof(placemark.Locality)}: {placemark.Locality}\n" +
                            $"{nameof(placemark.PostalCode)}: {placemark.PostalCode}\n" +
                            $"{nameof(placemark.SubAdminArea)}: {placemark.SubAdminArea}\n" +
                            $"{nameof(placemark.SubLocality)}: {placemark.SubLocality}\n" +
                            $"{nameof(placemark.SubThoroughfare)}: {placemark.SubThoroughfare}\n" +
                            $"{nameof(placemark.Thoroughfare)}: {placemark.Thoroughfare}\n";

                        LabelCurrentDeviceLocation.Text += $"\n\n{placemarkLocation}";
                    }
                }
                else
                {
                    LabelCurrentDeviceLocation.Text = "Unable to find device current location.";
                }


                Location boston = new Location(42.358056, -71.063611);
                Location sanFrancisco = new Location(37.783333, -122.416667);

                var distance = Location.CalculateDistance(boston, sanFrancisco, DistanceUnits.Kilometers);

                LabelDistanceBetweenTwoLocations.Text = "Distance between Boston and San Francisco:\n" +
                                                        $"{distance} kilometers.";

            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine(ex);
            }
            catch (FeatureNotEnabledException ex)
            {
                Debug.WriteLine(ex);
            }
            catch (PermissionException ex)
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
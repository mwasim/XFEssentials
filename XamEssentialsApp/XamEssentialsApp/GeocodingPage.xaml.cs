using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeocodingPage
    {
        private string _latitude = "47.673988";
        private string _longitude = "-122.121513";
        private string _geocodeAddress;
        private string _geocodePosition;
        private string _address = "Microsoft Building 25 Redmond WA USA";

        public ICommand DetectPlacemarksCommand { get; set; }
        public ICommand DetectLocationCommand { get; set; }

        public GeocodingPage()
        {
            InitializeComponent();

            DetectPlacemarksCommand = new Command(async () => await OnDetectPlacemarks(), () => IsBusy == false);
            DetectLocationCommand = new Command(async () => await OnDetectLocation(), () => IsBusy == false);

            BindingContext = this;
        }

        private async Task OnDetectPlacemarks()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                double.TryParse(Latitude, out var lat);
                double.TryParse(Longitude, out var lng);

                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lng);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark == null)
                {
                    GeocodeAddress = "Unable to detect place-marks";
                    return;
                }

                GeocodeAddress =
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
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task OnDetectLocation()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                var locationList = await Geocoding.GetLocationsAsync(Address);

                var location = locationList?.FirstOrDefault();
                if (location == null)
                {
                    GeocodePosition = "Unable to detect location";
                    return;
                }

                GeocodePosition =
                    $"{nameof(location.Latitude)}: {location.Latitude}\n" +
                    $"{nameof(location.Longitude)}: {location.Longitude}\n" +
                    $"{nameof(location.Altitude)}: {location.Altitude}\n" +
                    $"{nameof(location.Accuracy)}: {location.Accuracy}\n" +
                    $"{nameof(location.Course)}: {location.Course}\n" +
                    $"{nameof(location.IsFromMockProvider)}: {location.IsFromMockProvider}\n" +
                    $"{nameof(location.Speed)}: {location.Speed}\n" +
                    $"{nameof(location.Timestamp)}: {location.Timestamp}\n";
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public string Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        public string Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }

        public string GeocodeAddress
        {
            get => _geocodeAddress;
            set => SetProperty(ref _geocodeAddress, value);
        }

        public string GeocodePosition
        {
            get => _geocodePosition;
            set => SetProperty(ref _geocodePosition, value);
        }

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        protected virtual bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null, Func<T, T, bool> validateValue = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            if (validateValue != null && !validateValue(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
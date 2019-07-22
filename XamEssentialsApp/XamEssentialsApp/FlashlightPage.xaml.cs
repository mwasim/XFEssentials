using System;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamEssentialsApp
{
    /*
     * NOTE: ENSURE THE `Flashlight` and `Camera` PERMISSIONS ARE SET IN THE ANDROID MANIFEST (Can be set via Android Project properties)
     */

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashlightPage : ContentPage
    {
        private bool _flashlightStatus;
        public FlashlightPage()
        {
            InitializeComponent();
        }

        private async void OnToggleFlashlightClicked(object sender, EventArgs e)
        {
            try
            {
                var sb = new StringBuilder("Flashlight is ");

                if (_flashlightStatus == false)
                {
                    await Flashlight.TurnOnAsync();

                    _flashlightStatus = true;

                    sb.Append("ON");
                }
                else
                {
                    await Flashlight.TurnOffAsync();

                    _flashlightStatus = false;

                    sb.Append("OFF");
                }


                LabelFlashlightStatus.Text = sb.ToString();
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
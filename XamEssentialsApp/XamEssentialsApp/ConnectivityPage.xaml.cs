using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using XamEssentialsApp.Utils;

namespace XamEssentialsApp
{
    /*
     * NOTE: ENSURE THE `AccessNetworkState` PERMISSION IS SET IN THE ANDROID MANIFEST (Can be set via Android Project properties)
     */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectivityPage : ContentPage
    {
        public ConnectivityPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            InitStates();
            Connectivity.ConnectivityChanged += OnConnectivityChanged;

            try
            {
                var password = await SecureStorage.GetAsync("token");
                EntryPassword.Text = password;
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                LabelConnection.FadeTo(0).ContinueWith((result) => { });
            }
            else
            {
                LabelConnection.FadeTo(1).ContinueWith((result) => { });
            }
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("No internet", "Please go online", "OK");
                return;
            }

            var isValid = true;
            var username = EntryUsername.Text.Trim();
            var password = EntryPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || username.Length < 5)
            {
                VisualStateManager.GoToState(EntryUsername, "Invalid");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 5)
            {
                VisualStateManager.GoToState(EntryPassword, "Invalid");
                isValid = false;
            }

            if (isValid)
            {
                try
                {
                    await SecureStorage.SetAsync("token", EntryPassword.Text);

                    await DisplayAlert("Login Success", "You've logged in successfully!", "OK");
                }
                catch (Exception ex)
                {
                    // Possible that device doesn't support secure storage on device.
                }
                //await DisplayAlert("Login Success", "", "Thanks!");
                //await Clipboard.SetTextAsync("1234");
                //await Navigation.PushAsync(new ClipboardPage());
            }
        }

        private void OnForgotPasswordTapped(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://xamarin.com", BrowserLaunchMode.SystemPreferred);
        }

        private void InitStates()
        {
            var stateGroup = new VisualStateGroup
            {
                Name = "StrengthStates",
                TargetType = typeof(Label)
            };

            stateGroup.States.Add(CreateVisualState("Blank", "", Color.White));
            stateGroup.States.Add(CreateVisualState("VeryWeak", "\uf023", Color.Red));
            stateGroup.States.Add(CreateVisualState("Weak", "\uf023 \uf023", Color.Orange));
            stateGroup.States.Add(CreateVisualState("Medium", "\uf023 \uf023 \uf023", Color.Yellow));
            stateGroup.States.Add(CreateVisualState("String", "\uf023 \uf023 \uf023 \uf023", Color.Green));
            stateGroup.States.Add(CreateVisualState("VeryStrong", "\uf023 \uf023 \uf023 \uf023 \uf023", Color.Green));

            VisualStateManager.SetVisualStateGroups(this.LabelStrengthIndicator, new VisualStateGroupList { stateGroup });
        }

        private VisualState CreateVisualState(string strength, string text, Color color)
        {
            var textSetter = new Setter { Value = text, Property = Label.TextProperty };
            var colorSetter = new Setter { Value = color, Property = Label.TextColorProperty };

            return new VisualState
            {
                Name = strength,
                TargetType = typeof(Label),
                Setters = { textSetter, colorSetter }
            };
        }


        public bool RememberMe
        {
            get => Preferences.Get(nameof(RememberMe), false);
            set
            {
                Preferences.Set(nameof(RememberMe), value);
                if (!value)
                {
                    Preferences.Set(nameof(Username), string.Empty);
                }
                OnPropertyChanged(nameof(RememberMe));
            }
        }

        string username = Preferences.Get(nameof(Username), string.Empty);
        public string Username
        {
            get => username;
            set
            {
                username = value;
                if (RememberMe)
                    Preferences.Set(nameof(Username), value);
                OnPropertyChanged(nameof(RememberMe));
            }
        }

        string strength;

        public string Strength
        {
            get => strength;
            set
            {
                strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }

        private void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            var strength = PasswordAdvisor.CheckStrength(e.NewTextValue);
            var strengthName = Enum.GetName(typeof(PasswordScore), strength);

            VisualStateManager.GoToState(this.LabelStrengthIndicator, strengthName);
        }
    }
}
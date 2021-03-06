﻿using Xamarin.Forms;
using XamEssentialsApp.Infrastructure;

namespace XamEssentialsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Xamarin.Essentials.VersionTracking.Track(); //start tracking version info

            MainPage = new MasterPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

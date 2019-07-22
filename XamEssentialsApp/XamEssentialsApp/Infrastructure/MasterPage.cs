using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using XamEssentialsApp.Models;

namespace XamEssentialsApp.Infrastructure
{
    public class MasterPage : MasterDetailPage
    {
        private readonly MainMenu _mainMenu;
        private const string BarBackgroundColor = "#16222a";
        private const string BarTextColor = "#F1F1F1";
        private const string SelectedMenuItemBarTextColor = "#ccc";

        public MasterPage()
        {
            _mainMenu = new MainMenu();
            Master = _mainMenu;

            Detail = new Xamarin.Forms.NavigationPage(new AppInfoPage())
            {
                BarBackgroundColor = Color.FromHex(BarBackgroundColor),
                BarTextColor = Color.FromHex(BarTextColor)
            };

            ((Xamarin.Forms.NavigationPage)Detail).On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

            _mainMenu.Menu.ItemSelected += MenuOnItemSelected;
        }

        private void MenuOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
            if (item == null) return;

            Detail = new Xamarin.Forms.NavigationPage((Xamarin.Forms.Page) Activator.CreateInstance(item.TargetType))
            {
                BarBackgroundColor = Color.FromHex(BarBackgroundColor),
                BarTextColor = Color.FromHex(SelectedMenuItemBarTextColor)
            };

            ((Xamarin.Forms.NavigationPage)Detail).On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

            _mainMenu.Menu.SelectedItem = null;
            IsPresented = false;
        }
    }
}

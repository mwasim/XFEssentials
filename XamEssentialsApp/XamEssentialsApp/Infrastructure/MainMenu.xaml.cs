using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp.Infrastructure
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public ListView Menu => ListViewMenu;
    }
}
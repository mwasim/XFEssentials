using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace XamEssentialsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FileSysHelpersPage
    {
        private readonly string _localPath;
        private const string LocalFileName = "TheFile.txt";

        public FileSysHelpersPage()
        {
            InitializeComponent();

            _localPath = Path.Combine(FileSystem.CacheDirectory, LocalFileName);
        }

        private async void OnLoadAssetFileClicked(object sender, EventArgs e)
        {
            try
            {
                using (var stream = await FileSystem.OpenAppPackageFileAsync("TestFile.txt"))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var fileContents = await reader.ReadToEndAsync();
                        LabelAssetFileContents.Text = fileContents;
                    }
                }
            }
            catch (FeatureNotSupportedException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void OnSaveTextClicked(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(_localPath, EditorText.Text);
            }
            catch (FeatureNotSupportedException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private void OnLoadClicked(object sender, EventArgs e)
        {
            if (File.Exists(_localPath))
            {
                EditorText.Text = File.ReadAllText(_localPath);
            }
        }
    }
}
using System.Windows;
using ITS.Models.Models;
using ITS.ViewModels.ViewModels;

namespace ITS.WpfClient
{
    public partial class App : Application
    {
        private readonly DataUploadModel _dataUploadModel;

        public App()
        {
            _dataUploadModel = new DataUploadModel();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_dataUploadModel)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

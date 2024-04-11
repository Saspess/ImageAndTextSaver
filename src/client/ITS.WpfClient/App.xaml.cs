using System.Windows;
using ITS.Models.Models;
using ITS.Services.IoC;
using ITS.ViewModels.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ITS.WpfClient
{
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }
        private readonly DataUploadModel _dataUploadModel;

        public App()
        {
            _dataUploadModel = new DataUploadModel();

            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddClientServices();
                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            //var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            //startupForm.Show();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_dataUploadModel)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }
}

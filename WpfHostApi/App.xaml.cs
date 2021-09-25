using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfHostApi.Core;

namespace WpfHostApi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class App : Application
    {
        private readonly WindowExceptionHandler _windowExceptionHandler;
        private readonly IHost _host;

        public App()
        {
            _windowExceptionHandler = new WindowExceptionHandler();
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                })
                .ConfigureServices((context, services) =>
                {
                    //register services here
                    services.AddSingleton<MainWindow>();
                    services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
                })
                .ConfigureLogging(logging =>
                {

                })
                .ConfigureWebHostDefaults(webHost =>
                {
                    webHost.UseKestrel(opts =>
                    {
                        opts.ListenLocalhost(5000);
                        opts.AddServerHeader = false;
                    }).UseStartup<ApiStartup>();
                }).Build();
        }
        private async void App_OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                //Dont await, otherwise it never quits and the web server will keep running in background.
                _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}

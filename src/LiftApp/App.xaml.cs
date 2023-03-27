using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LiftApp.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LiftApp.Dal.Extensions;

namespace LiftApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;
        private readonly ILogger<App> _logger;

        public App()
        {
            _host = CreateHostBuilder().Build();
            _logger = _host.Services.GetRequiredService<ILogger<App>>();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                await _host.StartAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "");
                throw;
            }
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }

        private static IHostBuilder CreateHostBuilder()
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((context, configurationBuilder) =>
                {
                    configurationBuilder.SetBasePath(AppContext.BaseDirectory);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false);
                });

            ConfigureServices(builder);

            return builder;
        }

        private static void ConfigureServices(IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.RegisterDataAccessLayerServices(context.Configuration);
            });
        }
    }
}

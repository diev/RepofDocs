using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Rosd.Wpf.Data;

using System;
using System.IO;
using System.Windows;

namespace Rosd.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider? ServiceProvider { get; private set; }
    public static IConfiguration? Configuration { get; private set; }

    //public App()
    //{
    //    ServiceCollection services = new();

    //    services.AddDbContext<ApplicationDbContext>(options =>
    //    {
    //        options.UseSqlite(connectionString);
    //    });

    //    services.AddSingleton<MainWindow>();
    //    serviceProvider = services.BuildServiceProvider();
    //}

    private void OnStartup(object s, StartupEventArgs e)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        string connection = Configuration[nameof(connection)];
        string connectionString = Configuration.GetConnectionString(connection);

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            switch (connection)
            {
                case "Sqlite":
                    options.UseSqlite(connectionString);
                    break;

                //case "SqlServer":
                //    options.UseSqlServer(connectionString);
                //    break;

                //case "Npgsql":
                //    options.UseNpgsql(connectionString);
                //    break;
            }
        });

        services.AddTransient(typeof(MainWindow));
    }
}

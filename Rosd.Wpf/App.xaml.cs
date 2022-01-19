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
    public const string Title = "Rosd";
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
        string connection = Configuration[nameof(connection)] ?? "DefaultConnection";
        string connectionString = Configuration.GetConnectionString(connection);

        switch (connection)
        {
            case "Sqlite":
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
                break;

            //case "SqlServer":
            //    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            //    break;

            //case "Npgsql":
            //    services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
            //    break;
        }

        services.AddTransient(typeof(MainWindow));
    }
}

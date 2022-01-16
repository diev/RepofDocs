using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Rosd.Wpf.Data;

using System.Windows;

namespace Rosd.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private const string connectionString = "Data Source = Tracks.db";
    private readonly ServiceProvider serviceProvider;

    public App()
    {
        ServiceCollection services = new();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddSingleton<MainWindow>();
        serviceProvider = services.BuildServiceProvider();
    }

    private void OnStartup(object s, StartupEventArgs e)
    {
        var mainWindow = serviceProvider.GetService<MainWindow>();
        mainWindow.Show();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Rosd.Data.Repositories;

namespace Rosd.Data;

public static class DataRepositories
{
    internal static Func<RosdDbContext> DBContextFactory { get; private set; } = null!;

    internal static string SqliteConnectionString { get; private set; } = null!;
    internal static string ClientsPath { get; private set; } = null!;

    //internal static string PostgreSqlConnectionString { get; private set; } = null!;
    //internal static string SqlServerConnectionString { get; private set; } = null!;

    static DataRepositories()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        ClientsPath = configuration[nameof(ClientsPath)];

        SqliteConnectionString = configuration.GetConnectionString(nameof(SqliteConnectionString));
        //PostgreSqlConnectionString = configuration.GetConnectionString(nameof(PostgreSqlConnectionString));
        //SqlServerConnectionString = configuration.GetConnectionString(nameof(SqlServerConnectionString));

        var options = new DbContextOptionsBuilder<RosdDbContext>().UseSqlite(SqliteConnectionString).Options;
        DBContextFactory = () => new RosdDbContext(options);

        //var options = new DbContextOptionsBuilder<RosdDbContext>().UseNpgsql(PostgreSqlConnectionString).Options;
        //DBContextFactory = () => new RosdDbContext(options, new LowerCaseConverter());

        //var options = new DbContextOptionsBuilder<RosdDbContext>().UseSqlServer(SqlServerConnectionString).Options;
        //DBContextFactory = () => new RosdDbContext(options);
    }

    public static ClientRepository GetClientRepository()
    {
        return new ClientRepository(ClientsPath);
    }

    public static TrackRepository GetTrackRepository()
    {
        return new TrackRepository(DBContextFactory);
    }
}

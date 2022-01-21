using Microsoft.EntityFrameworkCore;

using Rosd.Data.Conventions;
using Rosd.Data.Entities;

using System.Text.RegularExpressions;

namespace Rosd.Data.Repositories;

public partial class RosdDbContext : DbContext
{
    private readonly IDatabaseConventionConverter? _convention;

    public RosdDbContext()
        : base()
    {
    }

    public RosdDbContext(DbContextOptions<RosdDbContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public RosdDbContext(DbContextOptions<RosdDbContext> options, IDatabaseConventionConverter convention)
        : base(options)
    {
        _convention = convention;
    }

    // Using "= null!;" to remove the compiler warning.
    // Assume that the DbContext constructor will populate these properties.

    public virtual DbSet<Track> Tracks { get; set; } = null!;
    public virtual DbSet<LastNum> LastNums { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=Tracks.db");
    //    optionsBuilder.UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder == null)
        {
            throw new ArgumentNullException(nameof(modelBuilder), $"{nameof(modelBuilder)} is null.");
        }

#nullable disable // Assume that the DbContext constructor will populate these properties.

        modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS"); // default: "SQL_Latin1_General_CP1_CI_AS"

        modelBuilder.Entity<Track>(entity =>
        {
            entity.Property(e => e.IDate).IsUnicode(false);
            entity.Property(e => e.SendDate).IsUnicode(false);
            entity.Property(e => e.INN).IsUnicode(false);
            entity.Property(e => e.JDate).IsUnicode(false);
            entity.Property(e => e.JNo).IsUnicode(false);
            entity.Property(e => e.RDate).IsUnicode(false);
            entity.Property(e => e.ODate).IsUnicode(false);
            entity.Property(e => e.ONo).IsUnicode(false);
        });

#nullable enable

        //i"Id",
        //"IDate",
        //i"INo",
        //"Via",*
        //"Sender",*
        //"SendDate",
        //"SendNo",
        //"Attn",*
        //"Client",*
        //"INN",*
        //"Content",
        //"Person",*
        //"Notes",
        //"JDate",
        //"JNo",
        //"JSubject",
        //"RDate",
        //"ODate",
        //"ONo",
        //"Receiver",*
        //"OSubject"

        string demoData = ""; //TODO App.Configuration[nameof(demoData)];
        if (File.Exists(demoData))
        {
            modelBuilder.Entity<Track>().HasData(SeedDemoData(demoData));
        }

        //string clientsPath = App.Configuration[nameof(clientsPath)];
        //if (Directory.Exists(clientsPath))
        //{
        //    modelBuilder.Entity<Client>().HasData(SeedClientData(clientsPath));
        //}

        modelBuilder.Entity<LastNum>().HasData(new LastNum
        {
            Id = DateTime.Today.Year,
            INo = 0,
            JNo = 0,
            ONo = 0
        });

        // Allow subclasses to override conventions
        OnModelCreatingPartial(modelBuilder);

        // Apply Conventions
        //_convention?.SetConvention(modelBuilder); //TODO

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    private static Client[] SeedClientData(string path)
    {
        //const string pattern = @"(.*)\s+\(\s*ИНН\s+(\d*)\s*\)";
        const string pattern = @"(.*)\s\(ИНН\s(\d*)\)";

        int id = 0;
        var dirs = new DirectoryInfo(path).GetDirectories();
        var data = new Client[dirs.Length];

        foreach (var di in dirs)
        {
            var item = di.Name.Trim();
            var match = Regex.Match(item, pattern);

            if (match.Success)
            {
                data[id] = new Client
                {
                    Id = ++id,
                    Title = match.Groups[1].Value,
                    INN = match.Groups[2].Value
                };
            }
            else
            {
                data[id] = new Client
                {
                    Id = ++id,
                    Title = item,
                    INN = string.Empty
                };
            }
        }

        return data;
    }

    private static Track[] SeedDemoData(string file)
    {
        int id = 0;
        var lines = File.ReadAllLines(file);
        var data = new Track[lines.Length];

        foreach (var line in lines)
        {
            var items = line.Split('\t');
            int ino = int.TryParse(items[0], out int i) ? i : 0;

            if (id < 75)
            {
                data[id] = new Track
                {
                    Id = ++id,
                    IDate = items[1],
                    INo = ino,
                    Via = items[2],
                    Sender = items[3],
                    SendDate = items[12].Length > 14 ? items[12][^10..] : string.Empty,
                    SendNo = items[12].Length > 14 ? items[12][0..^14] : string.Empty,
                    Attn = items[4],
                    Client = items[5],
                    INN = items[16],
                    Content = items[6],
                    JSubject = items[6].Split(' ')[0],
                    Person = items[7] ?? items[27],
                    Notes = items[17],
                    JDate = items[11],
                    JNo = items[10],
                    RDate = items[19],
                    ODate = items[23],
                    ONo = items[22],
                    Receiver = items[24],
                    OSubject = items[25]
                };
            }
            else
            {
                {
                    data[id] = new Track
                    {
                        Id = ++id,
                        IDate = items[1],
                        INo = ino,
                        Via = items[2],
                        Sender = items[3],
                        SendDate = items[12],
                        SendNo = items[12],
                        Attn = items[4],
                        Client = items[5],
                        INN = items[16],
                        Content = items[6],
                        Person = items[27],
                        Notes = items[17],
                        JDate = items[11],
                        JNo = items[10],
                        RDate = items[19],
                        ODate = items[23],
                        ONo = items[22],
                        Receiver = items[24],
                        OSubject = items[25]
                    };
                }
            }
        }

        return data;
    }
}

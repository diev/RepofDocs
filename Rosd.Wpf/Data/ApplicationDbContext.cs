using Microsoft.EntityFrameworkCore;

using System;
using System.IO;

namespace Rosd.Wpf.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<Track> Tracks { get; set; } = null!;
    public DbSet<LastTaken> LastTaken { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        string file = "DemoDump.txt";
        if (File.Exists(file))
        {
            modelBuilder.Entity<Track>().HasData(SeedDemoData(file));
        }

        modelBuilder.Entity<LastTaken>().HasData(
            new LastTaken { Id = DateTime.Today.Year, INo = 0, JNo = 0, ONo = 0 });

        base.OnModelCreating(modelBuilder);
    }

    private static Track[] SeedDemoData(string file)
    {
        int id = 0;
        var lines = File.ReadAllLines(file);
        var data = new Track[lines.Length];

        foreach (var line in lines)
        {
            var items = line.Split('\t');
            int ino = int.TryParse(items[0], out int i)? i: 0;

            if (id < 75)
            {
                data[id] = new Track
                {
                    Id = ++id,
                    IDate = items[1],
                    INo = ino,
                    IFile = items[9],
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
                    OFile = items[28],
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
                        IFile = items[9],
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
                        OFile = items[28],
                        Receiver = items[24],
                        OSubject = items[25]
                    };
                }
            }
        }

        return data;
    }
} 

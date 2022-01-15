using Microsoft.EntityFrameworkCore;

using Rosd.Wpf.Models;

namespace Rosd.Wpf.Data;

public class TrackContext : DbContext
{
    public DbSet<TrackItem> TrackItems { get; set; } = null!;
    public DbSet<AttnItem> AttnItems { get; set; } = null!;
    public DbSet<PersonItem> PersonItems { get; set; } = null!;
    public DbSet<TitleItem> TitleItems { get; set; } = null!;
    public DbSet<ViaItem> ViaItems { get; set; } = null!;
    public DbSet<LastTaken> LastTaken { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tracks.db");
        optionsBuilder.UseLazyLoadingProxies();
    }
}

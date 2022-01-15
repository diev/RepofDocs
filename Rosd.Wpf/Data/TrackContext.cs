using Microsoft.EntityFrameworkCore;

using Rosd.Wpf.Models;

namespace Rosd.Wpf.Data;

public class TrackContext : DbContext
{
    public DbSet<Track>? Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tracks.db");
        optionsBuilder.UseLazyLoadingProxies();
    }
}

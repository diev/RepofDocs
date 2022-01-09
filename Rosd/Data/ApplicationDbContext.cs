using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Rosd.Helpers;

namespace Rosd.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("public");

        base.OnModelCreating(builder);

        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var tableName = builder.Entity(entity.Name).Metadata.GetDefaultTableName();
            if (tableName != null)
            {
                if (tableName.Contains('<'))
                {
                    tableName = tableName.Split('<')[0];
                }

                builder.Entity(entity.Name).ToTable(tableName.ToSnakeCase());
            }
        }
    }
}

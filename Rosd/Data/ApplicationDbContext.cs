using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Rosd.Helpers;
using Rosd.Models;

namespace Rosd.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public DbSet<Income> Incomes { get; set; } = null!;
    public DbSet<Outcome> Outcomes { get; set; } = null!;
    public DbSet<Doc> Docs { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("public");

        builder.Entity<Doc>(entity =>
        {
            entity.ToTable("docs");
            entity.HasKey(i => i.Id).HasName("pk_docs");
            entity.HasIndex(e => e.Hash, "ix_doc_hash");
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasMany(f => f.Docs)
                .WithMany(d => d.Folders)
                .UsingEntity<Dictionary<string, object>>(
                    "FolderDoc",
                    l => l.HasOne<Doc>().WithMany().HasForeignKey("DocId").HasConstraintName("fk_doc_id"),
                    r => r.HasOne<Doc>().WithMany().HasForeignKey("FolderId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_folder_id"),
                    j =>
                    {
                        j.ToTable("folder_doc");
                        j.HasKey("DocId", "FolderId");
                        j.HasIndex(new[] { "FolderId" }, "IX_folder_doc_FolderId");
                    });

            entity.HasMany(d => d.Incomes)
                .WithMany(i => i.Docs)
                .UsingEntity<Dictionary<string, object>>(
                    "InDoc",
                    l => l.HasOne<Income>().WithMany().HasForeignKey("IncomeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_in_id"),
                    r => r.HasOne<Doc>().WithMany().HasForeignKey("DocId").HasConstraintName("fk_doc_id"),
                    j =>
                    {
                        j.ToTable("in_doc");
                        j.HasKey("DocId", "IncomeId");
                        j.HasIndex(new[] { "IncomeId" }, "IX_in_doc_IncomeId");
                    });

            entity.HasMany(d => d.Outcomes)
                .WithMany(o => o.Docs)
                .UsingEntity<Dictionary<string, object>>(
                    "OutDoc",
                    l => l.HasOne<Outcome>().WithMany().HasForeignKey("OutcomeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_out_id"),
                    r => r.HasOne<Doc>().WithMany().HasForeignKey("DocId").HasConstraintName("fk_doc_id"),
                    j =>
                    {
                        j.ToTable("out_doc");
                        j.HasKey("DocId", "OutcomeId");
                        j.HasIndex(new[] { "OutcomeId" }, "IX_out_doc_OutcomeId");
                    });

            entity.HasMany(d => d.Folders)
                .WithMany(f => f.Docs)
                .UsingEntity<Dictionary<string, object>>(
                    "FolderDoc",
                    l => l.HasOne<Doc>().WithMany().HasForeignKey("FolderId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_folder_id"),
                    r => r.HasOne<Doc>().WithMany().HasForeignKey("DocId").HasConstraintName("fk_doc_id"),
                    j =>
                    {
                        j.ToTable("folder_doc");
                        j.HasKey("DocId", "FolderId");
                        j.HasIndex(new[] { "FolderId" }, "IX_folder_doc_FolderId");
                    });
        });

        builder.Entity<Income>(entity =>
        {
            entity.ToTable("incomes");
            entity.HasKey(i => i.Id).HasName("pk_incomes");
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasMany(i => i.Outcomes)
                .WithMany(o => o.Incomes)
                .UsingEntity<Dictionary<string, object>>(
                    "InOut",
                    l => l.HasOne<Outcome>().WithMany().HasForeignKey("OutcomeId").HasConstraintName("fk_out_id"),
                    r => r.HasOne<Income>().WithMany().HasForeignKey("IncomeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_in_id"),
                    j =>
                    {
                        j.ToTable("in_out");
                        j.HasKey("IncomeId", "OutcomeId");
                        j.HasIndex(new[] { "OutcomeId" }, "IX_in_out_OutcomeId");
                    });
        });

        builder.Entity<Outcome>(entity =>
        {
            entity.ToTable("outcomes");
            entity.HasKey(i => i.Id).HasName("pk_outcomes");
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

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

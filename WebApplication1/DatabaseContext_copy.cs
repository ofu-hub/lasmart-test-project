/*
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;

/// Контекст для работы базы данных PostgreSQL
public sealed partial class DatabaseContext : DbContext
{
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Point> Points { get; set; } = null!;

    public DatabaseContext() { }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        if (Database.GetPendingMigrations().Any())
            Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.Color).IsRequired();
            e.Property(e => e.Text).IsRequired();
            e.Property(e => e.PointId).IsRequired();

            e.HasOne(c => c.Point).WithMany(p => p.Comments).HasForeignKey(c => c.PointId);
        });

        modelBuilder.Entity<Point>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.Color).IsRequired();
            e.Property(e => e.Radius).IsRequired();
            e.Property(e => e.X).IsRequired();
            e.Property(e => e.Y).IsRequired();

            e.HasMany(p => p.Comments).WithOne(c => c.Point).HasForeignKey(c => c.PointId);
        });
    }
}
*/

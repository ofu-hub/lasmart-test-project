using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;

/// <summary>
/// Контект базы данных in-memmory
/// </summary>
public sealed class DatabaseContext : DbContext
{
    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "lasmartDb");
        optionsBuilder.EnableSensitiveDataLogging();
    }
    
    /// <summary>
    /// Комментарии
    /// </summary>
    public DbSet<Comment> Comments { get; set; }
    
    /// <summary>
    /// Точки
    /// </summary>
    public DbSet<Point> Points { get; set; }
}

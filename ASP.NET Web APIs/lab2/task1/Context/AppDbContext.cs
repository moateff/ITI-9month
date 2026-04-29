using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=AppDb;User Id=SA;Password=Passw0rd;TrustServerCertificate=True;");
    }

    public virtual DbSet<Student> Students { get; set; }
}
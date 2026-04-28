using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(
            "Server=localhost,1433;Database=AppDb;User Id=SA;Password=Passw0rd;TrustServerCertificate=True;");
}
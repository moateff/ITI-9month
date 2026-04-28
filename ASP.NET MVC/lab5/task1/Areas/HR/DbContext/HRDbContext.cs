using Microsoft.EntityFrameworkCore;

public class HRDbContext : DbContext
{
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(
            "Server=localhost,1433;Database=HRDb;User Id=SA;Password=Passw0rd;TrustServerCertificate=True;");
}
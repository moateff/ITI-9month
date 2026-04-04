using Microsoft.EntityFrameworkCore;
using App.Model;

namespace App.Context
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(
                "Server=localhost,1433;Database=MyDb;User Id=SA;Password=Passw0rd;TrustServerCertificate=True;");

        public DbSet<Product> Products { get; set; }
    }
}

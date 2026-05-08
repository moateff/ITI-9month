using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using task1.Models;

namespace task1.Context;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { 
    }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
}
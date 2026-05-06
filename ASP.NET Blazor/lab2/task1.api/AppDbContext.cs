using Microsoft.EntityFrameworkCore;
using task1.shared.Models;

namespace task1.api;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Track> Tracks { get; set; }
}
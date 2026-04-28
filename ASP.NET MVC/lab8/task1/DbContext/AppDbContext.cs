using Microsoft.EntityFrameworkCore;
using task1.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Track> Tracks { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<TraineeCourse> TraineeCourses { get; set; }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TraineeCourse>()
            .HasKey(tc => new { tc.TraineeId, tc.CourseId });
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using task1.Models;

namespace task1.Data;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<UserRoom> UserRooms { get; set; }
}

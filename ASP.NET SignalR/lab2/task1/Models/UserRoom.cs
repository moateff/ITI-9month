using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models;

public class UserRoom
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;


    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;


    [ForeignKey(nameof(Room))]
    public Guid RoomId { get; set; }
    public Room Room { get; set; } = null!;
}
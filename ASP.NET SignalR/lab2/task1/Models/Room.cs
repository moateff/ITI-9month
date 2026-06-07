using System.ComponentModel.DataAnnotations;

namespace task1.Models;

public class Room
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;


    public IEnumerable<Message>? Messages { get; set; } = new List<Message>();
    public IEnumerable<UserRoom>? UserRooms { get; set; } = new List<UserRoom>();
}
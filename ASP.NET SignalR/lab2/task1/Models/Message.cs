using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models;

public class Message
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Text { get; set; } = null!;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime SentAt { get; set; } = DateTime.UtcNow;


    [ForeignKey("Room")]
    public Guid? RoomId { get; set; }
    public Room? Room { get; set; }


    [ForeignKey("Sender")]
    public Guid SenderId { get; set; }
    public User Sender { get; set; } = null!;


    public Guid? ReceiverId { get; set; }
    public User? Receiver { get; set; }
}
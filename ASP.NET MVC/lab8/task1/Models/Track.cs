using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models;

[Table("Tracks")]
public class Track 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Description { get; set; }

    public IEnumerable<Trainee>? Trainees { get; set; }
}
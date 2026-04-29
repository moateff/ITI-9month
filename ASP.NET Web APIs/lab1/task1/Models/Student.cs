using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models;

[Table("Students")]
public class Student
{
    [Key]
    public int SSN { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
    public string? Image { get; set; }
    public int Level { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models;

[Table("TraineeCourse")]
public class TraineeCourse
{
    [ForeignKey("Trainee")]
    [Display(Name = "Trainee")]
    public int TraineeId { get; set; }

    [ForeignKey("Course")]
    [Display(Name = "Course")]
    public int CourseId { get; set; }

    [Required]
    [Range(0, 100)]
    public float Grade { get; set; }

    public virtual Trainee? Trainee { get; set; }
    public virtual Course? Course { get; set; }
}

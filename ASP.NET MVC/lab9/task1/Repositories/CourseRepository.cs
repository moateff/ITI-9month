using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Repositories;
public class CourseRepository : GenericRepository<Course>
{
    public CourseRepository(AppDbContext context) : base(context)
    {
    }
}
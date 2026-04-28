using Microsoft.EntityFrameworkCore;
using task1.Models;

public class TraineeCourseRepository : GenericRepository<TraineeCourse>, ITraineeCourseRepository
{ 
    public TraineeCourseRepository(AppDbContext context) : base(context) { }

    public IEnumerable<TraineeCourse> GetAllWithTraineeAndCourse()
    {
        return _dbSet.Include(t => t.Trainee).Include(t => t.Course).ToList();
    }
    public TraineeCourse GetByIdWithTraineeAndCourse(int traineeId, int courseId) 
    {
        return _dbSet.Include(t => t.Trainee).Include(t => t.Course).FirstOrDefault(t => t.TraineeId == traineeId && t.CourseId == courseId);
    }

    public void DeleteByIdWithTraineeAndCourse(int traineeId, int courseId) 
    {
        var entity = _dbSet.Include(t => t.Trainee).Include(t => t.Course).FirstOrDefault(t => t.TraineeId == traineeId && t.CourseId == courseId);
        if (entity == null) return;
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
}
using task1.Models;

public interface ITraineeCourseRepository
{
    IEnumerable<TraineeCourse> GetAllWithTraineeAndCourse();
    TraineeCourse GetByIdWithTraineeAndCourse(int traineeId, int courseId);
    void DeleteByIdWithTraineeAndCourse(int traineeId, int courseId);
}

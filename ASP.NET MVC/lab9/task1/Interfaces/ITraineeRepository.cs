using task1.Models;

public interface ITraineeRepository
{
    IEnumerable<Trainee> GetAllWithTrack();
    Trainee GetByIdWithTrack(int id);
}
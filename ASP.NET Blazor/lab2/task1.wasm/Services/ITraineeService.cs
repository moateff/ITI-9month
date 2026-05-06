using task1.shared.Models;

namespace task1.wasm.Services;

public interface ITraineeService
{
    Task<IEnumerable<Trainee>> GetTrainees();
    Task<Trainee> GetTrainee(int id);
    Task CreateTrainee(Trainee trainee);
    Task UpdateTrainee(int id, Trainee trainee);
    Task DeleteTrainee(int id);
}
using Microsoft.EntityFrameworkCore;
using task1.Models;

public class TraineeRepository : GenericRepository<Trainee>, ITraineeRepository
{
    public TraineeRepository(AppDbContext context) : base(context) { }

    public IEnumerable<Trainee> GetAllWithTrack()
    {
        return _dbSet.Include(t => t.Track).ToList();
    }

    public Trainee GetByIdWithTrack(int id)
    {
        return _dbSet.Include(t => t.Track).FirstOrDefault(t => t.Id == id);
    }

}

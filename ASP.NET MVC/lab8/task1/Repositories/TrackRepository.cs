using Microsoft.EntityFrameworkCore;
using task1.Models;

public class TrackRepository : GenericRepository<Track>, ITrackRepository
{
    public TrackRepository(AppDbContext context) : base(context) { }

    public IEnumerable<Track> GetAllWithTrainees()
    {
        return _dbSet.Include(t => t.Trainees).ToList();
    }

    public Track GetByIdWithTrainees(int id)
    {
        return _dbSet.Include(t => t.Trainees).FirstOrDefault(t => t.Id == id);
    }
}
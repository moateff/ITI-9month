using task1.Models;

public interface ITrackRepository
{
    IEnumerable<Track> GetAllWithTrainees();
    Track GetByIdWithTrainees(int id);
}

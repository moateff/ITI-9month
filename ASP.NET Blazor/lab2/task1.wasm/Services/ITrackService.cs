using task1.shared.Models;

namespace task1.wasm.Services;

public interface ITrackService
{
    Task<IEnumerable<Track>> GetTracks();
    Task<Track> GetTrack(int id);
    Task CreateTrack(Track track);
    Task UpdateTrack(int id, Track track);
    Task DeleteTrack(int id);
}

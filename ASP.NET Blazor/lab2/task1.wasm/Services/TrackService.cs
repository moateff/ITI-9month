using System.Net.Http.Json;
using task1.shared.Models;

namespace task1.wasm.Services;

public class TrackService : ITrackService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _client;

    public TrackService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

        _client = _httpClientFactory.CreateClient("MyApi");
    }

    public async Task<IEnumerable<Track>> GetTracks()
    {
        return await _client.GetFromJsonAsync<IEnumerable<Track>>("api/Tracks");
    }

    public async Task<Track> GetTrack(int id)
    {
        return await _client.GetFromJsonAsync<Track>($"api/Tracks/{id}");
    }

    public async Task CreateTrack(Track track)
    {
        await _client.PostAsJsonAsync("api/Tracks", track);
    }

    public async Task UpdateTrack(int id, Track track)
    {
        await _client.PutAsJsonAsync($"api/Tracks/{id}", track);
    }

    public async Task DeleteTrack(int id)
    {
        await _client.DeleteAsync($"api/Tracks/{id}");
    }
}
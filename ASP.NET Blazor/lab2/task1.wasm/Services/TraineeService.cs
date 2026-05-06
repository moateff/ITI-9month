using System.Net.Http.Json;
using task1.shared.Models;

namespace task1.wasm.Services;

public class TraineeService : ITraineeService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _client;
    public TraineeService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

        _client = _httpClientFactory.CreateClient("MyApi");
    }

    public async Task<IEnumerable<Trainee>> GetTrainees()
    {
        return await _client.GetFromJsonAsync<IEnumerable<Trainee>>("api/Trainees");
    }

    public async Task<Trainee> GetTrainee(int id)
    {
        return await _client.GetFromJsonAsync<Trainee>($"api/Trainees/{id}");
    }

    public async Task CreateTrainee(Trainee trainee)
    {
        await _client.PostAsJsonAsync("api/Trainees", trainee);
    }

    public async Task UpdateTrainee(int id, Trainee trainee)
    {
        await _client.PutAsJsonAsync($"api/Trainees/{id}", trainee);
    }

    public async Task DeleteTrainee(int id)
    {
        await _client.DeleteAsync($"api/Trainees/{id}");
    }
}
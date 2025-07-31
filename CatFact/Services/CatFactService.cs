using CatFactsApp.Interfaces;
using System.Net.Http.Json;

namespace CatFactsApp.Services;

public class CatFactService : ICatFactService
{
    private readonly HttpClient _httpClient;

    public CatFactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetCatFactAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact");
            return response?.Fact ?? "No Data.";
        }
        catch (Exception ex)
        {
            return $"Error downloading fact: {ex.Message}";
        }
    }

    private class CatFact
    {
        public string? Fact { get; set; }
        public int Length { get; set; }
    }
}
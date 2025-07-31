using CatFact.Interfaces;
using CatFact.Models;
using System.Net.Http.Json;

namespace CatFact.Services;

public class CatFactService : ICatFactService
{
    private readonly HttpClient _httpClient;

    public CatFactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFactModel?> GetCatFactAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<CatFactModel>("https://catfact.ninsja/fact");
            return response;
        }
        catch (Exception ex)
        {
            return new CatFactModel { ErrorMessage = ex.Message };
        }
    }
}
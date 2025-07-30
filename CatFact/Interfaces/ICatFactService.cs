namespace CatFactsApp.Interfaces;

public interface ICatFactService
{
    Task<string> GetCatFactAsync();
}
using CatFact.Models;
using System.Threading.Tasks;

namespace CatFact.Interfaces;

public interface ICatFactService
{
    Task<CatFactModel?> GetCatFactAsync();
}
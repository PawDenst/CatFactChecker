using CatFact.Interfaces;
using CatFact.Services;
using CatFact.Models;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static async Task Main()
    {
        var services = new ServiceCollection();
        services.AddHttpClient();
        services.AddTransient<ICatFactService, CatFactService>();

        var serviceProvider = services.BuildServiceProvider();
        var catFactService = serviceProvider.GetRequiredService<ICatFactService>();

        string outputPath = "CatFacts.txt";
        string errorPath = "ErrorLog.txt";

        var fact = await catFactService.GetCatFactAsync();

        if (fact?.ErrorMessage != null)
        {
            await File.AppendAllTextAsync(errorPath, $"{DateTime.Now}: {fact.ErrorMessage}{Environment.NewLine}");
            Console.WriteLine($"Error logged to {errorPath}");
        }
        else
        {
            await File.AppendAllTextAsync(outputPath, $"{fact?.Fact}, Length: {fact?.Length}{Environment.NewLine}");
            Console.WriteLine($"Cat fact saved to {outputPath}");
        }
    }
}
using CatFactsApp.Interfaces;
using CatFactsApp.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient();
services.AddTransient<ICatFactService, CatFactService>();

var serviceProvider = services.BuildServiceProvider();
var catFactService = serviceProvider.GetRequiredService<ICatFactService>();

string outputPath = "CatFacts.txt";
string errorPath = "ErrorLog.txt";

var fact = await catFactService.GetCatFactAsync();

if (fact.StartsWith("Error"))
{
    await File.AppendAllTextAsync(errorPath, $"{DateTime.Now}: {fact}{Environment.NewLine}");
    Console.WriteLine($"Error logged to {errorPath}");
}
else
{
    await File.AppendAllTextAsync(outputPath, fact + Environment.NewLine);
    Console.WriteLine($"Cat fact saved to {outputPath}");
}
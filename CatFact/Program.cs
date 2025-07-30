using CatFactsApp.Interfaces;
using CatFactsApp.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient();
services.AddTransient<ICatFactService, CatFactService>();

var serviceProvider = services.BuildServiceProvider();
var catFactService = serviceProvider.GetRequiredService<ICatFactService>();

string path = "CatFacts.txt";

var fact = await catFactService.GetCatFactAsync();
await File.AppendAllTextAsync(path, fact + Environment.NewLine);
Console.WriteLine($"Cat fact saved to {path}");
// See https://aka.ms/new-console-template for more information
using Bitstamp.LiveOrderBook.BtcUsd.Function.Services.Abstractions;
using Bitstamp.LiveOrderBook.BtcUsd.Function.Services.Concretes;
using Bitstamp.LiveOrderBook.BtcUsd.Function.UseCases.Concretes;
using Bitstamp.LiveOrderBook.Domain.Entities.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false,true)
    .Build();

services.AddSingleton<IConfiguration>(configuration);

services.AddSingleton<ILiveOrderBookBtcUsdService, LiveOrderBookBtcUsdService>();

services.AddTransient<LiveOrderBookBtcUsdUseCase>();

var provider = services.BuildServiceProvider();

var useCase = provider.GetRequiredService<LiveOrderBookBtcUsdUseCase>();

try
{
    await useCase.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine("Erro de execução");
}
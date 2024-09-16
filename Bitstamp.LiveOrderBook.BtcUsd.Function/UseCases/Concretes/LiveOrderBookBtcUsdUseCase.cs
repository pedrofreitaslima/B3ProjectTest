using Bitstamp.LiveOrderBook.BtcUsd.Function.Services.Abstractions;
using Bitstamp.LiveOrderBook.Domain.Constants;
using MongoDB.Bson;

namespace Bitstamp.LiveOrderBook.BtcUsd.Function.UseCases.Concretes;

public class LiveOrderBookBtcUsdUseCase
{
    private readonly ILiveOrderBookBtcUsdService _service;

    public LiveOrderBookBtcUsdUseCase(ILiveOrderBookBtcUsdService service)
    {
        _service = service;
    }
    public async Task RunAsync()
    {
        await Task.CompletedTask;
    }
}
using Bitstamp.LiveOrderBook.Api.Queries.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Bitstamp.LiveOrderBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderBookController : ControllerBase
{
    private readonly ILogger<OrderBookController> _logger;

    public OrderBookController(ILogger<OrderBookController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCurrentPriceUsdForBtc")]
    public IEnumerable<OrderBookResponse> GetCurrentPriceUsdForBtc(string microtimestamp)
    {
        _logger.LogInformation("Get current price USD for BTC");
        var random = new Random();
        return Enumerable.Range(1, 5).Select(index => new OrderBookResponse
            {
                Price = Convert.ToDecimal(random.NextInt64(1,100) + random.NextDouble())
            })
            .ToArray();
    }
    
    [HttpGet(Name = "GetCurrentPriceUsdForEth")]
    public IEnumerable<OrderBookResponse> GetCurrentPriceUsdForEth([FromQuery]string microtimestamp)
    {
        _logger.LogInformation("Get current price USD for BTC");
        var random = new Random();
        return Enumerable.Range(1, 5).Select(index => new OrderBookResponse
            {
                Price = Convert.ToDecimal(random.NextInt64(1,100) + random.NextDouble())
            })
            .ToArray();
    }
}
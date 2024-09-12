namespace Bitstamp.LiveOrderBook.Domain.Tests.Doubles.Fake;

public static class BidsFake
{
    public static IEnumerable<string[]> CreateBids()
    {
        var response = new List<string[]>();
        var random = new Random();
        
        for (int times = 0; times < 100; times++)
        {
            string[] bid = new string[2];
            bid[0] = random.NextInt64(50000,60000).ToString();
            bid[1] = CryptocurrencyValue(random.NextDouble()).ToString("R");
            response.Add(bid);
        }

        return response;
    }

    private static double CryptocurrencyValue(double pointsValue) => 1 + pointsValue;
}
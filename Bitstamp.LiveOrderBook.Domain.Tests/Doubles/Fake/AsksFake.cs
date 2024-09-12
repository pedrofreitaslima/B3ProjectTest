namespace Bitstamp.LiveOrderBook.Domain.Tests.Doubles.Fake;

public static class AsksFake
{
    public static IEnumerable<string[]> CreateAsks()
    {
        var response = new List<string[]>();
        var random = new Random();
        
        for (int times = 0; times < 100; times++)
        {
            string[] ask = new string[2];
            ask[0] = random.NextInt64(50000,60000).ToString();
            ask[1] = CryptocurrencyValue(random.NextDouble()).ToString("R");
            response.Add(ask);
        }

        return response;
    }

    private static double CryptocurrencyValue(double pointsValue) => 1 + pointsValue;
}
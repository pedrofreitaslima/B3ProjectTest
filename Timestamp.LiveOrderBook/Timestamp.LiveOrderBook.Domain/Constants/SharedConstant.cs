namespace Timestamp.LiveOrderBook.Domain.Constants;

public static partial class SharedConstant
{
    public static class WebSocketConfiguration
    {
        public static string ConnectionString = "wss://ws.bitstamp.net/";
        public static string ChannelName = "live_order_book";
        public static string CurrencyPairBtc = "btcusd";
        public static string CurrencyPairEth = "ethusd";
    }
}
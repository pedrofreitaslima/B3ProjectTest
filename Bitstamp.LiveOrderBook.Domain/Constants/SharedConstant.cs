namespace Bitstamp.LiveOrderBook.Domain.Constants;

public static partial class SharedConstant
{
    public static class WebSocketConfiguration
    {
        public static readonly string ConnectionString = "wss://ws.bitstamp.net";
        public static readonly string ChannelName = "order_book";
        public static readonly string CurrencyPairBtcUsd = "btcusd";
        public static readonly string CurrencyPairEthUsd = "ethusd";
    }
}
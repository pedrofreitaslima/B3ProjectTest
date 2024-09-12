namespace Bitstamp.LiveOrderBook.Domain.Constants;

public static partial class MessageConstant
{
    public static class MessageError
    {
        public readonly static string InConnectionWebSocket = $"Error to connect in web socket in connection string: {SharedConstant.WebSocketConfiguration.ConnectionString}";
    }
    
    public static class MessageInfo
    {
        public readonly static string StartProccess = $"Worker service started at: {DateTime.Now}";
    }
}
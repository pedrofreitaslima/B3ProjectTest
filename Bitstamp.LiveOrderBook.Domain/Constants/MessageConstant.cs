namespace Bitstamp.LiveOrderBook.Domain.Constants;

public static partial class MessageConstant
{
    public static class MessageError
    {
        public static string InConnectionWebSocket = $"Error to connect in web socket in connection string: {SharedConstant.WebSocketConfiguration.ConnectionString}";
        public static string InConnectionRabbitMQ = "Error to connect in rabbitmq in connection string:";
        public static string InConnectionKafka = "Error to connect in kafka in connection string:";
        public static string InConnectionMongoDB = "Error to connect in mongodb in connection string:";
        public static string InConnectionDynamoDB = "Error to connect in dynamodb in connection string:";
    }
    
    public static class MessageInfo
    {
        public static string StartProccess = $"Worker started at: {DateTime.Now}";
    }
}
using Bitstamp.LiveOrderBook.Domain.Constants;
using FluentAssertions;

namespace Bitstamp.LiveOrderBook.Domain.Tests.Constants;

public class MessageConstantTest
{
    [Fact(DisplayName = "Validate message error in connection web socket")]
    public void Should_MessageError_InConnectionWebSocket_Validate()
    {
        // Arrange
        string messagePrefix = "Error to connect in web socket in connection string:";
        
        // Act
        var messageValid = MessageConstant.MessageError.InConnectionWebSocket.StartsWith(messagePrefix);

        // Assert
        messageValid.Should().BeTrue();
    }
    
    [Fact(DisplayName = "Validate message error in connection web socket")]
    public void Should_MessageInfo_StartProccess_Validate()
    {
        // Arrange
        string messagePrefix = "Worker service started at:";
    
        // Act
        var messageValid = MessageConstant.MessageInfo.StartProccess.StartsWith(messagePrefix);

        // Assert
        messageValid.Should().BeTrue();
    }
}
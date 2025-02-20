using DesignPatternsLibrary.ChainOfResponsibility;
using DesignPatternsLibrary.ChainOfResponsibility.AlarmMessageHandlers;

namespace DesignPatternLibrary.Tests
{
    public class ChainOfResponsibilityTests
    {
        [Fact]
        public async Task HandleMessageAsync_ForKnownMessage_HandlesAlarmMessage()
        {
            // Arrange
            IMessageHandler chain = new AlarmTriggeredHandler(new DefaultHandler());
            var message = new AlarmMessage();

            // Act
            var result = await chain.HandleMessageAsync(message);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(nameof(AlarmTriggeredHandler), result.HandledBy);
        }

        [Fact]
        public async Task HandleMessageAsync_ForUnknownMessage_DelegatesToDefaultHandler()
        {
            // Arrange
            IMessageHandler chain = new AlarmTriggeredHandler(new DefaultHandler());
            var message = new object();

            // Act
            var result = await chain.HandleMessageAsync(message);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(nameof(DefaultHandler), result.HandledBy);
        }
    }
}

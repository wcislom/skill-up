using DesignPatternsLibrary.ChainOfResponsibility;

namespace DesignPatternLibrary.Tests
{
    public class ChainOfResponsibilityTests
    {
        [Fact]
        public async Task ChainOfResponsibility_Example()
        {
            // Arrange
            IMessageHandler handler = new DefaultHandler();
            var message = new MessageA();

            // Act
            var result = await handler.HandleMessageAsync(message);

            // Assert
            Assert.True(result.Success);
        }
    }
}

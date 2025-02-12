using DesignPatternsLibrary.Decorator;

namespace DesignPatternLibrary.Tests
{
    public class DecoratorTests
    {
        [Fact]
        public async Task Decorator_Example()
        {
            // Arrange
            var decorated = new Component();
            var decoratorA = new DecoratorA(decorated);
            var decoratorB = new DecoratorB(decoratorA);

            // Act
            var result = await decoratorB.Operation();

            // Assert
            Assert.Equal("<DecoratorB><DecoratorA>This comes from component</DecoratorA></DecoratorB>", result);
        }
    }
}

using DesignPatternsLibrary.Decorator;

namespace DesignPatternLibrary.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Decorator_Example()
        {
            // Arrange
            var decorated = new Component();
            var decoratorA = new DecoratorA(decorated);
            var decoratorB = new DecoratorB(decoratorA);

            // Act
            var result = await decoratorB.Operation();

            // Assert
            Assert.Equal("<DecoratorB><DecoratorA><Component>This comes from component</Component></DecoratorA></DecoratorB>", result);
        }
    }
}

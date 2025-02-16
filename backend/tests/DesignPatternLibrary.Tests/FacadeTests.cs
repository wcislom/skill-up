using DesignPatternsLibrary.Facade;

namespace DesignPatternLibrary.Tests
{
    public class FacadeTests
    {
        [Fact]
        public async Task Facade_Example()
        {
            // Arrange
            var ecommerceFacade = FacadeFactory.CreateFacade();
            int productId = 1;
            int quantity = 2;

            // Act
            var result = await ecommerceFacade.PlaceOrder(productId, quantity);

            // Assert
            Assert.True(result);
        }
    }
}

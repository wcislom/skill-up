using DesignPatternsLibrary.OperationResult;

namespace DesignPatternLibrary.Tests
{
    public class FacadeOperationResultTests
    {
        [Fact]
        public async Task OperationResult_Example()
        {
            // Arrange
            int value = 10;

            // Act
            var result = OperationResult<int>.Success(value);
            // no access to Value => result.Value

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}

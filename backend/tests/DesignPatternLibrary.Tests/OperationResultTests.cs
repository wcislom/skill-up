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
            var failure = OperationResult<int>.Fail("Some error");

            // Assert
            Assert.True(result.IsSuccess);
            Assert.False(failure.IsSuccess);
        }
    }
}

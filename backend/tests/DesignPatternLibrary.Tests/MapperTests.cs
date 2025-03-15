using DesignPatternsLibrary.Mappings.Mappers;

namespace DesignPatternLibrary.Tests
{

    public class MapperTests
    {
        [Fact]
        public void MapperlyTest()
        {
            // Arrange
            int value = 1;
            var typeA = new TypeA(value);

            // Act
            var typeB = typeA.Map();

            // Assert
            Assert.Equal(typeA.Value, typeB.Value);
        }
    }
}

using DesignPatternsLibrary.Adapter;

namespace DesignPatternLibrary.Tests
{

    public class AdapterTests
    {
        [Fact]
        public async Task Adapter_Test()
        {
            // Arrange
            var library = new ExternalOcrLib();
            var adapter = new ExternalOcrLibAdapter(library);

            // Act
            var result = await adapter.Read(new MemoryStream([1, 2, 3]));

            // Assert
            Assert.Equal("This is the text extracted from the image", result);
        }
    }
}

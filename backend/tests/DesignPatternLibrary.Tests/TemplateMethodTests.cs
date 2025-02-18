using DesignPatternsLibrary.TemplateMethod;

namespace DesignPatternLibrary.Tests
{
    public class TemplateMethodTests
    {
        [Fact]
        public async Task TemplateMethod_Example()
        {
            // Arrange
            FileProcessor processor = new PdfFileProcessor();

            // Act
            var exception = await Record.ExceptionAsync(() => processor.Process("path"));

            // Assert
            Assert.Null(exception);
        }
    }
}

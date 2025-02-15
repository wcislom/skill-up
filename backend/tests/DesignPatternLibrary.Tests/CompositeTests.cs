using DesignPatternsLibrary.Composite;
using Directory = DesignPatternsLibrary.Composite.Directory;
using File = DesignPatternsLibrary.Composite.File;
namespace DesignPatternLibrary.Tests
{
    public class CompositeTests
    {
        [Fact]
        public async Task Composite_Test()
        {
            // Arrange
            var root = new Directory("root");
            var images = new Directory("images");
            var image1File = new File("image1.jpg");
            var image2File = new File("image2.jpg");
            images.Add(image1File);
            
            root.Add(images);
            root.Add(image2File);

            // Act
            var path1 = image1File.Path;
            var path2 = image2File.Path;

            // Assert
            Assert.Equal("root/images/image1.jpg", path1);
            Assert.Equal("root/image2.jpg", path2);
        }
    }
}

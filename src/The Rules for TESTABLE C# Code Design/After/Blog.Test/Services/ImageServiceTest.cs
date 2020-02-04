namespace Blog.Test.Services
{
    using Blog.Services;
    using Xunit;

    public class ImageServiceTest
    {
        [Fact]
        public void CalculateOptimalSizeShouldReturnMinimumSizeWhenSizeIsLessThanTheAllowedMinimum()
        {
            // Arrange
            const int minimumSize = 100;
            const int originalSize = 200;
            const int resizeSize = 50;

            var imageService = new ImageService();

            // Act
            var (width, height) = imageService
                .CalculateOptimalSize(resizeSize, resizeSize, originalSize, originalSize);

            // Assert
            Assert.Equal(minimumSize, width);
            Assert.Equal(minimumSize, height);
        }
    }
}

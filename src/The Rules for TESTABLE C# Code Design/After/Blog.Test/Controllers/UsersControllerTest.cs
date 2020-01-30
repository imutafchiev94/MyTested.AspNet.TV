namespace Blog.Test.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Blog.Controllers;
    using Extensions;
    using Fakes;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;

    public class UsersControllerTest
    {
        [Fact]
        public async Task ChangeProfilePictureWithNullPictureUrlShouldReturnBadRequest()
        {
            // Arrange
            var usersController = new UsersController(null);

            // Act
            var result = await usersController.ChangeProfilePicture(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Image cannot be empty.", badRequestResult.Value);
        }

        [Fact]
        public async Task ChangeProfilePictureWithNonNullPictureUrlShouldReturnOk()
        {
            // Arrange
            const string pictureUrl = "TestPictureUrl";

            var imageService = new FakeImageService();

            var usersController = new UsersController(imageService)
                .WithTestUser();

            // Act
            var result = await usersController.ChangeProfilePicture(pictureUrl);

            // Assert
            Assert.Equal(pictureUrl, imageService.ImageUrl);
            Assert.Equal(@$"Images\Users\{TestConstants.TestUsername}", imageService.Destination);
            Assert.IsType<OkResult>(result);
        }
    }
}

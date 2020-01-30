namespace Blog.Test.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Blog.Controllers;
    using Blog.Controllers.Models;
    using Extensions;
    using Fakes;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Services.Models;
    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public async Task IndexShouldReturnViewResultWithCorrectArticleModel()
        {
            // Arrange
            var homeController = new HomeController(new FakeArticleService());

            // Act
            var result = await homeController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ArticleListingServiceModel>>(viewResult.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void AboutShouldReturnViewResult()
        {
            // Arrange
            var homeController = new HomeController(null);

            // Act
            var result = homeController.About();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void PrivacyShouldReturnViewResultWithCorrectUsername()
        {
            // Arrange
            var homeController = new HomeController(null)
                .WithTestUser();

            // Act
            var result = homeController.Privacy();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<PrivacyViewModel>(viewResult.Model);
            Assert.Equal(TestConstants.TestUsername, model.Username);
        }
    }
}

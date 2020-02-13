namespace Blog.Test.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Blog.Controllers;
    using Blog.Controllers.Models;
    using Fakes;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Xunit;

    public class ArticlesControllerTest
    {
        [Fact]
        public async Task AllShouldReturnViewWithCorrectModel()
        {
            // Arrange
            const int pageSize = 2;
            var articleService = new FakeArticleService();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new []
                {
                    new KeyValuePair<string, string>("Articles:PageSize", pageSize.ToString())
                })
                .Build();

            var articlesController = new ArticlesController(articleService, null, configuration);

            // Act
            var result = await articlesController.All();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ArticleListingViewModel>(viewResult.Model);
            Assert.Equal(pageSize, model.Articles.Count());
            Assert.Equal(await articleService.Total(), model.Total);
            Assert.Equal(1, model.Page);
        }
    }
}

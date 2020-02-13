namespace Blog.Test.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Blog.Services;
    using Blog.Services.Infrastructure;
    using Data.Models;
    using Fakes;
    using Xunit;

    public class ArticleServiceTest
    {
        [Fact]
        public async Task IsByUserShouldReturnTrueWhenArticleByTheSpecificUserExists()
        {
            // Arrange
            var articleService = await this.GetArticleService("ArticlesIsByUserExists");

            // Act
            var exists = await articleService.IsByUser(1, "1");

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public async Task IsByUserShouldReturnFalseWhenArticleByTheSpecificUserDoesNotExist()
        {
            // Arrange
            var articleService = await this.GetArticleService("ArticlesIsByUserDoesNotExist");

            // Act
            var exists = await articleService.IsByUser(3, "1");

            // Assert
            Assert.False(exists);
        }

        [Fact]
        public async Task AllShouldReturnCorrectArticlesWithDefaultParameters()
        {
            // Arrange
            var articleService = await this.GetArticleService("AllArticlesWithDefaultParameters");

            // Act
            var articles = await articleService.All();

            // Assert
            var article = Assert.Single(articles);
            Assert.NotNull(article);
            Assert.Equal(2, article.Id);
        }

        private async Task<ArticleService> GetArticleService(string databaseName)
        {
            var db = new FakeBlogDbContext(databaseName);

            await this.AddFakeArticles(db);

            var mapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile<ServiceMappingProfile>();
            }));

            return new ArticleService(db.Data, mapper);
        }

        private async Task AddFakeArticles(FakeBlogDbContext fakeDb)
            => await fakeDb.Add(new Article
            {
                Id = 1,
                UserId = "1"
            },
            new Article
            {
                Id = 2,
                UserId = "2",
                IsPublic = true
            });
    }
}

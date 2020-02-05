namespace Blog.Test.Services
{
    using System.Threading.Tasks;
    using Blog.Services;
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

        private async Task<ArticleService> GetArticleService(string databaseName)
        {
            var db = new FakeBlogDbContext(databaseName);

            await this.AddFakeArticles(db);

            return new ArticleService(db.Data);
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
                UserId = "2"
            });
    }
}

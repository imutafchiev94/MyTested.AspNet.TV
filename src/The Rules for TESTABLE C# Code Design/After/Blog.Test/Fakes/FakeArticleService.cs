namespace Blog.Test.Fakes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Blog.Services;
    using Blog.Services.Models;
    using Data.Models;

    public class FakeArticleService : IArticleService
    {
        private readonly List<Article> articlesData = new List<Article>
        {
            new Article { Id = 1 },
            new Article { Id = 2 },
            new Article { Id = 3 },
            new Article { Id = 4 }
        };

        public async Task<IEnumerable<ArticleListingServiceModel>> All(
            int page = 1,
            int pageSize = ServicesConstants.ArticlesPerPage,
            bool publicOnly = true)
        {
            var articles = this.articlesData
                .Select(a => new ArticleListingServiceModel
                {
                    Id = a.Id
                });

            return await Task.FromResult(articles.Take(pageSize));
        }

        public Task<IEnumerable<TModel>> All<TModel>(int page = 1, int pageSize = ServicesConstants.ArticlesPerPage, bool publicOnly = true) where TModel : class
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<int>> AllIds()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ArticleForUserListingServiceModel>> ByUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsByUser(int id, string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ArticleDetailsServiceModel> Details(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Total() => await Task.FromResult(this.articlesData.Count);

        public Task<int> Add(string title, string content, string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task Edit(int id, string title, string content)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task ChangeVisibility(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

namespace Blog.Test.Fakes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Blog.Services;
    using Blog.Services.Models;
    using Services;

    public class FakeArticleService : IArticleService
    {
        public async Task<IEnumerable<ArticleListingServiceModel>> All(
            int page = 1,
            int pageSize = ServicesConstants.ArticlesPerPage,
            bool publicOnly = true)
        {
            var articles = new List<ArticleListingServiceModel>
            {
                new ArticleListingServiceModel {Id = 1},
                new ArticleListingServiceModel {Id = 2},
                new ArticleListingServiceModel {Id = 3},
                new ArticleListingServiceModel {Id = 4}
            };

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

        public Task<int> Total()
        {
            throw new System.NotImplementedException();
        }

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

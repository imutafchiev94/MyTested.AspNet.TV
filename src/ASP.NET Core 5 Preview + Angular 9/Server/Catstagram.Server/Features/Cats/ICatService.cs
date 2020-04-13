namespace Catstagram.Server.Features.Cats
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface ICatService
    {
        public Task<int> Create(string imageUrl, string description, string userId);

        public Task<bool> Update(int id, string description, string userId);

        public Task<bool> Delete(int id, string userId);

        public Task<IEnumerable<CatListingServiceModel>> ByUser(string userId);

        public Task<CatDetailsServiceModel> Details(int id);
    }
}

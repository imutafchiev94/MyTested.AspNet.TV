namespace Catstagram.Server.Features.Cats
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface ICatService
    {
        Task<int> Create(string imageUrl, string description, string userId);

        Task<bool> Update(int id, string description, string userId);

        Task<bool> Delete(int id, string userId);

        Task<IEnumerable<CatListingServiceModel>> ByUser(string userId);

        Task<CatDetailsServiceModel> Details(int id);
    }
}

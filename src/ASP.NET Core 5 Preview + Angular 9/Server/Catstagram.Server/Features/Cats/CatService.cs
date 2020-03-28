namespace Catstagram.Server.Features.Cats
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;

    public class CatService : ICatService
    {
        private readonly CatstagramDbContext data;

        public CatService(CatstagramDbContext data) => this.data = data;

        public async Task<int> Create(string imageUrl, string description, string userId)
        {
            var cat = new Cat
            {
                ImageUrl = imageUrl,
                Description = description,
                UserId = userId
            };

            this.data.Add(cat);

            await this.data.SaveChangesAsync();

            return cat.Id;
        }
    }
}

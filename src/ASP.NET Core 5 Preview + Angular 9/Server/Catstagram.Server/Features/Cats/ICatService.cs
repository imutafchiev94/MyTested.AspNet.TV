namespace Catstagram.Server.Features.Cats
{
    using System.Threading.Tasks;

    public interface ICatService
    {
        public Task<int> Create(string imageUrl, string description, string userId);
    }
}

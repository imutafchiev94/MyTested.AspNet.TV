namespace Catstagram.Server.Features.Follows
{
    using System.Threading.Tasks;
    using Infrastructure.Services;

    public interface IFollowService
    {
        Task<Result> Follow(string userId, string followerId);
    }
}

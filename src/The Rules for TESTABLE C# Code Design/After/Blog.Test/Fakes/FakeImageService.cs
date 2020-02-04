namespace Blog.Test.Fakes
{
    using System.Threading.Tasks;
    using Blog.Services;

    public class FakeImageService : IImageService
    {
        public string ImageUrl { get; private set; }

        public string Destination { get; private set; }

        public Task UpdateImage(
            string imageUrl,
            string destination,
            int? width = null,
            int? height = null)
        {
            this.ImageUrl = imageUrl;
            this.Destination = destination;

            return Task.CompletedTask;
        }
    }
}

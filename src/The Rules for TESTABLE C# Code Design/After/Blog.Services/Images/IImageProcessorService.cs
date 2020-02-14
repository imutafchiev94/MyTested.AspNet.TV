namespace Blog.Services.Images
{
    using System.Threading.Tasks;

    public interface IImageProcessorService
    {
        (int width, int height) GetSizes(string destination);

        Task Resize(string destination, int width, int height);
    }
}

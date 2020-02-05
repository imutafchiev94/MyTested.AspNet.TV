namespace Blog.Services
{
    using System.IO;

    public interface IFileSystemService
    {
        Stream OpenRead(string path);
    }
}

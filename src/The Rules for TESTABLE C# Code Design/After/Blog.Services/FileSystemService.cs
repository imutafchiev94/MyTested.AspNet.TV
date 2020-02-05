namespace Blog.Services
{
    using System.IO;

    public class FileSystemService : IFileSystemService
    {
        public Stream OpenRead(string path) => File.OpenRead(path);
    }
}

namespace Blog.Test.Fakes
{
    using System.IO;
    using System.Text;
    using Blog.Services;

    public class FakeFileSystemService : IFileSystemService
    {
        public Stream OpenRead(string path) 
            => new MemoryStream(Encoding.UTF8.GetBytes(path));
    }
}

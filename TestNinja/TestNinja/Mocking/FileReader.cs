using System.IO;

namespace TestNinja.Mocking
{
    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText("video.txt");
        }
    }

    public interface IFileReader
    {
        string Read(string path);
    }
}

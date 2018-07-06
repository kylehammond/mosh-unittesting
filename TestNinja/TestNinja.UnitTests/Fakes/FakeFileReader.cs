using TestNinja.Mocking;

namespace TestNinja.UnitTests.Fakes
{
    class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return string.Empty;
        }
    }
}

using System.Reflection;

namespace Microsoft.Maui
{
    public class MockFontRegistrar : IFontRegistrar
    {
        public string GetFont(string font)
            => fonts?[font];

        Dictionary<string, string> fonts = new();

        public void Register(string filename, string alias, Assembly assembly)
        {
            fonts[alias ?? filename] = filename;
        }

        public void Register(string filename, string alias)
        {
            fonts[alias ?? filename] = filename;
        }
    }
}
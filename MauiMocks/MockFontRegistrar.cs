using System.Reflection;

namespace Microsoft.Maui
{
    public class MockFontRegistrar : IFontRegistrar
    {
        public string GetFont(string font)
            => this.fonts?[font];

        readonly Dictionary<string, string> fonts = new();

        public void Register(string filename, string alias, Assembly assembly)
        {
            this.fonts[alias ?? filename] = filename;
        }

        public void Register(string filename, string alias)
        {
            this.fonts[alias ?? filename] = filename;
        }
    }
}
using Microsoft.Maui.Handlers;

namespace Microsoft.Maui
{
    public class MockApplicationHandler : ElementHandler<IApplication, object>
    {
        public MockApplicationHandler() : base(Mapper)
        {
        }

        public static IPropertyMapper<IApplication, MockApplicationHandler> Mapper = new PropertyMapper<IApplication, MockApplicationHandler>(ElementMapper);

        protected override object CreatePlatformElement()
        {
            return new object();
        }
    }
}
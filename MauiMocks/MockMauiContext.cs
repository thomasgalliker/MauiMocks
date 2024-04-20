using Microsoft.Maui.Animations;

namespace Microsoft.Maui
{
    public class MockMauiContext : IMauiContext
    {
        public MockMauiContext(params (Type serviceType, object serviceImplementation)[] services)
        {
            Services = new MockServiceProvider(services);
        }

        public IServiceProvider Services { get; }

        public IMauiHandlersFactory Handlers
            => Services.GetService(typeof(IMauiHandlersFactory)) as IMauiHandlersFactory;
    }
}
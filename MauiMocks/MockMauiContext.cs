namespace Microsoft.Maui
{
    public class MockMauiContext : IMauiContext
    {
        public MockMauiContext(params (Type serviceType, object serviceImplementation)[] services)
        {
            this.Services = new MockServiceProvider(services);
        }

        public IServiceProvider Services { get; }

        public IMauiHandlersFactory Handlers
            => this.Services.GetService(typeof(IMauiHandlersFactory)) as IMauiHandlersFactory;
    }
}
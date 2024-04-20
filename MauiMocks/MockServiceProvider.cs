using Microsoft.Maui.Animations;

namespace Microsoft.Maui
{
    public class MockServiceProvider : IServiceProvider
    {
        private readonly Dictionary<Type, object> _services = new();

        public MockServiceProvider(params (Type serviceType, object serviceImplementation)[] services)
        {
            if (services != null)
            {
                foreach (var s in services)
                {
                    _services[s.serviceType] = s.serviceImplementation;
                }
            }

            if (!_services.ContainsKey(typeof(IAnimationManager)))
            {
                _services.Add(typeof(IAnimationManager), new MockAnimationManager(new AsyncTicker()));
            }

            if (!_services.ContainsKey(typeof(IFontRegistrar)))
            {
                _services.Add(typeof(IFontRegistrar), new MockFontRegistrar());
            }

            if (!_services.ContainsKey(typeof(IFontManager)))
            {
                _services.Add(typeof(IFontManager), new MockFontManager());
            }
        }

        public object GetService(Type serviceType)
        {
            return _services?[serviceType];
        }
    }
}
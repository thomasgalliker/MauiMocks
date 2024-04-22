using Microsoft.Maui.Animations;
using Microsoft.Maui.Timers;

namespace Microsoft.Maui
{
    public class MockServiceProvider : IServiceProvider
    {
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        public MockServiceProvider(params (Type serviceType, object serviceImplementation)[] services)
        {
            if (services != null)
            {
                foreach (var s in services)
                {
                    this.services[s.serviceType] = s.serviceImplementation;
                }
            }

            if (!this.services.ContainsKey(typeof(IAnimationManager)))
            {
                this.services.Add(typeof(IAnimationManager), new MockAnimationManager(new SyncTimer()));
            }

            if (!this.services.ContainsKey(typeof(IFontRegistrar)))
            {
                this.services.Add(typeof(IFontRegistrar), new MockFontRegistrar());
            }

            if (!this.services.ContainsKey(typeof(IFontManager)))
            {
                this.services.Add(typeof(IFontManager), new MockFontManager());
            }
        }

        public object GetService(Type serviceType)
        {
            return this.services?[serviceType];
        }
    }
}
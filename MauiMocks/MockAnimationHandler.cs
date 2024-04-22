using Microsoft.Maui.Animations;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Timers;

namespace Microsoft.Maui
{
    // Original source: Microsoft.Maui.Controls.Core.UnitTests.AnimationReadyHandler
    public class MockAnimationHandler : ViewHandler<IView, object>
    {
        public MockAnimationHandler(IAnimationManager animationManager) : base(new PropertyMapper<IView>())
        {
            var services = new (Type, object)[]
            {
                (typeof(IAnimationManager), animationManager)
            };

            this.SetMauiContext(new MockMauiContext(services));
        }

        public MockAnimationHandler() : this(new MockAnimationManager(new SyncTimer()))
        {
        }

        protected override object CreatePlatformView() => new();
    }
}
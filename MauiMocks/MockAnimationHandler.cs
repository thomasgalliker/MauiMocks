using Microsoft.Maui.Animations;
using Microsoft.Maui.Handlers;

namespace Microsoft.Maui
{
    // Original source: Microsoft.Maui.Controls.Core.UnitTests.AnimationReadyHandler
    public class MockAnimationHandler : ViewHandler<IView, object>
    {
        public MockAnimationHandler(IAnimationManager animationManager) : base(new PropertyMapper<IView>())
        {
            this.SetMauiContext(new AnimationEnabledMauiContext(animationManager));
        }

        public MockAnimationHandler() : this(new MockAnimationManager(new AsyncTicker()))
        {
        }

        public IAnimationManager? AnimationManager => ((AnimationEnabledMauiContext?)this.MauiContext)?.AnimationAnimationManager;

        protected override object CreatePlatformView() => new();


    }
}
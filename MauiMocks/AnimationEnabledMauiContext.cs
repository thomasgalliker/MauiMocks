using Microsoft.Maui.Animations;

namespace Microsoft.Maui
{
    public class AnimationEnabledMauiContext(IAnimationManager animationManager) : IMauiContext, IServiceProvider
    {
        public IServiceProvider Services => this;

        public IAnimationManager AnimationAnimationManager { get; } = animationManager;

        IMauiHandlersFactory IMauiContext.Handlers => throw new NotSupportedException();

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IAnimationManager))
            {
                return this.AnimationAnimationManager;
            }
            else if (serviceType == typeof(IDispatcher))
            {
                return new MockDispatcherProvider().GetForCurrentThread();
            }

            throw new NotSupportedException();
        }
    }
}
using Microsoft.Maui.Animations;

namespace Microsoft.Maui
{
    public static class AnimationExtensions
    {
        /// <summary>
        /// Sets a mock animation handler to the given <paramref name="view"/>.
        /// <seealso cref="MockAnimationHandler"/>
        /// </summary>
        /// <param name="view">The view that should use mocked animations.</param>
        /// <param name="animationManager">The animation manager that mocks animations. Default is <see cref="MockAnimationManager"/>.</param>
        public static T UseMockAnimationHandler<T>(this T view, IAnimationManager? animationManager = null) where T : IView
        {
            view.Handler = animationManager == null
                ? new MockAnimationHandler()
                : new MockAnimationHandler(animationManager);

            return view;
        }
    }
}
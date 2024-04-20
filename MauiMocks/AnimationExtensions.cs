namespace Microsoft.Maui
{
    public static class AnimationExtensions
    {
        /// <summary>
        /// Sets a mock animation handler to the given <paramref name="view"/>.
        /// <seealso cref="MockAnimationHandler"/>
        /// </summary>
        public static T UseMockAnimationHandler<T>(this T view) where T : IView
        {
            view.Handler = new MockAnimationHandler();

            return view;
        }
    }
}
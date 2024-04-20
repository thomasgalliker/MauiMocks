namespace Microsoft.Maui
{
    // Original source: https://github.com/dotnet/maui/blob/main/src/Core/tests/UnitTests/TestClasses/DispatcherStub.cs
    public class MockDispatcherProvider : IDispatcherProvider, IDisposable
    {
        private readonly ThreadLocal<IDispatcher?> dispatcherInstance = new ThreadLocal<IDispatcher?>(() =>
            MockDispatcherProviderOptions.SkipDispatcherCreation
                ? null
                : new MockDispatcher(MockDispatcherProviderOptions.IsInvokeRequired, MockDispatcherProviderOptions.InvokeOnMainThread));

        public void Dispose()
        {
            this.dispatcherInstance.Dispose();
        }

        public IDispatcher? GetForCurrentThread()
        {
            var dispatcher = this.dispatcherInstance.Value;

            if (dispatcher == null)
            {
                System.Diagnostics.Debug.WriteLine("WTH");
            }

            return dispatcher;
        }
    }

    public class MockDispatcherProviderOptions
    {
        [ThreadStatic]
        public static bool SkipDispatcherCreation;

        [ThreadStatic]
        public static Func<bool>? IsInvokeRequired;

        [ThreadStatic]
        public static Action<Action>? InvokeOnMainThread;
    }
}
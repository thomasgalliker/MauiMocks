namespace Microsoft.Maui
{
    public class MockDispatcher : IDispatcher
    {
        private readonly Func<bool>? isInvokeRequired;
        private readonly Action<Action>? invokeOnMainThread;

        public MockDispatcher(Func<bool>? isInvokeRequired, Action<Action>? invokeOnMainThread)
        {
            this.isInvokeRequired = isInvokeRequired;
            this.invokeOnMainThread = invokeOnMainThread;

            this.ManagedThreadId = Environment.CurrentManagedThreadId;
        }

        public bool IsDispatchRequired =>
            this.isInvokeRequired?.Invoke() ?? false;

        public int ManagedThreadId { get; }

        public bool Dispatch(Action action)
        {
            if (this.invokeOnMainThread is null)
            {
                action();
            }
            else
            {
                this.invokeOnMainThread.Invoke(action);
            }

            return true;
        }

        public bool DispatchDelayed(TimeSpan delay, Action action)
        {
            Timer? timer = null;

            timer = new Timer(OnTimeout, null, delay, delay);

            return true;

            void OnTimeout(object? state)
            {
                this.Dispatch(action);

                timer?.Dispose();
            }
        }

        public IDispatcherTimer CreateTimer()
        {
            return new MockDispatcherTimer(this);
        }
    }
}
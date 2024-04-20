namespace Microsoft.Maui
{
	public class MockDispatcher : IDispatcher
	{
        private readonly Func<bool>? _isInvokeRequired;
        private readonly Action<Action>? _invokeOnMainThread;

		public MockDispatcher(Func<bool>? isInvokeRequired, Action<Action>? invokeOnMainThread)
		{
			_isInvokeRequired = isInvokeRequired;
			_invokeOnMainThread = invokeOnMainThread;

			ManagedThreadId = Environment.CurrentManagedThreadId;
		}

		public bool IsDispatchRequired =>
			_isInvokeRequired?.Invoke() ?? false;

		public int ManagedThreadId { get; }

		public bool Dispatch(Action action)
		{
			if (_invokeOnMainThread is null)
            {
                action();
            }
            else
            {
                _invokeOnMainThread.Invoke(action);
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
				Dispatch(action);

				timer?.Dispose();
			}
		}

		public IDispatcherTimer CreateTimer()
		{
			return new MockDispatcherTimer(this);
		}
	}
}
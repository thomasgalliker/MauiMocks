namespace Microsoft.Maui
{
    public class MockDispatcherTimer : IDispatcherTimer
    {
        private readonly MockDispatcher _mockDispatcher;

        private Timer? _timer;

        public MockDispatcherTimer(MockDispatcher mockDispatcher)
        {
            _mockDispatcher = mockDispatcher;
        }

        public TimeSpan Interval { get; set; }

        public bool IsRepeating { get; set; }

        public bool IsRunning => _timer != null;

        public event EventHandler? Tick;

        public void Start()
        {
            _timer = new Timer(OnTimeout, null, Interval, IsRepeating ? Interval : Timeout.InfiniteTimeSpan);

            void OnTimeout(object? state)
            {
                _mockDispatcher.Dispatch(() => Tick?.Invoke(this, EventArgs.Empty));
            }
        }

        public void Stop()
        {
            _timer?.Dispose();
            _timer = null;
        }
    }
}
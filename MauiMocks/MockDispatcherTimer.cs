namespace Microsoft.Maui
{
    public class MockDispatcherTimer : IDispatcherTimer
    {
        private readonly MockDispatcher mockDispatcher;

        private Timer? timer;

        public MockDispatcherTimer(MockDispatcher mockDispatcher)
        {
            this.mockDispatcher = mockDispatcher;
        }

        public TimeSpan Interval { get; set; }

        public bool IsRepeating { get; set; }

        public bool IsRunning => this.timer != null;

        public event EventHandler? Tick;

        public void Start()
        {
            this.timer = new Timer(OnTimeout, null, this.Interval, this.IsRepeating ? this.Interval : Timeout.InfiniteTimeSpan);

            void OnTimeout(object? state)
            {
                this.mockDispatcher.Dispatch(() => Tick?.Invoke(this, EventArgs.Empty));
            }
        }

        public void Stop()
        {
            this.timer?.Dispose();
            this.timer = null;
        }
    }
}
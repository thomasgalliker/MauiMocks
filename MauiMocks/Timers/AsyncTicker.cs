using Microsoft.Maui.Animations;

namespace Microsoft.Maui.Timers
{
    public sealed class AsyncTicker : Ticker, IDisposable
    {
        private static readonly TimeSpan Delay = TimeSpan.FromMilliseconds(16);

        private CancellationTokenSource? cancellationTokenSource;

        public override async void Start()
        {
            this.cancellationTokenSource = new CancellationTokenSource();

            while (!this.cancellationTokenSource.IsCancellationRequested)
            {
                this.Fire?.Invoke();

                if (!this.cancellationTokenSource.IsCancellationRequested)
                {
                    await Task.Delay(Delay);
                }
            }
        }

        public override void Stop() => this.cancellationTokenSource?.Cancel();

        public void Dispose()
        {
            this.cancellationTokenSource?.Dispose();
        }
    }
}
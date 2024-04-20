using Microsoft.Maui.Animations;

namespace Microsoft.Maui
{
    public sealed class AsyncTicker : Ticker, IDisposable
    {
        private CancellationTokenSource? cancellationTokenSource;

        public override async void Start()
        {
            this.cancellationTokenSource = new CancellationTokenSource();

            while (!this.cancellationTokenSource.IsCancellationRequested)
            {
                this.Fire?.Invoke();

                if (!this.cancellationTokenSource.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(16));
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
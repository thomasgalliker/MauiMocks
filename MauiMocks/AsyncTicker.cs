using Microsoft.Maui.Animations;

namespace Microsoft.Maui
{
    public sealed class AsyncTicker : Ticker, IDisposable
    {
        private CancellationTokenSource? cancellationTokenSource;

        public override async void Start()
        {
            cancellationTokenSource = new CancellationTokenSource();

            while (!cancellationTokenSource.IsCancellationRequested)
            {
                Fire?.Invoke();

                if (!cancellationTokenSource.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(16));
                }
            }
        }

        public override void Stop() => cancellationTokenSource?.Cancel();

        public void Dispose()
        {
            cancellationTokenSource?.Dispose();
        }
    }
}
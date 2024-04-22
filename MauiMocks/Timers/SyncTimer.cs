using Microsoft.Maui.Animations;

namespace Microsoft.Maui.Timers
{
    public class SyncTimer : Ticker
    {
        private static readonly TimeSpan Delay = TimeSpan.FromMilliseconds(16);

        private bool enabled;

        public override void Start()
        {
            this.enabled = true;

            while (this.enabled)
            {
                this.Fire?.Invoke();
                Task.Delay(Delay).Wait();
            }
        }

        public override void Stop()
        {
            this.enabled = false;
        }
    }
}
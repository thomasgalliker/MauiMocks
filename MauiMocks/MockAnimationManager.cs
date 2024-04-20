using Microsoft.Maui.Animations;

namespace Microsoft.Maui
{
    public class MockAnimationManager : IAnimationManager
    {
        private readonly List<Microsoft.Maui.Animations.Animation> animations = [];

        public MockAnimationManager(ITicker ticker)
        {
            this.Ticker = ticker;
            this.Ticker.Fire = this.OnFire;
        }

        public double SpeedModifier { get; set; } = 1;

        public bool AutoStartTicker { get; set; } = false;

        public ITicker Ticker { get; }

        public void Add(Microsoft.Maui.Animations.Animation animation)
        {
            this.animations.Add(animation);
            if (this.AutoStartTicker && !this.Ticker.IsRunning)
            {
                this.Ticker.Start();
            }
        }

        public void Remove(Microsoft.Maui.Animations.Animation animation)
        {
            this.animations.Remove(animation);
            if (!this.animations.Any())
            {
                this.Ticker.Stop();
            }
        }

        private void OnFire()
        {
            var animations = this.animations.ToList();
            animations.ForEach(AnimationTick);

            if (!this.animations.Any())
            {
                this.Ticker.Stop();
            }

            void AnimationTick(Microsoft.Maui.Animations.Animation animation)
            {
                if (animation.HasFinished)
                {
                    this.animations.Remove(animation);
                    animation.RemoveFromParent();
                    return;
                }

                animation.Tick(16);
                if (animation.HasFinished)
                {
                    this.animations.Remove(animation);
                    animation.RemoveFromParent();
                }
            }
        }
    }
}
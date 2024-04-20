using Microsoft.Maui.Animations;

namespace Microsoft.Maui
{
    public class MockAnimationManager : IAnimationManager
    {
        private readonly List<Microsoft.Maui.Animations.Animation> animations = [];

        public MockAnimationManager(ITicker ticker)
        {
            Ticker = ticker;
            Ticker.Fire = OnFire;
        }

        public double SpeedModifier { get; set; } = 1;

        public bool AutoStartTicker { get; set; } = false;

        public ITicker Ticker { get; }

        public void Add(Microsoft.Maui.Animations.Animation animation)
        {
            animations.Add(animation);
            if (AutoStartTicker && !Ticker.IsRunning)
            {
                Ticker.Start();
            }
        }

        public void Remove(Microsoft.Maui.Animations.Animation animation)
        {
            animations.Remove(animation);
            if (!animations.Any())
            {
                Ticker.Stop();
            }
        }

        private void OnFire()
        {
            var animations = this.animations.ToList();
            animations.ForEach(AnimationTick);

            if (!this.animations.Any())
            {
                Ticker.Stop();
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
namespace Microsoft.Maui
{
    public class MockDeviceDisplay : IDeviceDisplay
    {
        private DisplayInfo mainDisplayInfo = new DisplayInfo(100, 200, 2, DisplayOrientation.Portrait, DisplayRotation.Rotation0);

        public bool KeepScreenOn { get; set; }

        public event EventHandler<DisplayInfoChangedEventArgs>? MainDisplayInfoChanged;

        public DisplayInfo MainDisplayInfo => this.mainDisplayInfo;

        public void UpdateMainDisplayInfo(DisplayInfo displayInfo)
        {
            this.mainDisplayInfo = displayInfo;
            MainDisplayInfoChanged?.Invoke(this, new DisplayInfoChangedEventArgs(displayInfo));
        }

        public void SetMainDisplayOrientation(DisplayOrientation portrait)
        {
            var info = new DisplayInfo(
                this.mainDisplayInfo.Width,
                this.mainDisplayInfo.Height,
                this.mainDisplayInfo.Density,
                portrait,
                this.mainDisplayInfo.Rotation);

            this.UpdateMainDisplayInfo(info);
        }
    }
}
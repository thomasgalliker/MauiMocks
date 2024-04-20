namespace Microsoft.Maui
{
    public class MockDeviceDisplay : IDeviceDisplay
    {
        private DisplayInfo _mainDisplayInfo = new DisplayInfo(100, 200, 2, DisplayOrientation.Portrait, DisplayRotation.Rotation0);

        public bool KeepScreenOn { get; set; }

        public event EventHandler<DisplayInfoChangedEventArgs>? MainDisplayInfoChanged;

        public DisplayInfo MainDisplayInfo => _mainDisplayInfo;

        public void UpdateMainDisplayInfo(DisplayInfo displayInfo)
        {
            _mainDisplayInfo = displayInfo;
            MainDisplayInfoChanged?.Invoke(this, new DisplayInfoChangedEventArgs(displayInfo));
        }

        public void SetMainDisplayOrientation(DisplayOrientation portrait)
        {
            var info = new DisplayInfo(
                _mainDisplayInfo.Width,
                _mainDisplayInfo.Height,
                _mainDisplayInfo.Density,
                portrait,
                _mainDisplayInfo.Rotation);

            UpdateMainDisplayInfo(info);
        }
    }
}
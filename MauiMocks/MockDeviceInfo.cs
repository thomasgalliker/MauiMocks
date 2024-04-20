namespace Microsoft.Maui
{
    public class MockDeviceInfo : IDeviceInfo
    {
        public MockDeviceInfo()
        {
            Platform = DevicePlatform.Unknown;
            Idiom = DeviceIdiom.Unknown;
            DeviceType = DeviceType.Unknown;
        }

        public MockDeviceInfo(DevicePlatform? platform = null, DeviceIdiom? idiom = null, DeviceType? deviceType = null)
        {
            Platform = platform ?? DevicePlatform.Unknown;
            Idiom = idiom ?? DeviceIdiom.Unknown;
            DeviceType = deviceType ?? DeviceType.Unknown;
        }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string Name { get; set; }

        public string VersionString { get; set; }

        public Version Version { get; set; }

        public DevicePlatform Platform { get; set; }

        public DeviceIdiom Idiom { get; set; }

        public DeviceType DeviceType { get; set; }
    }
}
using FluentAssertions;
using Moq;
using Xunit;

namespace Microsoft.Maui.Tests
{
    [Collection("MauiMocks")]
    public class MauiMocksTests
    {
        public MauiMocksTests()
        {
            MauiMocks.DeviceInfo.SetCurrent(null);
        }

        [Fact]
        public void ShouldMockDeviceInfoCurrent_DefaultMockObject()
        {
            // Arrange
            var deviceInfoMock = new Mock<IDeviceInfo>();
            deviceInfoMock.Setup(d => d.DeviceType)
                .Returns(DeviceType.Physical);
            deviceInfoMock.Setup(d => d.Idiom)
                .Returns(DeviceIdiom.TV);

            // Act
            var deviceInfo = DeviceInfo.Current;

            // Assert
            deviceInfo.Should().NotBeNull();
            deviceInfo.DeviceType.Should().Be(DeviceType.Unknown);
            deviceInfo.Idiom.Should().Be(DeviceIdiom.Unknown);
            deviceInfo.Platform.Should().Be(DevicePlatform.Unknown);
        }

        [Fact]
        public void ShouldMockDeviceInfoCurrent_CustomMockObject()
        {
            // Arrange
            var deviceInfoMock = new Mock<IDeviceInfo>();
            deviceInfoMock.Setup(d => d.DeviceType)
                .Returns(DeviceType.Physical);
            deviceInfoMock.Setup(d => d.Idiom)
                .Returns(DeviceIdiom.TV);

            MauiMocks.DeviceInfo.SetCurrent(deviceInfoMock.Object);

            // Act
            var deviceInfo = DeviceInfo.Current;

            // Assert
            deviceInfo.Should().NotBeNull();
            deviceInfo.DeviceType.Should().Be(DeviceType.Physical);
            deviceInfo.Idiom.Should().Be(DeviceIdiom.TV);
        }
    }
}

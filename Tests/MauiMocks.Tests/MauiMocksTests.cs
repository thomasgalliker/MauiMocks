using FluentAssertions;
using Moq;
using Xunit;

namespace Microsoft.Maui.Tests
{
    [Collection("MauiMocks")]
    public class MauiMocksTests : IDisposable
    {
        public MauiMocksTests()
        {
            
        }

        [Fact]
        public void ShouldInitializeOnlyOnce()
        {
            // Act
            MauiMocks.Init();
            MauiMocks.Init();
            MauiMocks.Init();

            // Assert
            MauiMocks.IsInitialized.Should().BeTrue();
        }

        [Fact]
        public void ShouldResetOnlyOnce()
        {
            // Arrange
            MauiMocks.Init();

            // Act
            MauiMocks.Reset();
            MauiMocks.Reset();

            // Assert
            MauiMocks.IsInitialized.Should().BeFalse();
        }

        [Fact]
        public void ShouldGetDeviceInfoCurrent_DefaultMockObject()
        {
            // Arrange
            MauiMocks.Init();

            // Act
            var deviceInfo = DeviceInfo.Current;

            // Assert
            deviceInfo.Should().NotBeNull();
            deviceInfo.DeviceType.Should().Be(DeviceType.Unknown);
            deviceInfo.Idiom.Should().Be(DeviceIdiom.Unknown);
            deviceInfo.Platform.Should().Be(DevicePlatform.Unknown);
        }

        [Fact]
        public void ShouldGetDeviceInfoCurrent_CustomMockObject()
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

        [Fact]
        public void ShoulGeDeviceDisplayCurrent_DefaultMockObject()
        {
            // Arrange
            MauiMocks.Init();

            // Act
            var deviceDisplay = DeviceDisplay.Current;

            // Assert
            deviceDisplay.Should().NotBeNull();
            deviceDisplay.KeepScreenOn.Should().BeFalse();
            deviceDisplay.MainDisplayInfo.Should().NotBeNull();
            deviceDisplay.MainDisplayInfo.Width.Should().Be(100);
            deviceDisplay.MainDisplayInfo.Height.Should().Be(200);
        }

        public void Dispose()
        {
            MauiMocks.Reset();
        }
    }
}

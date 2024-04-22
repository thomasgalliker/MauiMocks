using CommunityToolkit.Maui.Behaviors;
using FluentAssertions;
using Xunit;

namespace Microsoft.Maui.Tests
{
    public class EventToCommandBehaviorTests : IDisposable
    {
        public EventToCommandBehaviorTests()
        {
            MauiMocks.Init();
        }

        [Fact]
        public void ShouldRaiseItemSelectedEvent_IfSelectedItemIsSet()
        {
            // Arrange
            var didEventToCommandBehaviorFire = false;

            var listView = new ListView
            {
                BindingContext = new object(),
                ItemsSource = new[]
                {
                    "Item 1",
                    "Item 2",
                    "Item 3",
                },
                Behaviors =
                {
                    new EventToCommandBehavior
                    {
                        EventName = nameof(ListView.ItemSelected),
                        Command = new Command(() => didEventToCommandBehaviorFire = true)
                    }
                }
            };

            // Act
            listView.SelectedItem = "Item 2";

            // Assert
            didEventToCommandBehaviorFire.Should().BeTrue();
        }

        [Fact]
        public void ShouldUseMockAnimationHandler()
        {
            // Arrange
            var listView = new ListView();

            // Act
            listView.UseMockAnimationHandler();

            // Assert
            listView.Handler.Should().BeOfType<MockAnimationHandler>();
        }

        public void Dispose()
        {
            MauiMocks.Reset();
        }
    }
}
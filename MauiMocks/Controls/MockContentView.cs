namespace Microsoft.Maui.Controls
{

    public class MockContentView : MockContentView<object>
    {
    }

    public class MockContentView<T> : ContentView
    {
        public virtual event EventHandler EventWithoutArgs;

        public void RaiseEventWithoutArgs()
        {
            EventWithoutArgs?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<T> EventWithEventArgs;

        public void RaiseEventWithEventArgs(T eventArgs)
        {
            EventWithEventArgs?.Invoke(this, eventArgs);
        }
    }

}
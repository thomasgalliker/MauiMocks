namespace Microsoft.Maui.Controls
{
    public class MockListView : MockListView<object>
    {
    }

    public class MockListView<T> : ListView
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
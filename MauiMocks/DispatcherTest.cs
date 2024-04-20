namespace Microsoft.Maui
{
    public static class DispatcherTest
    {
        public static Task Run(Action testAction) =>
            Run(() =>
            {
                testAction();
                return Task.CompletedTask;
            });

        public static Task Run(Func<Task> testAction)
        {
            var tcs = new TaskCompletionSource();

            var thread = new Thread(async () =>
            {
                try
                {
                    await testAction();

                    tcs.SetResult();
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });
            thread.Start();

            return tcs.Task;
        }
    }
}
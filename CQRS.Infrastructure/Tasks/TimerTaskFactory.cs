namespace Infrastructure.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public static class TimerTaskFactory
    {
        private static TimeSpan doNotRepeat = TimeSpan.FromMilliseconds(-1);

        public static Task<TResult> StartNew<TResult>(Func<TResult> getResult, Func<TResult, bool> isResultValid, TimeSpan interval, TimeSpan timeout)
        {
            Timer timer = null;
            TaskCompletionSource<TResult> taskCompletionSource = null;
            DateTime expiration = DateTime.UtcNow.Add(timeout);

            timer = new Timer(x =>
            {
                try
                {
                    if (DateTime.UtcNow > expiration)
                    {
                        timer.Dispose();
                        taskCompletionSource.SetResult(default(TResult));
                    }

                    var result = getResult();
                    if (isResultValid(result))
                    {
                        timer.Dispose();
                        taskCompletionSource.SetResult(result);
                    }
                    else
                    {
                        timer.Change(interval, doNotRepeat);
                    }
                }
                catch (Exception ex)
                {
                    timer.Dispose();
                    taskCompletionSource.SetException(ex);
                }
            });

            taskCompletionSource = new TaskCompletionSource<TResult>(timer);

            return taskCompletionSource.Task;
        }
    }
}

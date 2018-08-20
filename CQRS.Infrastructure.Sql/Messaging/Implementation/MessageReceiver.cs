namespace Infrastructure.Sql.Messaging.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class MessageReceiver : IMessageReceiver, IDisposable
    {
        private readonly object lockObject = new object();
        private readonly TimeSpan pollDelay;
        private CancellationTokenSource cancellationSource;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived = (sender, e) => { };

        ~MessageReceiver()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Start()
        {
            lock (this.lockObject)
            {
                if (this.cancellationSource == null)
                {
                    this.cancellationSource = new CancellationTokenSource();
                    Task.Factory.StartNew(
                        () => this.ReceiveMessages(this.cancellationSource.Token),
                        this.cancellationSource.Token,
                        TaskCreationOptions.LongRunning,
                        TaskScheduler.Current);
                }
            }
        }

        public void Stop()
        {
            lock (this.lockObject)
            {
                using (this.cancellationSource)
                {
                    if (this.cancellationSource != null)
                    {
                        this.cancellationSource.Cancel();
                        this.cancellationSource = null;
                    }
                }
            }
        }

        private void ReceiveMessages(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (!this.ReceiveMessage())
                {
                    Thread.Sleep(this.pollDelay);
                }
            }
        }

        protected bool ReceiveMessage()
        {
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            this.Stop();
        }
    }
}

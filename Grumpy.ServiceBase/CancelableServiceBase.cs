using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Grumpy.ServiceBase.Interfaces;

namespace Grumpy.ServiceBase
{
    /// <summary>
    /// Asynchronous Cancelable Base class for services
    /// </summary>
    [SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public abstract class CancelableServiceBase : ICancelableServiceBase
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private Task _task;
        private bool _disposed;

        protected CancelableServiceBase()
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Process - The Process will run in a separate Task/Thread, please check the cancellation periodically to exit gracefully when canceled
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        protected abstract void Process(CancellationToken cancellationToken);

        /// <summary>
        /// Called after the Process has stopped, use this to dispose of objects and close connections etc.
        /// </summary>
        protected virtual void Clean() { }

        /// <summary>
        /// Start the Service
        /// </summary>
        public void Start()
        {
            _task = new TaskFactory(_cancellationTokenSource.Token).StartNew(Process, _cancellationTokenSource.Token);
        }

        /// <summary>
        /// Start the Service
        /// </summary>
        public void StartSync()
        {
            Process();
        }

        /// <summary>
        /// Cancel underlying task and stop the service
        /// </summary>
        public void Stop()
        {
            _cancellationTokenSource?.Cancel();

            if (_task != null)
            {
                try
                {
                    Task.WaitAll(new[] { _task }, 1000000);
                }
                catch (Exception)
                {
                    // ignored
                }

                _task.Dispose();
            }

            Clean();

            _cancellationTokenSource?.Dispose();
        }

        private void Process()
        {
            Process(_cancellationTokenSource.Token);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                if (disposing)
                {
                    Stop();
                    _cancellationTokenSource.Dispose();
                    _task?.Dispose();
                }
            }
        }
    }
}
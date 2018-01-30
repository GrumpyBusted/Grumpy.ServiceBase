using System;
using System.Threading;
using System.Threading.Tasks;
using Grumpy.ServiceBase.Interfaces;
using Grumpy.Logging;
using Microsoft.Extensions.Logging;

namespace Grumpy.ServiceBase
{
    /// <inheritdoc cref="ServiceBase" />
    /// <inheritdoc cref="ICancelableServiceBase" />
    public abstract class CancelableServiceBase : ServiceBase, ICancelableServiceBase
    {
        private bool _disposed;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationTokenRegistration _cancellationTokenRegistration;
        private Task _task;

        /// <inheritdoc />
        public new void Start()
        {
            InternalStart(false, null);
        }

        /// <inheritdoc />
        public void Start(CancellationToken cancellationToken)
        {
            InternalStart(false, cancellationToken);
        }

        /// <inheritdoc />
        public void StartSync()
        {
            InternalStart(true, null);
        }

        /// <inheritdoc />
        public void StartSync(CancellationToken cancellationToken)
        {
            InternalStart(true, cancellationToken);
        }

        private void InternalStart(bool sync, CancellationToken? cancellationToken)
        {
            if (!Started)
            {
                _cancellationTokenSource = new CancellationTokenSource();

                if (cancellationToken != null)
                    _cancellationTokenRegistration = ((CancellationToken)cancellationToken).Register(Cancel);

                if (!sync)
                    _task = new TaskFactory().StartNew(Process, _cancellationTokenSource.Token);

                InternalStart();

                Started = true;

                if (sync)
                    Process(_cancellationTokenSource.Token);
            }
        }

        private void Cancel()
        {
            if (!_cancellationTokenSource?.IsCancellationRequested ?? false)
                _cancellationTokenSource?.Cancel();

            _cancellationTokenRegistration.Dispose();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        /// <inheritdoc />
        protected override void InternalStop()
        {
            Cancel();

            if (_task != null)
            {
                try
                {
                    Logger.LogInformation($"{Name}: Waiting max. 60 seconds for worker task to complete");

                    Task.WaitAll(new[] { _task }, 60000);
                }
                catch (Exception exception)
                {
                    Logger.LogWarning(exception, $"{Name}: Exception waiting for worker Task");
                }

                _task.Dispose();
                _task = null;
            }

            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;

            base.InternalStop();
        }

        /// <summary>
        /// Service Process
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        protected abstract void Process(CancellationToken cancellationToken);

        private void Process()
        {
            Process(_cancellationTokenSource.Token);
        }

        /// <inheritdoc />
        public new void Dispose()
        {
            Dispose(true);
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                base.Dispose(disposing);
            }
        }
    }
}
using Grumpy.Common;
using Grumpy.ServiceBase.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Grumpy.ServiceBase
{
    /// <inheritdoc />
    public abstract class ServiceBase : IServiceBase
    {
        private bool _disposed;

        /// <inheritdoc />
        protected ServiceBase()
        {
            Started = false;
            Logger = NullLogger.Instance;
            Name = new ProcessInformation().ProcessName;
        }

        /// <inheritdoc />
        public bool Started { get; set; }

        /// <inheritdoc />
        public string Name { get; protected set; }

        /// <inheritdoc />
        public ILogger Logger { get; set; }

        /// <inheritdoc />
        public void Start()
        {
            if (Started)
            {
                InternalStart();

                Started = true;
            }
        }

        /// <summary>
        /// Perform actual start
        /// </summary>
        protected void InternalStart()
        {
            Logger.LogInformation($"{Name} service started");
        }

        /// <inheritdoc />
        public void Stop()
        {
            if (Started)
            {
                InternalStop();

                Started = false;
            }
        }

        /// <summary>
        /// Internal stop method
        /// </summary>
        protected virtual void InternalStop()
        {
            Logger.LogInformation($"{Name} service stopped");
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Dispose internal objects
        /// </summary>
        /// <param name="disposing">Disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                if (disposing)
                    Stop();
            }
        }
    }
}
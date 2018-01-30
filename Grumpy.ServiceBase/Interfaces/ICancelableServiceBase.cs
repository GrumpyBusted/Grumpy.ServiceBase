using System.Threading;

namespace Grumpy.ServiceBase.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Base class for implementing a cancelable service
    /// </summary>
    public interface ICancelableServiceBase : IServiceBase
    {
        /// <summary>
        /// Start Service
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        void Start(CancellationToken cancellationToken);

        /// <summary>
        /// Run service in this thread
        /// </summary>
        void StartSync();

        /// <summary>
        /// Run service in this thread
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        void StartSync(CancellationToken cancellationToken);
    }
}
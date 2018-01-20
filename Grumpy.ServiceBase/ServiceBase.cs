using System.Threading;
using Grumpy.ServiceBase.Interfaces;

namespace Grumpy.ServiceBase
{
    /// <inheritdoc cref="ITopshelfService" />
    /// <summary>
    /// Base class for Windows Services
    /// </summary>
    /// <seealso cref="T:Grumpy.ServiceBase.CancelableServiceBase" />
    /// <seealso cref="T:Grumpy.ServiceBase.Interfaces.ITopshelfService" />
    public abstract class ServiceBase : CancelableServiceBase, ITopshelfService
    {
        /// <inheritdoc />
        protected abstract override void Process(CancellationToken cancellationToken);
    }
}

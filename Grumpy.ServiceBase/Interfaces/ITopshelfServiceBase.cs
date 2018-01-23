using Topshelf.Runtime;

namespace Grumpy.ServiceBase.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Topshelf Service Base Class
    /// </summary>
    public interface ITopshelfServiceBase : ICancelableServiceBase
    {
        /// <summary>
        /// Service Name
        /// </summary>
        string ServiceName { get; }
        
        /// <summary>
        /// Instance Name
        /// </summary>
        string InstanceName { get; }

        /// <summary>
        /// Set Service Settings
        /// </summary>
        /// <param name="hostSettings"></param>
        void Set(HostSettings hostSettings);
    }
}
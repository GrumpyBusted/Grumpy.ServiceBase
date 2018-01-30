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
        /// Topshelf Host Settings
        /// </summary>
        HostSettings HostSettings { set; }
    }
}
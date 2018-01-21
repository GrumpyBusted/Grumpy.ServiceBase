namespace Grumpy.ServiceBase.Interfaces
{
    /// <summary>
    /// Abstract Interface for Topshelf Service 
    /// </summary>
    public interface ITopshelfService
    {
        /// <summary>
        /// Start Service
        /// </summary>
        void Start();

        /// <summary>
        /// Stop Service
        /// </summary>
        void Stop();
    }
}
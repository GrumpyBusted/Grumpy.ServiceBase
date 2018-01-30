using System.Threading;
using Microsoft.Extensions.Logging;

namespace Grumpy.ServiceBase.Tester
{
    internal class MyCore 
    {
        private readonly ILogger _logger;

        public MyCore(ILogger logger)
        {
            _logger = logger;
        }

        public void Start(CancellationToken cancellationToken)
        {
            _logger.LogInformation("MyCore Started!");
        }

        public void Stop()
        {
            _logger.LogInformation("MyCore Stopped!");
        }
    }
}
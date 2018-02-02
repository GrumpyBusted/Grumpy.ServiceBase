using System.Threading;
using Grumpy.Logging;
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
            _logger.Information("MyCore Started!");
        }

        public void Stop()
        {
            _logger.Information("MyCore Stopped!");
        }
    }
}
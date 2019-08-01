using System;
using System.Threading;
using Microsoft.Extensions.Logging.Console;

namespace Grumpy.ServiceBase.Tester
{
    internal sealed class MyService : TopshelfServiceBase, IDisposable
    {
        private bool _disposed;
        private readonly MyCore _myCore;

        public MyService()
        {
            Logger = new ConsoleLogger("Hej", (s, level) => true, true);

            _myCore = new MyCore(Logger);
        }

        protected override void Process(CancellationToken cancellationToken)
        {
            _myCore.Start(cancellationToken);
        }

        public new void Dispose()
        {
            Dispose(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                if (disposing)
                    _myCore.Stop();

                base.Dispose(disposing);
            }
        }
    }
}
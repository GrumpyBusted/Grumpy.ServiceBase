using Grumpy.ServiceBase.UnitTests.Helper;
using Xunit;

namespace Grumpy.ServiceBase.UnitTests
{
    public class ServiceBaseTests
    {
        [Fact]
        public void CanCreate()
        {
            var cut = new MyService();

            cut.Start();
            cut.Stop();
        }
    }
}
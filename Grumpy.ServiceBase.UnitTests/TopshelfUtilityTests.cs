using Grumpy.ServiceBase.UnitTests.Helper;
using Xunit;

namespace Grumpy.ServiceBase.UnitTests
{
    public class TopshelfUtilityTests
    {
        [Fact]
        public void CanCreate()
        {
            TopshelfUtility.BuildService(Build);
        }

        private static MyService Build(string serviceName)
        {
            return null;
        }

        [Fact]
        public void CanCreate_Without_ServiceName()
        {
            TopshelfUtility.BuildService(BuildA);
        }

        private static MyService BuildA()
        {
            return null;
        }
    }
}
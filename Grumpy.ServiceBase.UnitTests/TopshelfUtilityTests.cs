using Grumpy.ServiceBase.UnitTests.Helper;
using Topshelf;
using Xunit;

namespace Grumpy.ServiceBase.UnitTests
{
    public class TopshelfUtilityTests
    {
        [Fact]
        public void CanRunService()
        {
            TopshelfUtility.Run<MyTopshelfService>();
        }
    }
}
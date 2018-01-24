[![Build status](https://ci.appveyor.com/api/projects/status/lxxiqar47aqo62db?svg=true)](https://ci.appveyor.com/project/GrumpyBusted/grumpy-servicebase)
[![codecov](https://codecov.io/gh/GrumpyBusted/Grumpy.ServiceBase/branch/master/graph/badge.svg)](https://codecov.io/gh/GrumpyBusted/Grumpy.ServiceBase)
[![nuget](https://img.shields.io/nuget/v/Grumpy.ServiceBase.svg)](https://www.nuget.org/packages/Grumpy.ServiceBase/)
[![downloads](https://img.shields.io/nuget/dt/Grumpy.ServiceBase.svg)](https://www.nuget.org/packages/Grumpy.ServiceBase/)

# Grumpy.WindowsService
Base class for building Windows Services, using Topshelf as a Service Host. This base class simplify building
cancelable windows services.

```csharp
public static class Program
{
    private static void Main()
    {
        // One line main procedure
        TopshelfUtility.Run<MyService>();
    }
}

// Sample Service
public class MyService : TopshelfServiceBase
{
    protected override void Process(CancellationToken cancellationToken)
    {
        // Start your service
    }

    protected override void Clean()
    {
        // Clean up when services is stopped
    }
}
```

// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DotNetty.Tests.Common
{
  using DotNetty.Common.Internal.Logging;
  using Xunit.Abstractions;

  public abstract class TestBase
  {
    static bool loggerInited;
    protected readonly ITestOutputHelper Output;

    protected TestBase(ITestOutputHelper output)
    {
      this.Output = output;
      lock(typeof(TestBase))
      {
          if (!loggerInited)
          {
              InternalLoggerFactory.DefaultFactory.AddProvider(new XUnitOutputLoggerProvider(output));
              loggerInited = true;
          }
      }
    }
  }
}
using System;
using Xunit;
using Shouldly;

namespace tdd_demo.tests
{
    public class WatcherTests
    {
        [Fact]
        public void Test1()
        {
            1.ShouldBe(2);
        }
    }
}

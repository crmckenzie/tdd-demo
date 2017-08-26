using System;
using Xunit;
using Shouldly;
using NSubstitute;

namespace tdd_demo.tests
{
    public class WatcherTests
    {
        private Watcher watcher;

        public WatcherTests()
        {
            this.watcher = Substitute.ForPartsOf<Watcher>();
        }        

        [Fact]
        public void IsImplementationFile_WhenIsAnImplementationFile()
        {
            watcher.IsImplementationFile("Impl.cs").ShouldBe(true);
        }

        [Fact]
        public void IsImplementationFile_WhenIsATestFile()
        {
            watcher.IsImplementationFile("Impl.Tests.cs").ShouldBe(false);
        }

        [Fact]
        public void FindAssociatedTestFile() 
        {
            watcher.FindAssociatedTestFile("Impl.cs").ShouldBe("Impl.Tests.cs");
        }

        [Fact]
        public void OnFileChanged_WhenImplementationFileChanged()
        {
            // Given
            watcher.FindAssociatedTestFile("Impl.cs").Returns("Impl.Tests.cs");

            // When
            watcher.OnFileChanged("Impl.cs");

            // Then
            watcher.Received().RunTests("Impl.Tests.cs");
        }

        [Fact]
        public void OnFileChanged_WhenTestFileChanged()
        {
            // When
            watcher.OnFileChanged("Impl.Tests.cs");

            // Then
            watcher.Received().RunTests("Impl.Tests.cs");        }
    }
}

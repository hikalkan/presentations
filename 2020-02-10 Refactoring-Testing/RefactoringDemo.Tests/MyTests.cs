using Shouldly;
using Xunit;

namespace RefactoringDemo.Tests
{
    public class MyTests
    {
        [Fact]
        public void TestMe()
        {
            "1".ShouldBe("1");
        }
    }
}

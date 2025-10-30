using Developer.ExtensionCore;
using FluentAssertions;

namespace Developer.TestProject
{
    [TestClass]
    public class TimeSpanExtensionTest
    {
        [TestMethod]
        public void Test_ToTimeSpan()
        {
            DateTime val = new(2023, 06, 01, 15, 45, 25);
            TimeSpan expected = new(15, 45, 25);
            val.ToTimeSpan().Should().Be(expected);
        }
    }
}

using Developer.ExtensionCore;
using FluentAssertions;

namespace Developer.TestProject
{
    [TestClass]
    public class GuidExtensionTest
    {
        private readonly Guid _expected = new("3cd0a22e-94e3-4802-85fd-4c89988f5e2d");

        [TestMethod]
        public void Test_ToGuid()
        {
            "3cd0a22e-94e3-4802-85fd-4c89988f5e2d".ToGuid().Should().Be(_expected);
        }

        [TestMethod]
        public void Test_ToGuidNull()
        {
            "3cd0a22e-94e3-4802-85fd-4c89988f5e2d".ToGuidNull().Should().Be(_expected);

            string? nullValue = null;
            nullValue.ToGuidNull().Should().BeNull();
        }
    }
}

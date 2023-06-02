using Developer.ExtensionCore;

namespace Developer.TestProject
{
    [TestClass]
    public class TimeSpanExtensionTest
    {
        [TestMethod]
        public void Test_ToTimeSpan()
        {
            DateTime val = new(2023, 06, 01, 15, 45, 25);
            TimeSpan actual = val.ToTimeSpan();
            TimeSpan expected = new(15, 45, 25);
            Assert.AreEqual(expected, actual);
        }

    }
}

using Developer.ExtensionCore;

namespace Developer.TestProject
{
    [TestClass]
    public class GuidExtensionTest
    {
        private Guid _expected;

        public GuidExtensionTest()
        {
            _expected = new Guid("3cd0a22e-94e3-4802-85fd-4c89988f5e2d");
        }

        [TestMethod]
        public void Test_ToGuid()
        {
            string value = "3cd0a22e-94e3-4802-85fd-4c89988f5e2d";
            Guid result = value.ToGuid();
            Assert.AreEqual(_expected, result);
        }

        [TestMethod]
        public void Test_ToGuidNull()
        {
            string value = "3cd0a22e-94e3-4802-85fd-4c89988f5e2d";
            Guid? result = value.ToGuidNull();
            Assert.AreEqual(_expected, result);

            value = null;
            result = value.ToGuidNull();
            Assert.AreEqual(null, result);
        }
    }
}

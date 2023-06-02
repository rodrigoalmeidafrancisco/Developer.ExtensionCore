using Developer.ExtensionCore;
using Developer.ExtensionCore.Enums;
using System.Globalization;

namespace Developer.TestProject
{
    [TestClass]
    public class LongExtensionTest
    {
        [TestMethod]
        public void Test_ToLong()
        {
            string value = "1500";
            long result = value.ToLong();
            long expected = 1500;
            Assert.AreEqual(expected, result);

            result = value.ToLong(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(expected, result);

            result = value.ToLong(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(expected, result);

            result = EnumCultureInfo.Portuguese_Brazil.ToLong();
            Assert.AreEqual(429, result);
        }

        [TestMethod]
        public void Test_ToLongNull()
        {
            string value = "1500";
            long? result = value.ToLongNull();
            long? expected = 1500;
            Assert.AreEqual(expected, result);

            result = value.ToLongNull(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(expected, result);

            result = value.ToLongNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(expected, result);

            result = EnumCultureInfo.Portuguese_Brazil.ToLongNull();
            Assert.AreEqual(429, result);

            value = null;
            result = value.ToLongNull();
            Assert.AreEqual(null, result);

            result = value.ToLongNull(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(null, result);

            result = value.ToLongNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(null, result);

            EnumCultureInfo? cultureInfo = null;
            result = cultureInfo.ToLongNull();
            Assert.AreEqual(null, result);
        }

    }
}

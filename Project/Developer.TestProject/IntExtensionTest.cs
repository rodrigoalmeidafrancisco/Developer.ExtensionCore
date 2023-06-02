using Developer.ExtensionCore;
using Developer.ExtensionCore.Enums;
using System.Globalization;

namespace Developer.TestProject
{
    [TestClass]
    public class IntExtensionTest
    {
        [TestMethod]
        public void Test_ToInt()
        {
            string value = "1500";
            int result = value.ToInt();
            int expected = 1500;
            Assert.AreEqual(expected, result);

            result = value.ToInt(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(expected, result);

            result = value.ToInt(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(expected, result);

            result = EnumCultureInfo.Portuguese_Brazil.ToInt();
            Assert.AreEqual(429, result);
        }

        [TestMethod]
        public void Test_ToIntNull()
        {
            string value = "1500";
            int? result = value.ToIntNull();
            int? expected = 1500;
            Assert.AreEqual(expected, result);

            result = value.ToIntNull(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(expected, result);

            result = value.ToIntNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(expected, result);

            result = EnumCultureInfo.Portuguese_Brazil.ToIntNull();
            Assert.AreEqual(429, result);

            value = null;
            result = value.ToIntNull();
            Assert.AreEqual(null, result);

            result = value.ToIntNull(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(null, result);

            result = value.ToIntNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(null, result);

            EnumCultureInfo? cultureInfo = null;
            result = cultureInfo.ToIntNull();
            Assert.AreEqual(null, result);
        }

    }
}

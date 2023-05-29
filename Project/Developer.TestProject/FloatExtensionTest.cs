using Developer.ExtensionCore;
using Developer.ExtensionCore.Enums;
using System.Globalization;

namespace Developer.TestProject
{
    [TestClass]
    public class FloatExtensionTest
    {
        [TestMethod]
        public void Test_ToDouble()
        {
            string value = "14.500,00";
            float result = value.ToFloat();
            float expected = 14500;
            Assert.AreEqual(expected, result);

            result = value.ToFloat(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(expected, result);

            result = value.ToFloat(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_ToDoubleNull()
        {
            string value = "14.500,00";
            float? result = value.ToFloatNull();
            float? expected = 14500;
            Assert.AreEqual(expected, result);

            result = value.ToFloatNull(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(expected, result);

            result = value.ToFloatNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(expected, result);

            value = null;
            result = value.ToFloatNull();
            Assert.AreEqual(null, result);

            result = value.ToFloatNull(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(null, result);

            result = value.ToFloatNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(null, result);
        }
    }
}

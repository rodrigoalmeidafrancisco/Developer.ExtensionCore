using Developer.ExtensionCore;
using Developer.ExtensionCore.Enums;
using System.Globalization;

namespace Developer.TestProject
{
    [TestClass]
    public class DoubleExtensionTest
    {
        [TestMethod]
        public void Test_ToDouble()
        {
            string value = "14.500,00";
            double result = value.ToDouble();
            double expected = 14500;
            Assert.AreEqual(expected, result);

            result = value.ToDouble(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(expected, result);

            result = value.ToDouble(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_ToDoubleNull()
        {
            string value = "14.500,00";
            double? result = value.ToDoubleNull();
            double? expected = 14500;
            Assert.AreEqual(expected, result);

            result = value.ToDoubleNull(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(expected, result);

            result = value.ToDoubleNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(expected, result);

            value = null;
            result = value.ToDoubleNull();
            Assert.AreEqual(null, result);

            result = value.ToDoubleNull(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(null, result);

            result = value.ToDoubleNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(null, result);
        }

    }
}

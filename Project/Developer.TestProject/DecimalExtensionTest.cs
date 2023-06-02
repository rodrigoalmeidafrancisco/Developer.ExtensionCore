using Developer.ExtensionCore;
using Developer.ExtensionCore.Enums;
using System.Globalization;

namespace Developer.TestProject
{
    [TestClass]
    public class DecimalExtensionTest
    {
        [TestMethod]
        public void Test_ToDecimal()
        {
            string value = "14.500,00";
            decimal result = value.ToDecimal();
            decimal expected = 14500.00M;   
            Assert.AreEqual(expected, result);

            result = value.ToDecimal(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(expected, result);

            result = value.ToDecimal(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_ToDecimalNull()
        {
            string value = "14.500,00";
            decimal? result = value.ToDecimalNull();
            decimal? expected = 14500.00M;
            Assert.AreEqual(expected, result);

            result = value.ToDecimalNull(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(expected, result);

            result = value.ToDecimalNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(expected, result);

            value = null;
            result = value.ToDecimalNull();
            Assert.AreEqual(null, result);

            result = value.ToDecimalNull(NumberStyles.Number, "pt-BR");
            Assert.AreEqual(null, result);

            result = value.ToDecimalNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(null, result);
        }

    }
}

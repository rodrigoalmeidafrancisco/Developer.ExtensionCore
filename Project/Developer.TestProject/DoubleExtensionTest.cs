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
            "14.500,00".ToDouble().Should().Be(14500);
            "14.500,00".ToDouble(NumberStyles.Number, "pt-BR").Should().Be(14500);
            "14.500,00".ToDouble(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().Be(14500);
        }

        [TestMethod]
        public void Test_ToDoubleNull()
        {
            "14.500,00".ToDoubleNull().Should().Be(14500);
            "14.500,00".ToDoubleNull(NumberStyles.Number, "pt-BR").Should().Be(14500);
            "14.500,00".ToDoubleNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().Be(14500);

            string? nullValue = null;
            nullValue.ToDoubleNull().Should().BeNull();
            nullValue.ToDoubleNull(NumberStyles.Number, "pt-BR").Should().BeNull();
            nullValue.ToDoubleNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().BeNull();
        }
    }
}

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
            "14.500,00".ToDecimal().Should().Be(14500.00M);
            "14.500,00".ToDecimal(NumberStyles.Number, "pt-BR").Should().Be(14500.00M);
            "14.500,00".ToDecimal(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().Be(14500.00M);
        }

        [TestMethod]
        public void Test_ToDecimalNull()
        {
            "14.500,00".ToDecimalNull().Should().Be(14500.00M);
            "14.500,00".ToDecimalNull(NumberStyles.Number, "pt-BR").Should().Be(14500.00M);
            "14.500,00".ToDecimalNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().Be(14500.00M);

            string? nullValue = null;
            nullValue.ToDecimalNull().Should().BeNull();
            nullValue.ToDecimalNull(NumberStyles.Number, "pt-BR").Should().BeNull();
            nullValue.ToDecimalNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().BeNull();
        }
    }
}

using Developer.ExtensionCore;
using Developer.ExtensionCore.Enums;
using System.Globalization;

namespace Developer.TestProject
{
    [TestClass]
    public class FloatExtensionTest
    {
        [TestMethod]
        public void Test_ToFloat()
        {
            "14.500,00".ToFloat().Should().Be(14500);
            "14.500,00".ToFloat(NumberStyles.Number, "pt-BR").Should().Be(14500);
            "14.500,00".ToFloat(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().Be(14500);
        }

        [TestMethod]
        public void Test_ToFloatNull()
        {
            "14.500,00".ToFloatNull().Should().Be(14500);
            "14.500,00".ToFloatNull(NumberStyles.Number, "pt-BR").Should().Be(14500);
            "14.500,00".ToFloatNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().Be(14500);

            string? nullValue = null;
            nullValue.ToFloatNull().Should().BeNull();
            nullValue.ToFloatNull(NumberStyles.Number, "pt-BR").Should().BeNull();
            nullValue.ToFloatNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().BeNull();
        }
    }
}

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
            "1500".ToInt().Should().Be(1500);
            "1500".ToInt(NumberStyles.Number, "pt-BR").Should().Be(1500);
            "1500".ToInt(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().Be(1500);
            EnumCultureInfo.Portuguese_Brazil.ToInt().Should().Be(429);
        }

        [TestMethod]
        public void Test_ToIntNull()
        {
            "1500".ToIntNull().Should().Be(1500);
            "1500".ToIntNull(NumberStyles.Number, "pt-BR").Should().Be(1500);
            "1500".ToIntNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().Be(1500);
            EnumCultureInfo.Portuguese_Brazil.ToIntNull().Should().Be(429);

            string? nullValue = null;
            nullValue.ToIntNull().Should().BeNull();
            nullValue.ToIntNull(NumberStyles.Number, "pt-BR").Should().BeNull();
            nullValue.ToIntNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().BeNull();

            EnumCultureInfo? cultureInfo = null;
            cultureInfo.ToIntNull().Should().BeNull();
        }
    }
}

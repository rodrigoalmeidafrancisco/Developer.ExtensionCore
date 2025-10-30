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
            "1500".ToLong().Should().Be(1500);
            "1500".ToLong(NumberStyles.Number, "pt-BR").Should().Be(1500);
            "1500".ToLong(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().Be(1500);
            EnumCultureInfo.Portuguese_Brazil.ToLong().Should().Be(429);
        }

        [TestMethod]
        public void Test_ToLongNull()
        {
            "1500".ToLongNull().Should().Be(1500);
            "1500".ToLongNull(NumberStyles.Number, "pt-BR").Should().Be(1500);
            "1500".ToLongNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().Be(1500);
            EnumCultureInfo.Portuguese_Brazil.ToLongNull().Should().Be(429);

            string? nullValue = null;
            nullValue.ToLongNull().Should().BeNull();
            nullValue.ToLongNull(NumberStyles.Number, "pt-BR").Should().BeNull();
            nullValue.ToLongNull(NumberStyles.Number, EnumCultureInfo.Portuguese_Brazil).Should().BeNull();

            EnumCultureInfo? cultureInfo = null;
            cultureInfo.ToLongNull().Should().BeNull();
        }
    }
}

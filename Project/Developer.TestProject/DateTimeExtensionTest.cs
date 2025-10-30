using Developer.ExtensionCore;
using Developer.ExtensionCore.Enums;

namespace Developer.TestProject
{
    [TestClass]
    public class DateTimeExtensionTest
    {
        [TestMethod]
        public void Test_ToDateTime()
        {
            "May 22, 2023".ToDateTime("pt-BR").Should().Be(new DateTime(2023, 05, 22));
            "22/05/2023".ToDateTime().Should().Be(new DateTime(2023, 05, 22));
            "22/05/2023".ToDateTime("pt-BR").Should().Be(new DateTime(2023, 05, 22));
            "22/05/2023".ToDateTime(EnumCultureInfo.Portuguese_Brazil.GetDescription()).Should().Be(new DateTime(2023, 05, 22));
            "22/05/2023".ToDateTime(EnumCultureInfo.Portuguese_Brazil).Should().Be(new DateTime(2023, 05, 22));
            "22/05/2023".ToDateTime(EnumCultureInfo.German_Germany).Should().Be(new DateTime(2023, 05, 22));
        }

        [TestMethod]
        public void Test_ToDateTimeNull()
        {
            "May 22, 2023".ToDateTimeNull("pt-BR").Should().Be(new DateTime(2023, 05, 22));
            "22/05/2023".ToDateTimeNull("").Should().Be(new DateTime(2023, 05, 22));
            "22/05/2023".ToDateTimeNull("pt-BR").Should().Be(new DateTime(2023, 05, 22));
            "22/05/2023".ToDateTimeNull(EnumCultureInfo.Portuguese_Brazil.GetDescription()).Should().Be(new DateTime(2023, 05, 22));
            "22/05/2023".ToDateTimeNull(EnumCultureInfo.Portuguese_Brazil).Should().Be(new DateTime(2023, 05, 22));
            "22/05/2023".ToDateTimeNull(EnumCultureInfo.German_Germany).Should().Be(new DateTime(2023, 05, 22));

            string? nullValue = null;
            nullValue.ToDateTimeNull(EnumCultureInfo.German_Germany).Should().BeNull();
        }

        [TestMethod]
        public void Test_ToDateTimeDayEnd()
        {
            DateTime value = new(2023, 05, 22, 10, 00, 00);
            DateTime expected = new(2023, 05, 22, 23, 59, 59, 999);
            value.ToDateTimeDayEnd().Should().Be(expected);
        }
    }
}

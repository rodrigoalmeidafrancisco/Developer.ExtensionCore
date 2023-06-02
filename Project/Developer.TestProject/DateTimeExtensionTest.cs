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
            string value = "May 22, 2023";
            DateTime result = value.ToDateTime("pt-BR");
            Assert.AreEqual(new DateTime(2023, 05, 22), result);

            value = "22/05/2023";
            result = value.ToDateTime();
            Assert.AreEqual(new DateTime(2023, 05, 22), result);
            
            result = value.ToDateTime("pt-BR");
            Assert.AreEqual(new DateTime(2023, 05, 22), result);

            result = value.ToDateTime(EnumCultureInfo.Portuguese_Brazil.GetDescription());
            Assert.AreEqual(new DateTime(2023, 05, 22), result);

            result = value.ToDateTime(EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(new DateTime(2023, 05, 22), result);

            result = value.ToDateTime(EnumCultureInfo.German_Germany);
            Assert.AreEqual(new DateTime(2023, 05, 22), result);
        }

        [TestMethod]
        public void Test_ToDateTimeNull()
        {
            string value = "May 22, 2023";
            DateTime? result = value.ToDateTimeNull("pt-BR");
            Assert.AreEqual(new DateTime(2023, 05, 22), result);

            value = "22/05/2023";
            result = value.ToDateTimeNull("");
            Assert.AreEqual(new DateTime(2023, 05, 22), result);

            result = value.ToDateTimeNull("pt-BR");
            Assert.AreEqual(new DateTime(2023, 05, 22), result);

            result = value.ToDateTimeNull(EnumCultureInfo.Portuguese_Brazil.GetDescription());
            Assert.AreEqual(new DateTime(2023, 05, 22), result);

            result = value.ToDateTimeNull(EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual(new DateTime(2023, 05, 22), result);

            result = value.ToDateTimeNull(EnumCultureInfo.German_Germany);
            Assert.AreEqual(new DateTime(2023, 05, 22), result);

            value = null;
            result = value.ToDateTimeNull(EnumCultureInfo.German_Germany);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Test_ToDateTimeDayEnd()
        {
            DateTime value = new(2023, 05, 22, 10, 00, 00);
            DateTime result = value.ToDateTimeDayEnd();
            DateTime expected = new DateTime(2023, 05, 22, 23, 59, 59, 999);
            Assert.AreEqual(expected, result);
        }

    }
}

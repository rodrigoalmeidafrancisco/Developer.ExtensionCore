using Developer.ExtensionCore;
using Developer.ExtensionCore.Enums;
using System.Diagnostics;

namespace Developer.TestProject
{
    [TestClass]
    public class StringExtensionTest
    {
        [TestMethod]
        public void Test_ToDateFormat()
        {
            DateTime date = new(2023, 05, 31, 23, 16, 10);
            string result = date.ToDateFormat();
            Assert.AreEqual("31/05/2023 23:16:10", result);
        }

        [TestMethod]
        public void Test_ToDateCulture()
        {
            DateTime date = new(2023, 05, 31, 23, 16, 10);
            string result = date.ToDateCulture(EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual("31/05/2023 23:16:10", result);

            result = date.ToDateCulture(EnumCultureInfo.Portuguese_Brazil.GetDescription());
            Assert.AreEqual("31/05/2023 23:16:10", result);
        }

        [TestMethod]
        public void Test_ReduceText()
        {
            string val = "1234567890";
            string result = val.ReduceText(5, false);
            Assert.AreEqual("12345", result);

            result = val.ReduceText(5, true);
            Assert.AreEqual("12345...", result);
        }

        [TestMethod]
        public void Test_ToDateExtensive1()
        {
            DateTime date = new(2023, 05, 31);
            string result = date.ToDateExtensive1(EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual("Quarta-Feira, 31 de Maio de 2023", result);
        }

        [TestMethod]
        public void Test_ToDateExtensive2()
        {
            DateTime date = new(2023, 05, 31);
            string result = date.ToDateExtensive2(EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual("31 de Maio de 2023", result);
        }

        [TestMethod]
        public void Test_OnlyNumbers()
        {
            string val = "asgdf gdghjgd 123 4567 8 90 fsf s fx fh xfh ";
            string result = val.OnlyNumbers();
            Assert.AreEqual("1234567890", result);
        }

        [TestMethod]
        public void Test_ToBase64String()
        {
            byte[] val = new byte[] { 1, 3, 5, 7, 9, 10, 55, 100 };
            string result = val.ToBase64String();
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Test_RemoveAccents()
        {
            string val = "número raça";
            string result = val.RemoveAccents();
            Assert.AreEqual("numero raca", result);
        }

        [TestMethod]
        public async Task Test_ToString_Stopwatch()
        {
            Stopwatch val = new();
            val.Start();

            await Task.Delay(1000);

            var result = val.ToString(true);
            Assert.IsTrue(result.IsNullOrEmptyOrWhiteSpace() == false);
        }

    }
}

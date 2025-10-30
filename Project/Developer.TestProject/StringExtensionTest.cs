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
            date.ToDateFormat().Should().Be("31/05/2023 23:16:10");
        }

        [TestMethod]
        public void Test_ToDateCulture()
        {
            DateTime date = new(2023, 05, 31, 23, 16, 10);
            date.ToDateCulture(EnumCultureInfo.Portuguese_Brazil).Should().Be("31/05/2023 23:16:10");
            date.ToDateCulture(EnumCultureInfo.Portuguese_Brazil.GetDescription()).Should().Be("31/05/2023 23:16:10");
        }

        [TestMethod]
        public void Test_ReduceText()
        {
            string val = "1234567890";
            val.ReduceText(5, false).Should().Be("12345");
            val.ReduceText(5, true).Should().Be("12345...");
        }

        [TestMethod]
        public void Test_ToDateExtensive1()
        {
            DateTime date = new(2023, 05, 31);
            date.ToDateExtensive1(EnumCultureInfo.Portuguese_Brazil).Should().Be("Quarta-Feira, 31 de Maio de 2023");
            date.ToDateExtensive1(EnumCultureInfo.Portuguese_Brazil.GetDescription()).Should().Be("Quarta-Feira, 31 de Maio de 2023");
        }

        [TestMethod]
        public void Test_ToDateExtensive2()
        {
            DateTime date = new(2023, 05, 31);
            date.ToDateExtensive2(EnumCultureInfo.Portuguese_Brazil).Should().Be("31 de Maio de 2023");
            date.ToDateExtensive2(EnumCultureInfo.Portuguese_Brazil.GetDescription()).Should().Be("31 de Maio de 2023");
        }

        [TestMethod]
        public void Test_OnlyNumbers()
        {
            string val = "asgdf gdghjgd 123 4567 8 90 fsf s fx fh xfh ";
            val.OnlyNumbers().Should().Be("1234567890");
        }

        [TestMethod]
        public void Test_ToBase64String()
        {
            byte[] val = new byte[] { 1, 3, 5, 7, 9, 10, 55, 100 };
            val.ToBase64String().Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Test_RemoveAccents()
        {
            string val = "número raça";
            val.RemoveAccents().Should().Be("numero raca");
        }

        [TestMethod]
        public async Task Test_ToString_Stopwatch()
        {
            Stopwatch val = new();
            val.Start();

            await Task.Delay(1000);

            var result = val.ToString(true);
            result.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void Test_ToMaskCPF()
        {
            "13601854023".ToMaskCPF().Should().Be("136.018.540-23");
            "123456789".ToMaskCPF().Should().Be("001.234.567-89");
            "136.018.540-23".ToMaskCPF().Should().Be("136.018.540-23");

            string? nullValue = null;
            nullValue.ToMaskCPF().Should().BeNull();

            "".ToMaskCPF().Should().BeEmpty();
        }

        [TestMethod]
        public void Test_ToMaskCNPJ()
        {
            "18556359000105".ToMaskCNPJ().Should().Be("18.556.359/0001-05");
            "18.556.359/0001-05".ToMaskCNPJ().Should().Be("18.556.359/0001-05");



            string? nullValue = null;
            nullValue.ToMaskCNPJ().Should().BeNull();

            "".ToMaskCNPJ().Should().BeEmpty();
        }
    }
}

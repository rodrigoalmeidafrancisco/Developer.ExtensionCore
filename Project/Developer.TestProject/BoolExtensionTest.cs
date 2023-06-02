using Developer.ExtensionCore;

namespace Developer.TestProject
{
    [TestClass]
    public class BoolExtensionTest
    {
        #region string

        [TestMethod]
        public void Test_IsNullOrEmpty()
        {
            string value = "Test";
            bool result = value.IsNullOrEmpty();
            Assert.AreEqual(false, result);

            value = "    ";
            result = value.IsNullOrEmpty();
            Assert.AreEqual(false, result);

            value = "";
            result = value.IsNullOrEmpty();
            Assert.AreEqual(true, result);

            value = null;
            result = value.IsNullOrEmpty();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Test_IsNullOrWhiteSpace()
        {
            string value = "Test";
            bool result = value.IsNullOrWhiteSpace();
            Assert.AreEqual(false, result);

            value = "    ";
            result = value.IsNullOrWhiteSpace();
            Assert.AreEqual(true, result);

            value = "";
            result = value.IsNullOrWhiteSpace();
            Assert.AreEqual(true, result);

            value = null;
            result = value.IsNullOrWhiteSpace();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Test_IsNullOrEmptyOrWhiteSpace()
        {
            string value = "Test";
            bool result = value.IsNullOrEmptyOrWhiteSpace();
            Assert.AreEqual(false, result);

            value = "    ";
            result = value.IsNullOrEmptyOrWhiteSpace();
            Assert.AreEqual(true, result);

            value = "";
            result = value.IsNullOrEmptyOrWhiteSpace();
            Assert.AreEqual(true, result);

            value = null;
            result = value.IsNullOrEmptyOrWhiteSpace();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Test_StringOnlyNumbers()
        {
            string value = "Test22222";
            bool result = value.StringOnlyNumbers();
            Assert.AreEqual(false, result);

            value = "222222";
            result = value.StringOnlyNumbers();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Test_StringOnlyCharacters()
        {
            string value = "Test";
            bool result = value.StringOnlyCharacters();
            Assert.AreEqual(true, result);

            value = "Á ç É";
            result = value.StringOnlyCharacters();
            Assert.AreEqual(true, result);

            value = "Test22222";
            result = value.StringOnlyCharacters();
            Assert.AreEqual(false, result);

            value = "222222";
            result = value.StringOnlyCharacters();
            Assert.AreEqual(false, result);

            value = "  ";
            result = value.StringOnlyCharacters();
            Assert.AreEqual(false, result);

            value = null;
            result = value.StringOnlyCharacters();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_ValidCPF()
        {
            string value = "136.018.540-23";
            bool result = value.ValidCPF();
            Assert.AreEqual(true, result);

            value = "13601854023";
            result = value.ValidCPF();
            Assert.AreEqual(true, result);

            value = "00000000000";
            result = value.ValidCPF();
            Assert.AreEqual(false, result);

            value = "11111111111";
            result = value.ValidCPF();
            Assert.AreEqual(false, result);

            value = "22222222222";
            result = value.ValidCPF();
            Assert.AreEqual(false, result);

            value = "33333333333";
            result = value.ValidCPF();
            Assert.AreEqual(false, result);

            value = "44444444444";
            result = value.ValidCPF();
            Assert.AreEqual(false, result);

            value = "55555555555";
            result = value.ValidCPF();
            Assert.AreEqual(false, result);

            value = "66666666666";
            result = value.ValidCPF();
            Assert.AreEqual(false, result);

            value = "77777777777";
            result = value.ValidCPF();
            Assert.AreEqual(false, result);

            value = "88888888888";
            result = value.ValidCPF();
            Assert.AreEqual(false, result);

            value = "99999999999";
            result = value.ValidCPF();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_ValidCNPJ()
        {
            string value = "18.556.359/0001-05";
            bool result = value.ValidCNPJ();
            Assert.AreEqual(true, result);

            value = "18556359000105";
            result = value.ValidCNPJ();
            Assert.AreEqual(true, result);

            value = "00000000000000";
            result = value.ValidCNPJ();
            Assert.AreEqual(false, result);

            value = "11111111111111";
            result = value.ValidCNPJ();
            Assert.AreEqual(false, result);

            value = "22222222222222";
            result = value.ValidCNPJ();
            Assert.AreEqual(false, result);

            value = "33333333333333";
            result = value.ValidCNPJ();
            Assert.AreEqual(false, result);

            value = "44444444444444";
            result = value.ValidCNPJ();
            Assert.AreEqual(false, result);

            value = "55555555555555";
            result = value.ValidCNPJ();
            Assert.AreEqual(false, result);

            value = "66666666666666";
            result = value.ValidCNPJ();
            Assert.AreEqual(false, result);

            value = "77777777777777";
            result = value.ValidCNPJ();
            Assert.AreEqual(false, result);

            value = "88888888888888";
            result = value.ValidCNPJ();
            Assert.AreEqual(false, result);

            value = "99999999999999";
            result = value.ValidCNPJ();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_ValidEmail()
        {
            string value = "test@abc.com";
            bool result = value.ValidEmail();
            Assert.AreEqual(true, result);

            value = "test@abc.com.br";
            result = value.ValidEmail();
            Assert.AreEqual(true, result);

            value = "test@gmail.com";
            result = value.ValidEmail();
            Assert.AreEqual(true, result);

            value = "t@gmail.com";
            result = value.ValidEmail();
            Assert.AreEqual(true, result);

            value = "@gmail.com";
            result = value.ValidEmail();
            Assert.AreEqual(false, result);

            value = "Test22222";
            result = value.ValidEmail();
            Assert.AreEqual(false, result);

            value = "222222";
            result = value.ValidEmail();
            Assert.AreEqual(false, result);

            value = "  ";
            result = value.ValidEmail();
            Assert.AreEqual(false, result);

            value = null;
            result = value.ValidEmail();
            Assert.AreEqual(false, result);
        }

        #endregion string

        #region IsBetween

        [TestMethod]
        public void Test_IsBetween_DateTime()
        {
            DateTime value = new(2023, 01, 10);
            DateTime valueStart = new(2023, 01, 01);
            DateTime valueEnd = new(2023, 01, 15);

            bool result = value.IsBetween(valueStart, valueEnd);
            Assert.AreEqual(true, result);

            result = valueStart.IsBetween(value, valueEnd);
            Assert.AreEqual(false, result);

            DateTime? valueNull = new(2023, 01, 10);
            DateTime? valueStartNull = new(2023, 01, 01);
            DateTime? valueEndNull = new(2023, 01, 15);

            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(true, result);

            result = valueStartNull.IsBetween(valueNull, valueEndNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsBetween_Int()
        {
            int value = 30;
            int valueStart = 10;
            int valueEnd = 50;

            bool result = value.IsBetween(valueStart, valueEnd);
            Assert.AreEqual(true, result);

            result = valueStart.IsBetween(value, valueEnd);
            Assert.AreEqual(false, result);

            int? valueNull = 30;
            int? valueStartNull = 10;
            int? valueEndNull = 50;

            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(true, result);

            result = valueStartNull.IsBetween(valueNull, valueEndNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsBetween_Long()
        {
            long value = 30;
            long valueStart = 10;
            long valueEnd = 50;

            bool result = value.IsBetween(valueStart, valueEnd);
            Assert.AreEqual(true, result);

            result = valueStart.IsBetween(value, valueEnd);
            Assert.AreEqual(false, result);

            long? valueNull = 30;
            long? valueStartNull = 10;
            long? valueEndNull = 50;

            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(true, result);

            result = valueStartNull.IsBetween(valueNull, valueEndNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsBetween_Decimal()
        {
            decimal value = 30;
            decimal valueStart = 10;
            decimal valueEnd = 50;

            bool result = value.IsBetween(valueStart, valueEnd);
            Assert.AreEqual(true, result);

            result = valueStart.IsBetween(value, valueEnd);
            Assert.AreEqual(false, result);

            decimal? valueNull = 30;
            decimal? valueStartNull = 10;
            decimal? valueEndNull = 50;

            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(true, result);

            result = valueStartNull.IsBetween(valueNull, valueEndNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsBetween_float()
        {
            float value = 30;
            float valueStart = 10;
            float valueEnd = 50;

            bool result = value.IsBetween(valueStart, valueEnd);
            Assert.AreEqual(true, result);

            result = valueStart.IsBetween(value, valueEnd);
            Assert.AreEqual(false, result);

            float? valueNull = 30;
            float? valueStartNull = 10;
            float? valueEndNull = 50;

            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(true, result);

            result = valueStartNull.IsBetween(valueNull, valueEndNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsBetween_double()
        {
            double value = 30;
            double valueStart = 10;
            double valueEnd = 50;

            bool result = value.IsBetween(valueStart, valueEnd);
            Assert.AreEqual(true, result);

            result = valueStart.IsBetween(value, valueEnd);
            Assert.AreEqual(false, result);

            double? valueNull = 30;
            double? valueStartNull = 10;
            double? valueEndNull = 50;

            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(true, result);

            result = valueStartNull.IsBetween(valueNull, valueEndNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsBetween_TimeSpan()
        {
            TimeSpan value = new(10, 00, 00);
            TimeSpan valueStart = new(05, 00, 00);
            TimeSpan valueEnd = new(15, 00, 00);

            bool result = value.IsBetween(valueStart, valueEnd);
            Assert.AreEqual(true, result);

            result = valueStart.IsBetween(value, valueEnd);
            Assert.AreEqual(false, result);

            TimeSpan? valueNull = new(10, 00, 00);
            TimeSpan? valueStartNull = new(05, 00, 00);
            TimeSpan? valueEndNull = new(15, 00, 00);

            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(true, result);

            result = valueStartNull.IsBetween(valueNull, valueEndNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsBetween(valueStartNull, valueEndNull);
            Assert.AreEqual(false, result);
        }

        #endregion IsBetween

        #region IsGreaterThan

        [TestMethod]
        public void Test_IsGreaterThan_DateTime()
        {
            DateTime value = new(2023, 01, 10);
            DateTime compare = new(2023, 01, 01);

            bool result = value.IsGreaterThan(compare);
            Assert.AreEqual(true, result);

            result = compare.IsGreaterThan(value);
            Assert.AreEqual(false, result);

            DateTime? valueNull = new(2023, 01, 10);
            DateTime? compareNull = new(2023, 01, 01);

            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(true, result);

            result = compareNull.IsGreaterThan(valueNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsGreaterThan_int()
        {
            int value = 50;
            int compare = 15;

            bool result = value.IsGreaterThan(compare);
            Assert.AreEqual(true, result);

            result = compare.IsGreaterThan(value);
            Assert.AreEqual(false, result);

            int? valueNull = 50;
            int? compareNull = 15;

            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(true, result);

            result = compareNull.IsGreaterThan(valueNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsGreaterThan_long()
        {
            long value = 50;
            long compare = 15;

            bool result = value.IsGreaterThan(compare);
            Assert.AreEqual(true, result);

            result = compare.IsGreaterThan(value);
            Assert.AreEqual(false, result);

            long? valueNull = 50;
            long? compareNull = 15;

            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(true, result);

            result = compareNull.IsGreaterThan(valueNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsGreaterThan_decimal()
        {
            decimal value = 50;
            decimal compare = 15;

            bool result = value.IsGreaterThan(compare);
            Assert.AreEqual(true, result);

            result = compare.IsGreaterThan(value);
            Assert.AreEqual(false, result);

            decimal? valueNull = 50;
            decimal? compareNull = 15;

            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(true, result);

            result = compareNull.IsGreaterThan(valueNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsGreaterThan_float()
        {
            float value = 50;
            float compare = 15;

            bool result = value.IsGreaterThan(compare);
            Assert.AreEqual(true, result);

            result = compare.IsGreaterThan(value);
            Assert.AreEqual(false, result);

            float? valueNull = 50;
            float? compareNull = 15;

            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(true, result);

            result = compareNull.IsGreaterThan(valueNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsGreaterThan_double()
        {
            double value = 50;
            double compare = 15;

            bool result = value.IsGreaterThan(compare);
            Assert.AreEqual(true, result);

            result = compare.IsGreaterThan(value);
            Assert.AreEqual(false, result);

            double? valueNull = 50;
            double? compareNull = 15;

            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(true, result);

            result = compareNull.IsGreaterThan(valueNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsGreaterThan_TimeSpan()
        {
            TimeSpan value = new(10, 00, 00);
            TimeSpan compare = new(05, 00, 00);

            bool result = value.IsGreaterThan(compare);
            Assert.AreEqual(true, result);

            result = compare.IsGreaterThan(value);
            Assert.AreEqual(false, result);

            TimeSpan? valueNull = new(10, 00, 00);
            TimeSpan? compareNull = new(05, 00, 00);

            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(true, result);

            result = compareNull.IsGreaterThan(valueNull);
            Assert.AreEqual(false, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsGreaterThan(compareNull);
            Assert.AreEqual(false, result);
        }

        #endregion IsGreaterThan

        #region IsLowerThan

        [TestMethod]
        public void Test_IsLowerThan_DateTime()
        {
            DateTime value = new(2023, 01, 10);
            DateTime compare = new(2023, 01, 01);

            bool result = value.IsLowerThan(compare);
            Assert.AreEqual(false, result);

            result = compare.IsLowerThan(value);
            Assert.AreEqual(true, result);

            DateTime? valueNull = new(2023, 01, 10);
            DateTime? compareNull = new(2023, 01, 01);

            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);

            result = compareNull.IsLowerThan(valueNull);
            Assert.AreEqual(true, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsLowerThan_int()
        {
            int value = 50;
            int compare = 15;

            bool result = value.IsLowerThan(compare);
            Assert.AreEqual(false, result);

            result = compare.IsLowerThan(value);
            Assert.AreEqual(true, result);

            int? valueNull = 50;
            int? compareNull = 15;

            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);

            result = compareNull.IsLowerThan(valueNull);
            Assert.AreEqual(true, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsLowerThan_long()
        {
            long value = 50;
            long compare = 15;

            bool result = value.IsLowerThan(compare);
            Assert.AreEqual(false, result);

            result = compare.IsLowerThan(value);
            Assert.AreEqual(true, result);

            long? valueNull = 50;
            long? compareNull = 15;

            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);

            result = compareNull.IsLowerThan(valueNull);
            Assert.AreEqual(true, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsLowerThan_decimal()
        {
            decimal value = 50;
            decimal compare = 15;

            bool result = value.IsLowerThan(compare);
            Assert.AreEqual(false, result);

            result = compare.IsLowerThan(value);
            Assert.AreEqual(true, result);

            decimal? valueNull = 50;
            decimal? compareNull = 15;

            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);

            result = compareNull.IsLowerThan(valueNull);
            Assert.AreEqual(true, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsLowerThan_float()
        {
            float value = 50;
            float compare = 15;

            bool result = value.IsLowerThan(compare);
            Assert.AreEqual(false, result);

            result = compare.IsLowerThan(value);
            Assert.AreEqual(true, result);

            float? valueNull = 50;
            float? compareNull = 15;

            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);

            result = compareNull.IsLowerThan(valueNull);
            Assert.AreEqual(true, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsLowerThan_double()
        {
            double value = 50;
            double compare = 15;

            bool result = value.IsLowerThan(compare);
            Assert.AreEqual(false, result);

            result = compare.IsLowerThan(value);
            Assert.AreEqual(true, result);

            double? valueNull = 50;
            double? compareNull = 15;

            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);

            result = compareNull.IsLowerThan(valueNull);
            Assert.AreEqual(true, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test_IsLowerThan_TimeSpan()
        {
            TimeSpan value = new(10, 00, 00);
            TimeSpan compare = new(05, 00, 00);

            bool result = value.IsLowerThan(compare);
            Assert.AreEqual(false, result);

            result = compare.IsLowerThan(value);
            Assert.AreEqual(true, result);

            TimeSpan? valueNull = new(10, 00, 00);
            TimeSpan? compareNull = new(05, 00, 00);

            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);

            result = compareNull.IsLowerThan(valueNull);
            Assert.AreEqual(true, result);

            //Qualquer valor nulo, retorna false.
            valueNull = null;
            result = valueNull.IsLowerThan(compareNull);
            Assert.AreEqual(false, result);
        }

        #endregion IsLowerThan

    }
}
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
         value.IsNullOrEmpty().Should().BeFalse();

            value = "    ";
        value.IsNullOrEmpty().Should().BeFalse();

        value = "";
    value.IsNullOrEmpty().Should().BeTrue();

       value = null;
     value.IsNullOrEmpty().Should().BeTrue();
  }

        [TestMethod]
        public void Test_IsNullOrWhiteSpace()
 {
            string value = "Test";
            value.IsNullOrWhiteSpace().Should().BeFalse();

         value = "    ";
       value.IsNullOrWhiteSpace().Should().BeTrue();

            value = "";
        value.IsNullOrWhiteSpace().Should().BeTrue();

   value = null;
      value.IsNullOrWhiteSpace().Should().BeTrue();
     }

    [TestMethod]
        public void Test_IsNullOrEmptyOrWhiteSpace()
     {
   string value = "Test";
        value.IsNullOrEmptyOrWhiteSpace().Should().BeFalse();

 value = "    ";
            value.IsNullOrEmptyOrWhiteSpace().Should().BeTrue();

            value = "";
        value.IsNullOrEmptyOrWhiteSpace().Should().BeTrue();

      value = null;
    value.IsNullOrEmptyOrWhiteSpace().Should().BeTrue();
     }

        [TestMethod]
        public void Test_StringOnlyNumbers()
        {
            string value = "Test22222";
          value.StringOnlyNumbers().Should().BeFalse();

 value = "222222";
  value.StringOnlyNumbers().Should().BeTrue();
        }

        [TestMethod]
        public void Test_StringOnlyCharacters()
     {
   string value = "Test";
 value.StringOnlyCharacters().Should().BeTrue();

            value = "Á ç É";
            value.StringOnlyCharacters().Should().BeTrue();

     value = "Test22222";
   value.StringOnlyCharacters().Should().BeFalse();

            value = "222222";
       value.StringOnlyCharacters().Should().BeFalse();

         value = "  ";
 value.StringOnlyCharacters().Should().BeFalse();

     value = null;
            value.StringOnlyCharacters().Should().BeFalse();
  }

    [TestMethod]
        public void Test_ValidCPF()
        {
            "136.018.540-23".ValidCPF().Should().BeTrue();
            "13601854023".ValidCPF().Should().BeTrue();
     
            "00000000000".ValidCPF().Should().BeFalse();
        "11111111111".ValidCPF().Should().BeFalse();
  "22222222222".ValidCPF().Should().BeFalse();
        "33333333333".ValidCPF().Should().BeFalse();
            "44444444444".ValidCPF().Should().BeFalse();
            "55555555555".ValidCPF().Should().BeFalse();
    "66666666666".ValidCPF().Should().BeFalse();
      "77777777777".ValidCPF().Should().BeFalse();
            "88888888888".ValidCPF().Should().BeFalse();
   "99999999999".ValidCPF().Should().BeFalse();
      }

      [TestMethod]
    public void Test_ValidCNPJ()
 {
            "18.556.359/0001-05".ValidCNPJ().Should().BeTrue();
   "18556359000105".ValidCNPJ().Should().BeTrue();
            
  "00000000000000".ValidCNPJ().Should().BeFalse();
            "11111111111111".ValidCNPJ().Should().BeFalse();
  "22222222222222".ValidCNPJ().Should().BeFalse();
    "33333333333333".ValidCNPJ().Should().BeFalse();
          "44444444444444".ValidCNPJ().Should().BeFalse();
 "55555555555555".ValidCNPJ().Should().BeFalse();
            "66666666666666".ValidCNPJ().Should().BeFalse();
         "77777777777777".ValidCNPJ().Should().BeFalse();
   "88888888888888".ValidCNPJ().Should().BeFalse();
         "99999999999999".ValidCNPJ().Should().BeFalse();
        }

        [TestMethod]
     public void Test_ValidEmail()
      {
          "test@abc.com".ValidEmail().Should().BeTrue();
     "test@abc.com.br".ValidEmail().Should().BeTrue();
        "test@gmail.com".ValidEmail().Should().BeTrue();
            "t@gmail.com".ValidEmail().Should().BeTrue();
      
            "@gmail.com".ValidEmail().Should().BeFalse();
   "Test22222".ValidEmail().Should().BeFalse();
            "222222".ValidEmail().Should().BeFalse();
    "  ".ValidEmail().Should().BeFalse();
     
    string? nullValue = null;
          nullValue.ValidEmail().Should().BeFalse();
     }

        #endregion string

        #region IsBetween

        [TestMethod]
        public void Test_IsBetween_DateTime()
        {
 DateTime value = new(2023, 01, 10);
       DateTime valueStart = new(2023, 01, 01);
            DateTime valueEnd = new(2023, 01, 15);

value.IsBetween(valueStart, valueEnd).Should().BeTrue();
      valueStart.IsBetween(value, valueEnd).Should().BeFalse();

            DateTime? valueNull = new(2023, 01, 10);
            DateTime? valueStartNull = new(2023, 01, 01);
            DateTime? valueEndNull = new(2023, 01, 15);

            valueNull.IsBetween(valueStartNull, valueEndNull).Should().BeTrue();
            valueStartNull.IsBetween(valueNull, valueEndNull).Should().BeFalse();

          valueNull = null;
         valueNull.IsBetween(valueStartNull, valueEndNull).Should().BeFalse();
        }

 [TestMethod]
        public void Test_IsBetween_Int()
    {
    30.IsBetween(10, 50).Should().BeTrue();
            10.IsBetween(30, 50).Should().BeFalse();

     int? valueNull = 30;
    valueNull.IsBetween(10, 50).Should().BeTrue();

            valueNull = null;
  valueNull.IsBetween(10, 50).Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsBetween_Long()
        {
     30L.IsBetween(10L, 50L).Should().BeTrue();
 10L.IsBetween(30L, 50L).Should().BeFalse();

    long? valueNull = 30;
            valueNull.IsBetween(10L, 50L).Should().BeTrue();

          valueNull = null;
          valueNull.IsBetween(10L, 50L).Should().BeFalse();
        }

        [TestMethod]
    public void Test_IsBetween_Decimal()
        {
            30M.IsBetween(10M, 50M).Should().BeTrue();
            10M.IsBetween(30M, 50M).Should().BeFalse();

            decimal? valueNull = 30;
   valueNull.IsBetween(10M, 50M).Should().BeTrue();

        valueNull = null;
            valueNull.IsBetween(10M, 50M).Should().BeFalse();
      }

        [TestMethod]
      public void Test_IsBetween_Float()
   {
         30f.IsBetween(10f, 50f).Should().BeTrue();
          10f.IsBetween(30f, 50f).Should().BeFalse();

       float? valueNull = 30;
      valueNull.IsBetween(10f, 50f).Should().BeTrue();

    valueNull = null;
  valueNull.IsBetween(10f, 50f).Should().BeFalse();
   }

   [TestMethod]
  public void Test_IsBetween_Double()
        {
  30d.IsBetween(10d, 50d).Should().BeTrue();
     10d.IsBetween(30d, 50d).Should().BeFalse();

    double? valueNull = 30;
valueNull.IsBetween(10d, 50d).Should().BeTrue();

            valueNull = null;
            valueNull.IsBetween(10d, 50d).Should().BeFalse();
    }

        [TestMethod]
public void Test_IsBetween_TimeSpan()
        {
            TimeSpan value = new(10, 00, 00);
         TimeSpan valueStart = new(05, 00, 00);
            TimeSpan valueEnd = new(15, 00, 00);

    value.IsBetween(valueStart, valueEnd).Should().BeTrue();
            valueStart.IsBetween(value, valueEnd).Should().BeFalse();

    TimeSpan? valueNull = new(10, 00, 00);
 valueNull.IsBetween(valueStart, valueEnd).Should().BeTrue();

valueNull = null;
      valueNull.IsBetween(valueStart, valueEnd).Should().BeFalse();
        }

      #endregion IsBetween

        #region IsGreaterThan

        [TestMethod]
        public void Test_IsGreaterThan_DateTime()
    {
       DateTime value = new(2023, 01, 10);
            DateTime compare = new(2023, 01, 01);

       value.IsGreaterThan(compare).Should().BeTrue();
 compare.IsGreaterThan(value).Should().BeFalse();

            DateTime? valueNull = new(2023, 01, 10);
  valueNull.IsGreaterThan(compare).Should().BeTrue();

   valueNull = null;
        valueNull.IsGreaterThan(compare).Should().BeFalse();
 }

    [TestMethod]
   public void Test_IsGreaterThan_Int()
        {
 50.IsGreaterThan(15).Should().BeTrue();
        15.IsGreaterThan(50).Should().BeFalse();

  int? valueNull = 50;
            valueNull.IsGreaterThan(15).Should().BeTrue();

  valueNull = null;
            valueNull.IsGreaterThan(15).Should().BeFalse();
        }

  [TestMethod]
  public void Test_IsGreaterThan_Long()
        {
            50L.IsGreaterThan(15L).Should().BeTrue();
   15L.IsGreaterThan(50L).Should().BeFalse();

  long? valueNull = 50;
   valueNull.IsGreaterThan(15L).Should().BeTrue();

            valueNull = null;
            valueNull.IsGreaterThan(15L).Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsGreaterThan_Decimal()
        {
      50M.IsGreaterThan(15M).Should().BeTrue();
  15M.IsGreaterThan(50M).Should().BeFalse();

            decimal? valueNull = 50;
  valueNull.IsGreaterThan(15M).Should().BeTrue();

  valueNull = null;
            valueNull.IsGreaterThan(15M).Should().BeFalse();
        }

        [TestMethod]
public void Test_IsGreaterThan_Float()
      {
       50f.IsGreaterThan(15f).Should().BeTrue();
            15f.IsGreaterThan(50f).Should().BeFalse();

            float? valueNull = 50;
     valueNull.IsGreaterThan(15f).Should().BeTrue();

        valueNull = null;
        valueNull.IsGreaterThan(15f).Should().BeFalse();
   }

        [TestMethod]
        public void Test_IsGreaterThan_Double()
        {
            50d.IsGreaterThan(15d).Should().BeTrue();
        15d.IsGreaterThan(50d).Should().BeFalse();

            double? valueNull = 50;
            valueNull.IsGreaterThan(15d).Should().BeTrue();

            valueNull = null;
            valueNull.IsGreaterThan(15d).Should().BeFalse();
        }

      [TestMethod]
        public void Test_IsGreaterThan_TimeSpan()
        {
            TimeSpan value = new(10, 00, 00);
            TimeSpan compare = new(05, 00, 00);

    value.IsGreaterThan(compare).Should().BeTrue();
       compare.IsGreaterThan(value).Should().BeFalse();

            TimeSpan? valueNull = new(10, 00, 00);
  valueNull.IsGreaterThan(compare).Should().BeTrue();

     valueNull = null;
  valueNull.IsGreaterThan(compare).Should().BeFalse();
        }

        #endregion IsGreaterThan

      #region IsLowerThan

  [TestMethod]
      public void Test_IsLowerThan_DateTime()
    {
          DateTime value = new(2023, 01, 10);
     DateTime compare = new(2023, 01, 01);

      value.IsLowerThan(compare).Should().BeFalse();
          compare.IsLowerThan(value).Should().BeTrue();

   DateTime? valueNull = new(2023, 01, 01);
      valueNull.IsLowerThan(value).Should().BeTrue();

  valueNull = null;
       valueNull.IsLowerThan(value).Should().BeFalse();
}

        [TestMethod]
        public void Test_IsLowerThan_Int()
        {
  50.IsLowerThan(15).Should().BeFalse();
            15.IsLowerThan(50).Should().BeTrue();

            int? valueNull = 15;
            valueNull.IsLowerThan(50).Should().BeTrue();

            valueNull = null;
            valueNull.IsLowerThan(50).Should().BeFalse();
    }

    [TestMethod]
        public void Test_IsLowerThan_Long()
        {
        50L.IsLowerThan(15L).Should().BeFalse();
            15L.IsLowerThan(50L).Should().BeTrue();

          long? valueNull = 15;
         valueNull.IsLowerThan(50L).Should().BeTrue();

  valueNull = null;
        valueNull.IsLowerThan(50L).Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsLowerThan_Decimal()
        {
      50M.IsLowerThan(15M).Should().BeFalse();
    15M.IsLowerThan(50M).Should().BeTrue();

decimal? valueNull = 15;
          valueNull.IsLowerThan(50M).Should().BeTrue();

            valueNull = null;
 valueNull.IsLowerThan(50M).Should().BeFalse();
   }

        [TestMethod]
        public void Test_IsLowerThan_Float()
        {
     50f.IsLowerThan(15f).Should().BeFalse();
            15f.IsLowerThan(50f).Should().BeTrue();

            float? valueNull = 15;
   valueNull.IsLowerThan(50f).Should().BeTrue();

            valueNull = null;
     valueNull.IsLowerThan(50f).Should().BeFalse();
      }

        [TestMethod]
        public void Test_IsLowerThan_Double()
        {
            50d.IsLowerThan(15d).Should().BeFalse();
          15d.IsLowerThan(50d).Should().BeTrue();

       double? valueNull = 15;
            valueNull.IsLowerThan(50d).Should().BeTrue();

          valueNull = null;
      valueNull.IsLowerThan(50d).Should().BeFalse();
  }

        [TestMethod]
        public void Test_IsLowerThan_TimeSpan()
  {
  TimeSpan value = new(10, 00, 00);
 TimeSpan compare = new(05, 00, 00);

    value.IsLowerThan(compare).Should().BeFalse();
       compare.IsLowerThan(value).Should().BeTrue();

            TimeSpan? valueNull = new(05, 00, 00);
    valueNull.IsLowerThan(value).Should().BeTrue();

      valueNull = null;
          valueNull.IsLowerThan(value).Should().BeFalse();
     }

      #endregion IsLowerThan

        #region IsList

        [TestMethod]
        public void Test_IsList()
  {
            var list = new List<int> { 1, 2, 3 };
     list.IsList().Should().BeTrue();

     IList<string> iList = new List<string> { "a", "b" };
       iList.IsList().Should().BeTrue();

       IEnumerable<int> enumerable = new List<int> { 1, 2, 3 };
enumerable.IsList().Should().BeTrue();

            IReadOnlyCollection<int> readOnly = new List<int> { 1, 2, 3 };
         readOnly.IsList().Should().BeTrue();

            int singleValue = 42;
  singleValue.IsList().Should().BeFalse();

         string text = "test";
 text.IsList().Should().BeFalse();
     }

        #endregion IsList
    }
}
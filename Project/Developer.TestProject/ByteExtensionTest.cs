using Developer.ExtensionCore;
using Developer.TestProject.Dto;

namespace Developer.TestProject
{
    [TestClass]
    public class ByteExtensionTest
    {
        [TestMethod]
        public void Test_ToByte()
        {
            string value = "1";
            byte result = value.ToByte();
            Assert.AreEqual(1, result);

            value = "   ";
            result = value.ToByte();
            Assert.AreEqual(0, result);

            value = "";
            result = value.ToByte();
            Assert.AreEqual(0, result);

            value = null;
            result = value.ToByte();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_ToByteNull()
        {
            string value = "1";
            byte? result = value.ToByteNull();
            Assert.AreEqual(1, result.Value);

            value = "   ";
            result = value.ToByteNull();
            Assert.AreEqual(null, result);

            value = "";
            result = value.ToByteNull();
            Assert.AreEqual(null, result);

            value = null;
            result = value.ToByteNull();
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Test_ToByte_Enum()
        {
            byte result = EnumTest.Valor0.ToByte();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_ToByteNull_Enum()
        {
            byte? result = EnumTest.Valor0.ToByteNull();
            Assert.AreEqual(0, result.Value);
        }


    }
}

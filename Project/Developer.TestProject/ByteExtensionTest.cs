using Developer.ExtensionCore;
using Developer.ExtensionCore.Enums;

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
            byte result = EnumCultureInfo.Afar_Djibouti.ToByte();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_ToByteNull_Enum()
        {
            byte? result = EnumCultureInfo.Afar_Djibouti.ToByteNull();
            Assert.AreEqual(1, result.Value);
        }

        [TestMethod]
        public void Test_ToBytes_Stream()
        {
            string pathFile = @"FilesTest\ImageTest.png";
            using (FileStream fileStream = File.Open(pathFile, FileMode.Open))
            {
                var fileInBytes = fileStream.ToBytes();
                Assert.AreNotEqual(null, fileInBytes);
            }
        }

        [TestMethod]
        public void Test_ToBytesPathFile()
        {
            string pathFile = @"FilesTest\ImageTest.png";
            byte[] fileInBytes = pathFile.ToBytesPathFile();
            Assert.AreNotEqual(null, fileInBytes);
        }
    }
}

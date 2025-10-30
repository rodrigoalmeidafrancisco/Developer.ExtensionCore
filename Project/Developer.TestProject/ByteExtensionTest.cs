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
            "1".ToByte().Should().Be(1);
            "   ".ToByte().Should().Be(0);
            "".ToByte().Should().Be(0);

            string? nullValue = null;
            nullValue.ToByte().Should().Be(0);
        }

        [TestMethod]
        public void Test_ToByteNull()
        {
            "1".ToByteNull().Should().Be(1);
            "   ".ToByteNull().Should().BeNull();
            "".ToByteNull().Should().BeNull();

            string? nullValue = null;
            nullValue.ToByteNull().Should().BeNull();
        }

        [TestMethod]
        public void Test_ToByte_Enum()
        {
            EnumCultureInfo.Afar_Djibouti.ToByte().Should().Be(1);
        }

        [TestMethod]
        public void Test_ToByteNull_Enum()
        {
            EnumCultureInfo.Afar_Djibouti.ToByteNull().Should().Be(1);
        }

        [TestMethod]
        public void Test_ToBytes_Stream()
        {
            string pathFile = @"FilesTest\ImageTest.png";
            using (FileStream fileStream = File.Open(pathFile, FileMode.Open))
            {
                var fileInBytes = fileStream.ToBytes();
                fileInBytes.Should().NotBeNull();
            }
        }

        [TestMethod]
        public void Test_ToBytesPathFile()
        {
            string pathFile = @"FilesTest\ImageTest.png";
            byte[] fileInBytes = pathFile.ToBytesPathFile();
            fileInBytes.Should().NotBeNull();
        }
    }
}

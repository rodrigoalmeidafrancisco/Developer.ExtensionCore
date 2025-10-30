using Developer.ExtensionCore;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning; // Necessário para o atributo SupportedOSPlatform

namespace Developer.TestProject
{
    [TestClass]
    public class StreamExtensionTest
    {
        [TestMethod]
        [SupportedOSPlatform("windows")] // Corrige CA1416
        public void Test_ToBitmapForStream()
        {
            // Criar um bitmap simples para teste
            using Bitmap bitmap = new(100, 100); // Corrige IDE0090
            {
                using Graphics g = Graphics.FromImage(bitmap);
                {
                    g.Clear(Color.Blue);
                }

                var stream = bitmap.ToBitmapForStream(ImageFormat.Png);
                Assert.IsNotNull(stream);
            }
        }

        [TestMethod]
        public void Test_ToBytesForMemoryStream()
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var memoryStream = bytes.ToBytesForMemoryStream();

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(bytes.Length, memoryStream.Length);
        }

        [TestMethod]
        public void Test_ToBytesForMemoryStream_Null()
        {
            byte[] bytes = null;
            var memoryStream = bytes.ToBytesForMemoryStream();

            Assert.IsNull(memoryStream);
        }
    }
}

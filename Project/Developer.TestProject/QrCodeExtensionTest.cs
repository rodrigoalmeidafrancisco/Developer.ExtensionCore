using Developer.ExtensionCore;

namespace Developer.TestProject
{
    [TestClass]
    public class QrCodeExtensionTest
    {
        //A versão 1.4.3 do pacote nuget "QRCoder" está dando erro.
        //https://github.com/codebude/QRCoder/

        private readonly string _phraseQrCode;

        public QrCodeExtensionTest()
        {
            _phraseQrCode = "https://www.nuget.org/packages/Developer.ExtensionCore/";
        }

        [TestMethod]
        public void Test_ToCreateQrCode()
        {
            byte[] qrCode = _phraseQrCode.ToCreateQrCode();
            Assert.IsTrue(qrCode != null);

            string phrase = null;
            qrCode = phrase.ToCreateQrCode();
            Assert.IsTrue(qrCode != null);
        }

        [TestMethod]
        public void Test_ToCreateQrCodeBase64()
        {
            string qrCode = _phraseQrCode.ToCreateQrCodeBase64(false);
            Assert.IsTrue(qrCode != null);
            //Result: iVBORw0KGgoAAAANSUhEUgAAA4QAAAOECAYAAAD5Tv87AAAAAXNSR0IArs4c6Q.....

            qrCode = _phraseQrCode.ToCreateQrCodeBase64(true);
            Assert.IsTrue(qrCode != null);
            //Result: data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAA4QAAAOECAYAAAD5Tv87AAAAAXNSR0IArs4c6Q.....
        }

    }
}

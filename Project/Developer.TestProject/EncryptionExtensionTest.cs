using Developer.ExtensionCore;

namespace Developer.TestProject
{
    [TestClass]
    public class EncryptionExtensionTest
    {
        private readonly string _encryptionKey;
        private readonly string _phraseToEncrypt;

        public EncryptionExtensionTest()
        {
            _encryptionKey = "123456789012345678901234";
            _phraseToEncrypt = "Teste de Criptografia!";
        }

        [TestMethod]
        public void Test_Encrypt_Decrypt()
        {
            string resultEncrypt = EncryptionExtension.Encrypt(_encryptionKey, _phraseToEncrypt);

            if (resultEncrypt.Equals(_phraseToEncrypt) == false)
            {
                string resultDecrypt = EncryptionExtension.Decrypt(_encryptionKey, resultEncrypt);
                Assert.IsTrue(resultDecrypt.Equals(_phraseToEncrypt));
            }
            else
            {
                Assert.Fail("Frase não criptografada!");
            }
        }
    }
}

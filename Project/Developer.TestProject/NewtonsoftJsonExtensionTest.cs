using Developer.ExtensionCore;
using Developer.TestProject.FilesTest;

namespace Developer.TestProject
{
    [TestClass]
    public class NewtonsoftJsonExtensionTest
    {
        private readonly PersonTest _personTest;
        private readonly PersonAddressTest _address;
        private readonly List<PersonTelephoneTest> _phones;

        public NewtonsoftJsonExtensionTest()
        {
            _address = new("Rua Teste", "123", "Brasil", "São Paulo", "SP");
            _phones = new() { new PersonTelephoneTest("Cel", "123"), new PersonTelephoneTest("Res", "456") };
            _personTest = new("Batman", 30, new List<string>() { "Combater o Crime", "Andar de Batmóvel" }, _address, _phones);
        }

        [TestMethod]
        public void Test_ToNewtonsoftSerializeJson()
        {
            string json = _personTest.ToNewtonsoftSerializeJson();
            Assert.IsTrue(json.IsNullOrEmptyOrWhiteSpace() == false);
        }

        [TestMethod]
        public void Test_ToNewtonsoftDeserializeJson()
        {
            string json = _personTest.ToNewtonsoftSerializeJson();
            PersonTest personTest = json.ToNewtonsoftDeserializeJson<PersonTest>();
            Assert.IsTrue(personTest != null);
        }

    }
}

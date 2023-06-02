using Developer.ExtensionCore;
using Developer.TestProject.FilesTest;
using System.Text.Json;

namespace Developer.TestProject
{
    [TestClass]
    public class SystemTextJsonExtensionTest
    {
        private readonly PersonTest _personTest;
        private readonly PersonAddressTest _address;
        private readonly List<PersonTelephoneTest> _phones;
        private readonly JsonSerializerOptions _options;

        public SystemTextJsonExtensionTest()
        {
            _address = new("Rua Teste", "123", "Brasil", "São Paulo", "SP");
            _phones = new() { new PersonTelephoneTest("Cel", "123"), new PersonTelephoneTest("Res", "456") };
            _personTest = new("Batman", 30, new List<string>() { "Combater o Crime", "Andar de Batmóvel" }, _address, _phones);

            _options = new()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };
        }

        [TestMethod]
        public void Test_ToSystemTextJsonSerializeJson()
        {
            string json = _personTest.ToSystemTextJsonSerializeJson();
            Assert.IsTrue(json.IsNullOrEmptyOrWhiteSpace() == false);

            json = _personTest.ToSystemTextJsonSerializeJson(_options);
            Assert.IsTrue(json.IsNullOrEmptyOrWhiteSpace() == false);
        }

        [TestMethod]
        public void Test_ToNewtonsoftDeserializeJson()
        {
            string json = _personTest.ToSystemTextJsonSerializeJson();
            PersonTest personTest = json.ToSystemTextJsonDeserializeJson<PersonTest>();
            Assert.IsTrue(personTest != null);

            json = _personTest.ToSystemTextJsonSerializeJson(_options);
            personTest = json.ToSystemTextJsonDeserializeJson<PersonTest>(_options);
            Assert.IsTrue(personTest != null);
        }

    }
}

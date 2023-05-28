using Developer.ExtensionCore;
using Developer.ExtensionCore.Enums;

namespace Developer.TestProject
{
    [TestClass]
    public class EnumExtensionTest
    {
        [TestMethod]
        public void Test_GetDescription()
        {
            string description = EnumCultureInfo.Portuguese_Brazil.GetDescription();
            Assert.AreEqual("pt-BR", description);
        }

        [TestMethod]
        public void Test_GetListDescriptionEnum()
        {
            var listDescription = EnumExtension.GetListDescriptionEnum<EnumCultureInfo>();
            Assert.IsTrue(listDescription != null && listDescription.Any());
        }

        [TestMethod]
        public void Test_GetListDescriptionEnumDropDown()
        {
            var listDescription = EnumExtension.GetListDescriptionEnumDropDown<EnumCultureInfo>();
            Assert.IsTrue(listDescription != null && listDescription.Any());
        }

    }
}

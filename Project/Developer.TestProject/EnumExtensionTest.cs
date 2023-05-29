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

            description = EnumExtension.GetDescription(EnumCultureInfo.Portuguese_Brazil);
            Assert.AreEqual("pt-BR", description);
        }

        [TestMethod]
        public void Test_GetListDescription()
        {
            var listDescription = EnumExtension.GetListDescription<EnumCultureInfo>();
            Assert.IsTrue(listDescription != null && listDescription.Any());
        }

        [TestMethod]
        public void Test_GetListDescriptionDropDown()
        {
            var listDescription = EnumExtension.GetListDescriptionDropDown<EnumCultureInfo>();
            Assert.IsTrue(listDescription != null && listDescription.Any());

            listDescription = EnumExtension.GetListDescriptionDropDown<EnumCultureInfo>(-10, "Select...");
            Assert.IsTrue(listDescription != null && listDescription.Any());
            Assert.IsTrue(listDescription.First().Key == -10);
        }

    }
}

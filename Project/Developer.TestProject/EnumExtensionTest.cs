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
            EnumCultureInfo.Portuguese_Brazil.GetDescription().Should().Be("pt-BR");
            EnumExtension.GetDescription(EnumCultureInfo.Portuguese_Brazil).Should().Be("pt-BR");
        }

        [TestMethod]
        public void Test_GetListDescription()
        {
            var listDescription = EnumExtension.GetListDescription<EnumCultureInfo>();
            listDescription.Should().NotBeNull().And.NotBeEmpty();
        }

        [TestMethod]
        public void Test_GetListDescriptionDropDown()
        {
            var listDescription = EnumExtension.GetListDescriptionDropDown<EnumCultureInfo>();
            listDescription.Should().NotBeNull().And.NotBeEmpty();

            listDescription = EnumExtension.GetListDescriptionDropDown<EnumCultureInfo>(-10, "Select...");
            listDescription.Should().NotBeNull().And.NotBeEmpty();
            listDescription.First().Key.Should().Be(-10);
            listDescription.First().Value.Should().Be("Select...");
        }
    }
}

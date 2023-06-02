namespace Developer.TestProject.FilesTest
{
    public class PersonTest
    {
        public PersonTest()
        {
                
        }

        public PersonTest(string name, int age, List<string> hobbies, PersonAddressTest address, List<PersonTelephoneTest> phones)
        {
            Name = name;
            Age = age;
            Hobbies = hobbies;
            Address = address;
            Phones = phones;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Hobbies { get; set; }
        public PersonAddressTest Address { get; set; }
        public List<PersonTelephoneTest> Phones { get; set; }
    }
}

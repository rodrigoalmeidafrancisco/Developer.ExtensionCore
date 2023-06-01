namespace Developer.TestProject.FilesTest
{
    public class PersonTelephoneTest
    {
        public PersonTelephoneTest()
        {
                
        }

        public PersonTelephoneTest(string type, string number)
        {
            Type = type;
            Number = number;
        }

        public string Type { get; set; }
        public string Number { get; set; }
    }
}

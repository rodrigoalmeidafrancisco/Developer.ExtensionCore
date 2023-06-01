namespace Developer.TestProject.FilesTest
{
    public class PersonAddressTest
    {
        public PersonAddressTest()
        {
            
        }

        public PersonAddressTest(string street, string number, string country, string city, string state)
        {
            Street = street;
            Number = number;
            Country = country;
            City = city;
            State = state;
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}

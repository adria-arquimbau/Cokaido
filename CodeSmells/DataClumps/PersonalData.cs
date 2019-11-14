namespace DataClumps
{
    public class PersonalData
    {
        public PersonalData(string house, string street, string city, string postCode, string country, string firstName, string lastName, string title)
        {
            House = house;
            Street = street;
            City = city;
            PostCode = postCode;
            Country = country;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
        }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string House { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}
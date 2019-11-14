namespace DataClumps
{
    public class Customer
    {
        private readonly PersonalData personalData;

        public Customer(string title, string firstName, string lastName, string house, string street, string city, string postCode, string country)
        {
            personalData = new PersonalData(house, street, city, postCode, country, firstName, lastName, title);
        }

        public string AddressSummary
        {
            get
            {
                return personalData.House + ", " + personalData.Street + ", " + personalData.City + ", " + personalData.PostCode + ", " + personalData.Country;
            }
        }
    }
}
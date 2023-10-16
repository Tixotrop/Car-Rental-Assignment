using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes
{
    public class Customer : IPerson
    {
        public string SSN { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty;

        public Customer()
        {
            
        }

        public Customer(string sSN, string firstName, string lastName)
        {
            this.SSN = sSN;
            this.FirstName = firstName;
            this.LastName = lastName;   
        }


    }
}

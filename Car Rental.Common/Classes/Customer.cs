using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes
{
    public class Customer : IPerson
    {
        public int Id { get; }
        public string SSN { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty;


        public Customer()
        {
            
        }

        public Customer(int id, string sSN, string firstName, string lastName)
        {
            Id = id;
            this.SSN = sSN;
            this.FirstName = firstName;
            this.LastName = lastName;   
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} ({SSN})";
        }
    }
}

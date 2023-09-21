using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes
{
    public class Customer : IPerson
    {
        public string SSN { get; }
        public string FirstName { get;  }
        public string LastName { get;  }
        
        public Customer(string sSN, string firstName, string lastName)
        {
            this.SSN = sSN;
            this.FirstName = firstName;
            this.LastName = lastName;   
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface IPerson
    {
        // SSN, firstName, lastName
        public string SSN { get;  }
        public string FirstName { get; }

        public string LastName { get; }

    
    }

}

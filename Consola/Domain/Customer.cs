using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer
    {
        public Guid IdCustomer { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }

        public string Doc { get; set; }

        public Address Address { get; set; }

        public Customer()
        {

        }
        public Customer(Guid idCustomer, string firstName, string lastName, DateTime dateBirth, string doc, Address address)
        {
            IdCustomer = idCustomer;
            FirstName = firstName;
            LastName = lastName;
            DateBirth = dateBirth;
            Doc = doc;
            Address = address;
        }
    }
}

using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.File
{
    internal class AddressRepository : IGenericRepository<Address>
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public Address GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Address obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Address obj)
        {
            throw new NotImplementedException();
        }
    }
}

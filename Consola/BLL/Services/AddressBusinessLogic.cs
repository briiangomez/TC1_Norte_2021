using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public sealed class AddressBusinessLogic : IGenericBusinessLogic<Address>
    {
        #region Singleton
        private readonly static AddressBusinessLogic  _instance = new AddressBusinessLogic ();

        public static AddressBusinessLogic  Current
        {
            get
            {
                return _instance;
            }
        }
        private AddressBusinessLogic()
        {
            //Implement here the initialization code
        }

        #endregion
               
        public void Add(Address obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Address obj)
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
       
    }

}

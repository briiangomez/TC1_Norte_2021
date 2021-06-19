using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.SqlServer;
using System.Configuration;

namespace DAL.Factory
{
    public sealed class Factory
    {
        //string backend;
        //public void SetearAccesoDatos(string backend)
        //{
        //    this.backend = backend;
        //}

        #region Singleton
        private readonly static Factory _instance = new Factory();
        private string backend;
        public static Factory Current
        {
            get
            {
                return _instance;
            }
        }

        private Factory()
        {
            //Implement here the initialization code
            backend = ConfigurationManager.AppSettings["backend"];
        }
        #endregion

        public IGenericRepository<Customer> GetCustomerRepository()
        {
            return new CustomerRepository();
        }

        public IGenericRepository<Address> GetAddressRepository()
        {     
            if (backend == "SQL")
                return new AddressRepository();
            else
                return new DAL.Repositories.File.AddressRepository();
        }
    }
}

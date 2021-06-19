using BLL.Contracts;
using DAL.Contracts;
using DAL.Factory;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{

    public sealed class CustomerBusinessLogic : IGenericBusinessLogic<Customer>
    {
        #region Singleton
        private readonly static CustomerBusinessLogic  _instance = new CustomerBusinessLogic();

        public static CustomerBusinessLogic  Current
        {
            get
            {
                return _instance;
            }
        }

        private CustomerBusinessLogic()
        {
            //Implement here the initialization code
            customerRepository = Factory.Current.GetCustomerRepository();
        }


        #endregion

        IGenericRepository<Customer> customerRepository;

        public void Add(Customer obj)
        {
            //Regla de negocio?
            if(obj.DateBirth > DateTime.Now.AddYears(-18))
            {
                //Deberíamos lanzar una Exception del Negocio
                throw new Exception("La persona es menor de edad");
            }

            //DESPUÉS DE PASAR TODAS LA REGLAS...

            customerRepository.Insert(obj);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetOne(Guid id)
        {
            throw new NotImplementedException();
        }
    }

}

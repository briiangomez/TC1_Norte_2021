using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IGenericBusinessLogic<T> where T : class, new()
    {
        void Add(T obj);

        void Remove(Guid id);

        void Update(T obj);

        IEnumerable<T> GetAll();

        T GetOne(Guid id);
    }
}

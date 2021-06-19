using System.Linq;

namespace UNITOFWORK_AND_REPOSITORY_PATTERN.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        void Remove(T entity);
        void Add(T entity);
    }
}

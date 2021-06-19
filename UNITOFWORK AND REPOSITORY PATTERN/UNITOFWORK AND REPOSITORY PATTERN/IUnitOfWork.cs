using UNITOFWORK_AND_REPOSITORY_PATTERN.Entities;
using UNITOFWORK_AND_REPOSITORY_PATTERN.Repositories;

namespace UNITOFWORK_AND_REPOSITORY_PATTERN
{
    public interface IUnitOfWork
    {
        IRepository<Author> AuthorRepository { get; }
        IRepository<Book> BookRepository { get; }
        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();
        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        void RejectChanges();
        void Dispose();
    }

}

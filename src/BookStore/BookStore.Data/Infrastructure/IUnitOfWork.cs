using BookStore.Data.Infrastructure.Repositories;
using BookStore.Models.BaseEntities;
using BookStore.Models.Common;
using System;
using System.Threading.Tasks;

namespace BookStore.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        BookStoreContext DataContext { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;

        #region Master Data

        IGenericRepository<Category> CategoryRepository { get; }

        IGenericRepository<Book> BookRepository { get; }

        IGenericRepository<Publisher> PublisherRepository { get; }

        IGenericRepository<Review> ReviewRepository { get; }

        IGenericRepository<Author> AuthorRepository { get; }

        #endregion

    }
}

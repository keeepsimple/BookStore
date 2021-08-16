using BookStore.Data.Infrastructure;
using BookStore.Models.Common;
using BookStore.Services.BaseServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookServices : BaseServices<Book>, IBookServices
    {
        public BookServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Book>> GetBookByAuthorAsync(string author)
        {
            return await _unitOfWork.BookRepository.GetQuery().Where(b => b.Authors.Any(t => t.Name.Equals(author))).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByCategoryAsync(string category)
        {
            return await _unitOfWork.BookRepository.GetQuery().Where(b => b.Category.Name.Equals(category)).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByPriceAsync(decimal price)
        {
            return await _unitOfWork.BookRepository.GetQuery().Where(b=>b.Price == price).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByPublisherAsync(string publisher)
        {
            return await _unitOfWork.BookRepository.GetQuery().Where(b=>b.Publisher.Name.Equals(publisher)).ToListAsync();  
        }

        public IEnumerable<Book> GetHighestBook(int size)
        {
            return _unitOfWork.BookRepository.GetQuery().OrderByDescending(b=>b.Price).Take(size).ToList();
        }

        public async Task<IEnumerable<Book>> GetHighestBookAsync(int size)
        {
            return await _unitOfWork.BookRepository.GetQuery().OrderByDescending(b=>b.Price).Take(size).ToListAsync();
        }

        public IEnumerable<Book> GetLastestBook(int size)
        {
            return _unitOfWork.BookRepository.GetQuery().OrderByDescending(b=>b.CreatedDate).Take(size).ToList();
        }

        public async Task<IEnumerable<Book>> GetLastestBookAsync(int size)
        {
            return await _unitOfWork.BookRepository.GetQuery().OrderByDescending(b => b.CreatedDate).Take(size).ToListAsync();
        }

        public IEnumerable<Book> GetPopularBook(int size)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetPopularBookAsync(int size)
        {
            throw new System.NotImplementedException();
        }
    }
}

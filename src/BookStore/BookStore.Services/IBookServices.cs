using BookStore.Models.Common;
using BookStore.Services.BaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IBookServices : IBaseServices<Book>
    {
        /// <summary>
        /// Get async lastest book
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetLastestBookAsync(int size);

        /// <summary>
        /// Get lastest book
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IEnumerable<Book> GetLastestBook(int size);

        /// <summary>
        /// Get async get popular book
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetPopularBookAsync(int size);

        /// <summary>
        /// Get popular book
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IEnumerable<Book> GetPopularBook(int size);

        /// <summary>
        /// Get async highest book
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetHighestBookAsync(int size);
        
        /// <summary>
        /// Get highest book
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IEnumerable<Book> GetHighestBook(int size);

        /// <summary>
        /// Get async book by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetBookByCategoryAsync(string category);
        
        /// <summary>
        /// Get async book by price
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetBookByPriceAsync(decimal price);

        /// <summary>
        /// get async book by author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetBookByAuthorAsync(string author);
        
        /// <summary>
        /// get async book by publisher
        /// </summary>
        /// <param name="publisher"></param>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetBookByPublisherAsync(string publisher);
    }
}

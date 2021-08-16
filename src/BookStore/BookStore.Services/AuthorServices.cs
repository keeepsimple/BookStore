using BookStore.Data.Infrastructure;
using BookStore.Models.Common;
using BookStore.Services.BaseServices;

namespace BookStore.Services
{
    public class AuthorServices : BaseServices<Author>, IAuthorServices
    {
        public AuthorServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

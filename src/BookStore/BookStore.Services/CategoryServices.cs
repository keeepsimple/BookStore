using BookStore.Data.Infrastructure;
using BookStore.Models.Common;
using BookStore.Services.BaseServices;

namespace BookStore.Services
{
    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        public CategoryServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

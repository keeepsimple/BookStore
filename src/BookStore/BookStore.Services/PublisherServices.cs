using BookStore.Data.Infrastructure;
using BookStore.Models.Common;
using BookStore.Services.BaseServices;

namespace BookStore.Services
{
    public class PublisherServices : BaseServices<Publisher>, IPublisherServices
    {
        public PublisherServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

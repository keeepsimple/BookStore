using BookStore.Models.Common;
using BookStore.Services.BaseServices;
using System;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IReviewServices : IBaseServices<Review>
    {
        Task<int> AddReviewAsync(Guid bookId, string name, string email, string content);

        int AddReview(Guid bookId, string name, string email, string content);
    }
}

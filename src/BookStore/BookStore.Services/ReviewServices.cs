using BookStore.Data.Infrastructure;
using BookStore.Models.Common;
using BookStore.Services.BaseServices;
using System;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class ReviewServices : BaseServices<Review>, IReviewServices
    {
        public ReviewServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public int AddReview(Guid bookId, string name, string email, string content)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Content = content,
                IsActive = true
            };
            _unitOfWork.ReviewRepository.Add(review);
            return _unitOfWork.SaveChanges();
        }

        public Task<int> AddReviewAsync(Guid bookId, string name, string email, string content)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Content = content,
                IsActive = true
            };
            _unitOfWork.ReviewRepository.Add(review);
            return _unitOfWork.SaveChangesAsync();
        }
    }
}

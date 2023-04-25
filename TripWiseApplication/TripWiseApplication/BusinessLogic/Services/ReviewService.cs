using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.DataAccess.Repositories.Interfaces;
using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.Services;

public class ReviewService : IReviewService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async void CreateReview(Review review) 
    {
        await _unitOfWork.ReviewRepository.AddAsync(review);
        _unitOfWork.Save();
    }

    public async void RemoveReview(int id)
    {
        await _unitOfWork.ReviewRepository.RemoveAsync(id);
        _unitOfWork.Save();
    }
}

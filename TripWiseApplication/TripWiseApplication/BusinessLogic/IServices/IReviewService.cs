using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.IServices;

public interface IReviewService
{
    void CreateReview(Review review);
    void RemoveReview(int id);
    IEnumerable<Review> GetAllReviewByRoomId(int id);
}

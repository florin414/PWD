using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.IServices;

public interface IBookingService
{
    void CreateBooking(Booking booking);
    void DeleteBooking(int id);
}

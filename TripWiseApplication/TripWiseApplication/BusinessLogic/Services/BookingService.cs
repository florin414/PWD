using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.DataAccess.Repositories.Interfaces;
using TripWiseApplication.Models;

namespace TripWiseApplication.BusinessLogic.Services;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async void CreateBooking(Booking booking) 
    {
        await _unitOfWork.BookingRepository.AddAsync(booking);
        _unitOfWork.Save();
    }

    public async void DeleteBooking(int id) 
    {
        await _unitOfWork.BookingRepository.RemoveAsync(id);
        _unitOfWork.Save();
    }
}

using TripWiseApplication.Models;

namespace TripWiseApplication.DataAccess.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<Accommodation, int> AccommodationRepository { get; set; }
    IBaseRepository<Customer, int> CustomerRepository { get; set; }
    IBaseRepository<Booking, int> BookingRepository { get; set; }
    IBaseRepository<Review, int> ReviewRepository { get; set; }
    IBaseRepository<Room, int> RoomRepository { get; set; }
    IBaseRepository<Ticket, int> TicketRepository { get; set; }

    IBaseRepository<Image, int> ImageRepository { get; set; }

    void Save();
}

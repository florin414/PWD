using TripWiseApplication.DataAccess.Context;
using TripWiseApplication.DataAccess.Repositories.Interfaces;
using TripWiseApplication.Models;

namespace TripWiseApplication.DataAccess.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly TripWiseApplicationContext _dbContext;
    private bool disposedValue;

    public IBaseRepository<Accommodation, int> AccommodationRepository { get; set; }
    public IBaseRepository<Customer, int> CustomerRepository { get; set; }
    public IBaseRepository<Booking, int> BookingRepository { get; set; }
    public IBaseRepository<Review, int> ReviewRepository { get; set; }
    public IBaseRepository<Room, int> RoomRepository { get; set; }
    public IBaseRepository<Ticket, int> TicketRepository { get; set; }

    public UnitOfWork(
        TripWiseApplicationContext dbContext,
        IBaseRepository<Accommodation, int> accommodationRepository,
        IBaseRepository<Customer, int> customerRepository,
        IBaseRepository<Booking, int> bookingRepository,
        IBaseRepository<Review, int> reviewRepository,
        IBaseRepository<Room, int> roomRepository,
        IBaseRepository<Ticket, int> ticketRepository
    )
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        AccommodationRepository =
            accommodationRepository
            ?? throw new ArgumentNullException(nameof(accommodationRepository));
        CustomerRepository =
            customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        BookingRepository =
            bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        ReviewRepository =
            reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
        RoomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        TicketRepository =
            ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _dbContext?.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripWiseApplication.Models;

namespace TripWiseApplication.DataAccess.Context;

public class TripWiseApplicationContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Booking>? Bookings { get; set; }
    public DbSet<Accommodation>? Accommodations { get; set; }
    public DbSet<Review>? Reviews { get; set; }
    public DbSet<Room>? Rooms { get; set; }
    public DbSet<Ticket>? Tickets { get; set; }

    public TripWiseApplicationContext(DbContextOptions<TripWiseApplicationContext> options) : base(options) { }
}

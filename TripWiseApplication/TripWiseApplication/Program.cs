using Microsoft.EntityFrameworkCore;
using TripWiseApplication.DataAccess.Context;
using TripWiseApplication.DataAccess.Repositories.Interfaces;
using TripWiseApplication.DataAccess.Repositories;
using TripWiseApplication.Models;
using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.BusinessLogic.Services;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();


    var connectionString =
    builder.Configuration.GetConnectionString("TripWiseDBConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'TripWiseDBConnection' not found."
    );

    builder.Services.AddDbContext<TripWiseApplicationContext>(
        options => options.UseSqlServer(connectionString)
    );

    builder.Services.AddScoped<IBaseRepository<Accommodation, int>, BaseRepository<Accommodation, int>>();
    builder.Services.AddScoped<IBaseRepository<Booking, int>, BaseRepository<Booking, int>>();
    builder.Services.AddScoped<IBaseRepository<Customer, int>, BaseRepository<Customer, int>>();
    builder.Services.AddScoped<IBaseRepository<Review, int>, BaseRepository<Review, int>>();
    builder.Services.AddScoped<IBaseRepository<Room, int>, BaseRepository<Room, int>>();
    builder.Services.AddScoped<IBaseRepository<Ticket, int>, BaseRepository<Ticket, int>>();

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

    // Add services entity
    builder.Services.AddScoped<ICustomerService, CustomerService>();
    builder.Services.AddScoped<IAccommodationService, AccommodationService>();
    builder.Services.AddScoped<IBookingService, BookingService>();
    builder.Services.AddScoped<IReviewService, ReviewService>();
    builder.Services.AddScoped<IRoomService, RoomService>();
    builder.Services.AddScoped<ITicketService, TicketService>();



    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception e)
{

    Console.WriteLine(e.ToString());
}

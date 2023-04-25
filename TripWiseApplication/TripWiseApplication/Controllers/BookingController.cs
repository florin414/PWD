using Microsoft.AspNetCore.Mvc;
using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.Models;

namespace TripWiseApplication.Controllers;
public class BookingController : Controller
{
    private readonly IBookingService _bookingService;
    [BindProperty]
    public Booking Booking { get; set; }

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create()
    {
        _bookingService.CreateBooking(Booking);
        return View();
    }
}

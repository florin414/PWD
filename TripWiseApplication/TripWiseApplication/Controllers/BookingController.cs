using Microsoft.AspNetCore.Mvc;
using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.Models;

namespace TripWiseApplication.Controllers;

public class BookingController : Controller
{
    private readonly IBookingService _bookingService;
    private readonly IAccommodationService _accommodationService;
    private readonly IImageService _imageService;

    [BindProperty]
    public Booking Booking { get; set; }

    public BookingController(
        IBookingService bookingService,
        IAccommodationService accommodationService,
        IImageService imageService
    )
    {
        _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        _accommodationService =
            accommodationService ?? throw new ArgumentNullException(nameof(accommodationService));
        _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
    }

    [HttpGet]
    public IActionResult Index(int id)
    {
        var accommodation = _accommodationService
            .GetAll()
            .FirstOrDefault(x => x.AccommodationId == id);
        var image = _imageService.GetAll().FirstOrDefault(x => x.AccommodationId.Equals(id));
        return View((accommodation, image));
    }

    [HttpPost]
    public IActionResult Create()
    {
        _bookingService.CreateBooking(Booking);
        return View();
    }
}

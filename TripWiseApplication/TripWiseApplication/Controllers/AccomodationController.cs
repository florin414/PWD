using Microsoft.AspNetCore.Mvc;
using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.Models;

namespace TripWiseApplication.Controllers;
public class AccomodationController : Controller
{
    private readonly IAccommodationService _accommodationService;
    [BindProperty]
    public Accommodation Accommodation { get; set; }

    public AccomodationController(IAccommodationService accommodationService)
    {
        _accommodationService = accommodationService ?? throw new ArgumentNullException(nameof(accommodationService));
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create()
    {
        _accommodationService.AddAccomodation(Accommodation);
        return View();
    }
}

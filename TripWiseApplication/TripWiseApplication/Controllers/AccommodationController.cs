using Microsoft.AspNetCore.Mvc;
using TripWiseApplication.BusinessLogic.IServices;
using TripWiseApplication.BusinessLogic.Services;
using TripWiseApplication.Models;

namespace TripWiseApplication.Controllers;

public class AccommodationController : Controller
{
    private readonly IAccommodationService _accommodationService;
    private readonly IImageService _imageService;

    [BindProperty]
    public Accommodation Accommodation { get; set; }

    public AccommodationController(
        IAccommodationService accommodationService,
        IImageService imageService
    )
    {
        _accommodationService =
            accommodationService ?? throw new ArgumentNullException(nameof(accommodationService));
        _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
    }

    [HttpGet]
    public IActionResult Index()
    {
        var accomodations = _accommodationService.GetAll();
        var images = _imageService.GetAll().ToArray();
        return View((accomodations, images));
    }
}


